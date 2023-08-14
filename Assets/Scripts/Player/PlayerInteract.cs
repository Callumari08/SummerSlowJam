using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask orderConsoleMask;
    public float interactionRange;

    public Camera cam;

    void Update()
    {
        Ray camera_ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if(Input.GetKeyDown(KeyCode.E))
        {   
            if(Physics.Raycast(camera_ray, out RaycastHit hit_info, interactionRange, orderConsoleMask))
            {
                hit_info.transform.gameObject.GetComponent<OrderConsole>().EndOrder();
            }
        }
        
        //to test end_order
        if(Input.GetKeyDown(KeyCode.R))
        {   
            if(Physics.Raycast(camera_ray, out RaycastHit hit_info, interactionRange, orderConsoleMask))
            {
                hit_info.transform.gameObject.GetComponent<OrderConsole>().EndOrder();
            }
        }
    }
}
