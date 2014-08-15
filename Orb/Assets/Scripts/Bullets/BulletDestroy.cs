using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour
{
    public float LifeTime = 2f;

    void OnEnable()
    {
        Invoke("Destroy", LifeTime);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
