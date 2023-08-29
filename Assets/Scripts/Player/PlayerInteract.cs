using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask InteractableMask;
    public float interactionRange;

    public Camera cam;

    void Update()
    {
        Ray camera_ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(camera_ray, out RaycastHit hit_info, interactionRange, InteractableMask))
            {
                if ((hit_info.transform.gameObject.GetComponent("OrderConsole") as OrderConsole) != null)
                {
                    hit_info.transform.gameObject.GetComponent<OrderConsole>().StartOrder();
                    hit_info.transform.gameObject.GetComponent<OrderConsole>().StartEndOrder();
                }

                if ((hit_info.transform.gameObject.GetComponent("Door") as Door) != null)
                {
                    hit_info.transform.gameObject.GetComponent<Door>().Open();
                }

                if ((hit_info.transform.gameObject.GetComponent("Rent") as Rent) != null)
                {
                    hit_info.transform.gameObject.GetComponent<Rent>().Pay();
                }

                if ((hit_info.transform.gameObject.GetComponent("Bed") as Bed) != null)
                {
                    hit_info.transform.gameObject.GetComponent<Bed>().OpenPanel();
                }

                if ((hit_info.transform.gameObject.GetComponent("Computer") as Computer) != null)
                {
                    hit_info.transform.gameObject.GetComponent<Computer>().OpenPanel();
                }
            }
        }
    }
}
