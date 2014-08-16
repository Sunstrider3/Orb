using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float rotationSpeed;
    
    private CharacterController controller;
    private Transform myTransform;

	void Start ()
    {
        controller = GetComponent<CharacterController>();
        myTransform = this.transform;
	}
	
	void Update ()
    {
        Move();
	}

    private Quaternion targetRotation;
    private void Move()
    {

        Vector3 input = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));

        Vector3 motion = input;
        motion = Vector3.ClampMagnitude(motion, 1f);

        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }


        anim.SetFloat("Speed", motion.magnitude);
        anim.SetBool("Run", Input.GetButton("Sprint"));
        //controller.Move(input * Time.deltaTime);
    }
}
