using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask order_console_mask;
    public float interaction_range;

    public Camera cam;

    void Update()
    {
        Ray camera_ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if(Input.GetKeyDown(KeyCode.E))
        {   
            if(Physics.Raycast(camera_ray, out RaycastHit hit_info, interaction_range, order_console_mask))
            {
                hit_info.transform.gameObject.GetComponent<OrderConsole>().start_order();
            }
        }
        
        //to test end_order
        if(Input.GetKeyDown(KeyCode.R))
        {   
            if(Physics.Raycast(camera_ray, out RaycastHit hit_info, interaction_range, order_console_mask))
            {
                hit_info.transform.gameObject.GetComponent<OrderConsole>().end_order();
            }
        }
    }
}
