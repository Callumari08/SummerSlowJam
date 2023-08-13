using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    public LayerMask pickup_mask;
    public Transform pickup_point;
    public float pickup_range;

    public Camera cam;

    Rigidbody current_object;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray camera_ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if(Physics.Raycast(camera_ray, out RaycastHit hit_info, pickup_range, pickup_mask))
            {
                current_object = hit_info.rigidbody;
                current_object.useGravity = false;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            current_object.useGravity = true;
            current_object = null;
        }
    }

    void FixedUpdate()
    {
        if(current_object != null)
        {
            current_object.position = Vector3.MoveTowards(current_object.position, pickup_point.position, 5 * Time.deltaTime);
        }
    }
}
