using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sensitivity;
    public float speed;
    public Transform cam;
    
    CharacterController controller;
    Vector2 look;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 input = new Vector3();
        input += transform.forward * y;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        controller.Move(input * speed * Time.deltaTime);

        look.x += Input.GetAxis("Mouse X");
        look.y += Input.GetAxis("Mouse Y");

        look.y = Mathf.Clamp(look.y, -89f, 89f);

        cam.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }
}
