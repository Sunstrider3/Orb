using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaceTerrain : MonoBehaviour
{
    public List<Terrain> terrain;

	void Start ()
    {
        for (int i = 0; i < terrain.Count; i++)
        {
            terrain[i].transform.position = new Vector3(0, 0, i * 2000);
        }
	
	}

    void Update()
    {
	
	}
}
