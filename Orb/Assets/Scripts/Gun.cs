using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (AudioSource))]
public class Gun : MonoBehaviour
{
    public enum GunType
    {
        SemiAutomatic,
        Automatic,
        laser,
    }
    public GunType guntype;
    public Transform projectileSpawn;
    public float rpm;
    public GameObject bullet;
    public float bulletSpeed;
    public int PooledBullets = 10;

    List<GameObject> bulletList;
    
    private float secondsBetweenShots;
    private float nextPossibleShootTime;

    void Start()
    {
        secondsBetweenShots = 60 / rpm;

        bulletList = new List<GameObject>();
        for (int i = 0; i < PooledBullets; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            obj.GetComponent<Bullet>().speed = bulletSpeed;
            obj.SetActive(false);
            bulletList.Add((GameObject)obj);
        }
        

    }

    public void Shoot(Transform forward)
    {
        if (CanShoot())
        {
            /*Ray ray = new Ray(projectileSpawn.position, projectileSpawn.forward);
            RaycastHit hit;
            float projectileDistance = 20;

            if (Physics.Raycast(ray, out hit, projectileDistance))
            {
                projectileDistance = hit.distance;
            }
            Debug.DrawRay(ray.origin, ray.direction * projectileDistance, Color.magenta, 1);
            */

            for (int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].activeInHierarchy)
                {
                    bulletList[i].transform.position = projectileSpawn.position;
                    bulletList[i].transform.rotation = projectileSpawn.rotation;
                    bulletList[i].SetActive(true);
                    break;

                }
            }

            
            nextPossibleShootTime = Time.time + secondsBetweenShots;

            audio.Play();
        }
    }

    private bool CanShoot()
    {
        bool canShoot = true;

        if (Time.time < nextPossibleShootTime)
        {
            canShoot = false;
        }

        return canShoot;
    }

    public void ShootAuto(Transform forward)
    {
        if (guntype == GunType.Automatic)
            Shoot(forward);
    }
}
