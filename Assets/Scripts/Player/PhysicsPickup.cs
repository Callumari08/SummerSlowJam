using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    public LayerMask pickupMask;
    public Transform pickupPoint;
    public float pickupRange;

    public Camera cam;

    Rigidbody currentObject;

    void Update()
    {
        Ray camera_ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if(Input.GetMouseButton(0))
        {            
            if(Physics.Raycast(camera_ray, out RaycastHit hit_info, pickupRange, pickupMask))
            {
                currentObject = hit_info.rigidbody;
            }
        }
        else
        {
            if(currentObject)
            {
                currentObject = null;
            }
        }
    }

    void FixedUpdate()
    {
        if(currentObject)
        {
            Vector3 direction_to_point = pickupPoint.position - currentObject.position;
            float distance_to_point = direction_to_point.magnitude;
 
            currentObject.velocity = direction_to_point * 12f * distance_to_point;
        }
    }
}
