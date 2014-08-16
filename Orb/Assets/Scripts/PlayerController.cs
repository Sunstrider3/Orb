using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 450;
    public float walkSpeed = 5;
    public float runSpeed = 8;

    private CharacterController controller;
    private Quaternion targetRotation;
    private Camera cam;

    public Gun EquipedGun;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    void Update()
    {
        ControlMouseLook();
        Shooting();
    }

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EquipedGun.Shoot(transform);
        }
        else if (Input.GetMouseButton(0))
        {
            EquipedGun.ShootAuto(transform);
        }
    }

    void ControlMouseLook()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, cam.transform.position.y - transform.position.y));

        targetRotation = Quaternion.LookRotation(mousePosition - new Vector3(transform.position.x, 0, transform.position.z));
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);


        Vector3 input = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0,
            Input.GetAxisRaw("Vertical"));
        Vector3 motion = input;
        motion *= (Mathf.Abs(motion.x) == 1 && Mathf.Abs(motion.z) == 1) ? 0.7071f : 1;
        motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
        motion += Vector3.up * -9.81f;

        controller.Move(motion * Time.deltaTime);
    }
    void ControlWASD()
    {
        Vector3 input = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0,
            Input.GetAxisRaw("Vertical"));

        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }

        Vector3 motion = input;
        motion *= (Mathf.Abs(motion.x) == 1 && Mathf.Abs(motion.z) == 1) ? 0.7f : 1;
        motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
        motion += Vector3.up * -9.81f;

        controller.Move(motion * Time.deltaTime);
    }

}