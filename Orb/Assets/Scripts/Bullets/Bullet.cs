using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 5;

	void Update ()
    {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }
}
