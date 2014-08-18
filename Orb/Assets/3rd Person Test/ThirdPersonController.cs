using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour
{
    public Animator anim;
    public Transform myCamera;
    public float lookSpeed = 1f;
    public float rotationSpeed = 360f;
    public float maxSpeed = 2;

    // private CharacterController controller;
    private Transform myTransform;

	void Start ()
    {
        //controller = GetComponent<CharacterController>();
        myTransform = this.transform;
	}
	
	void Update ()
    {
        Move();
        //UpdateCamera();

	}

    private Quaternion targetRotation;
    private float speed;
    private void Move()
    {

        Vector3 input = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));

        Vector3 motion = myCamera.TransformDirection(input);
        motion = Vector3.ClampMagnitude(motion, 1f);

        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(motion);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }

        //anim.SetBool("Jump", Input.GetButtonDown("Jump"));
        
        speed += (Input.GetButton("Sprint")) ? Time.deltaTime : -Time.deltaTime;
        speed = (speed <= 1) ? motion.magnitude : Mathf.Clamp(speed, 1, maxSpeed);

        // anim.SetFloat("Speed", Mathf.Abs(motion.magnitude));
        anim.SetFloat("Speed", speed);
    }

    private void UpdateCamera()
    {

        Quaternion target = Quaternion.Euler(
            myCamera.rotation.x,
            myCamera.rotation.y + Input.GetAxis("Mouse X"),
            myCamera.rotation.z);

        myCamera.rotation = target;
        myCamera.position = myTransform.position;
    }
}
