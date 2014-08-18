using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public float lookSpeed;
    public Transform player;

    private Transform myTransform;

    void Start ()
    {
        myTransform = this.transform;
	}
	
	void Update ()
    {
        float xDistance = Input.GetAxis("Mouse X") * lookSpeed;
        float yDistance = Input.GetAxis("Mouse Y") * lookSpeed;
        Quaternion target = Quaternion.Euler(
            myTransform.eulerAngles.x - yDistance,
            myTransform.eulerAngles.y + xDistance,
            myTransform.eulerAngles.z);

        myTransform.rotation = target;

        myTransform.position = new Vector3(
            player.position.x,
            player.position.y + 1.75f,  //moves camera up to look at head
            player.position.z);

    }
}
