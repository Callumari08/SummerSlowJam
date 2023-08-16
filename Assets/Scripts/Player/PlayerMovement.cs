using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using UnityEngineInternal;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float rotationSpeed = 3f;
    public int maxBounces = 5;
    [Range(0f, 100f)]
    public float maxSlopeAngle = 55;
    public float gravity = 9;
    public Camera cam; 

    CapsuleCollider capsuleCollider;
    Rigidbody rb;
    Bounds bounds;
    bool isGrounded = true;
    float yaw;
    float pitch;

    private void Awake()
    {
        yaw = 90;
        pitch = 90;
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        bounds = capsuleCollider.bounds;

        CameraRotation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = cam.transform.forward * z + cam.transform.right * x;

        moveDirection = CollideAndSlide(moveDirection, transform.position, 0, false, moveDirection);
        moveDirection += CollideAndSlide(Vector3.down * gravity, transform.position + moveDirection, 0, true, Vector3.down * gravity).normalized;

        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    void CameraRotation()
    {
        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, -90, 90);

        transform.eulerAngles = new Vector3(0, yaw, 0);
        cam.transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }

    Vector3 CollideAndSlide(Vector3 vel, Vector3 pos, int depth, bool gravityPass, Vector3 velInit)
    {
        const float skinWidth = 0.015f;

        bounds.Expand(-2 * skinWidth);

        if (depth >= maxBounces)
        {
            return Vector3.zero;
        }

        float dist = vel.magnitude + skinWidth;

        Vector3 capPos = transform.position + capsuleCollider.center;

        if (Physics.CapsuleCast(capPos + new Vector3(0f, capsuleCollider.height / 2f), 
            capPos - new Vector3(0f, capsuleCollider.height / 2f), 
            capsuleCollider.radius, vel.normalized, out RaycastHit hit, dist))
        {
            Vector3 snapToSurface = vel.normalized * (hit.distance - skinWidth);
            Vector3 leftover = vel - snapToSurface;
            float angle = Vector3.Angle(Vector3.up, hit.normal);
            float scale = 1f;

            if (snapToSurface.magnitude <= skinWidth)
                snapToSurface = Vector3.zero;

            if (angle <= maxSlopeAngle) // Normal Ground / Slope
            {
                if (gravityPass) 
                    return snapToSurface;

                leftover = ProjectAndScale(leftover, hit.normal);
            }

            else // Wall or steep slope
            {
                scale = 1f - Vector3.Dot(
                    new Vector3(hit.normal.x, 0f, hit.normal.z).normalized,
                    -new Vector3(velInit.x, 0f, velInit.z).normalized);

                if (isGrounded && !gravityPass)
                {
                    leftover = ProjectAndScale(
                        new Vector3(leftover.x, 0f, leftover.z),
                        new Vector3(hit.normal.x, 0f, hit.normal.z)).normalized;

                    leftover *= scale;
                }
                else leftover = ProjectAndScale(leftover, hit.normal) * scale;
            }

            return snapToSurface + CollideAndSlide(leftover, pos + snapToSurface, depth + 1, gravityPass, velInit);
        }

        return vel;
    }

    Vector3 ProjectAndScale(Vector3 vec, Vector3 normal)
    {
        float mag = vec.magnitude;

        vec = Vector3.ProjectOnPlane(vec, normal).normalized;
        vec *= mag;

        return vec;
    }
}