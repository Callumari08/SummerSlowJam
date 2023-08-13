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
        Ray camera_ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if(Input.GetMouseButton(0))
        {            
            if(Physics.Raycast(camera_ray, out RaycastHit hit_info, pickup_range, pickup_mask))
            {
                current_object = hit_info.rigidbody;
                current_object.useGravity = false;
            }
        }
        else
        {
            if(current_object)
            {
                current_object.useGravity = true;
                current_object = null;
            }
        }
    }

    void FixedUpdate()
    {
        if(current_object)
        {
            Vector3 direction_to_point = pickup_point.position - current_object.position;
            float distance_to_point = direction_to_point.magnitude;
 
            current_object.velocity = direction_to_point * 12f * distance_to_point;
        }
    }
}
