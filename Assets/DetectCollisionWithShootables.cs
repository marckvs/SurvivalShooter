using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionWithShootables : MonoBehaviour {

    private SphereSpawner sphereSpawner;

    void Start()
    {
        sphereSpawner = GameObject.FindWithTag("SphereSpawner").GetComponent<SphereSpawner>();
    }

	void OnTriggerEnter(Collider c)
    {

        if(c.tag == "Player")
        {
            sphereSpawner.SetNumSpheres(sphereSpawner.GetNumSpheres() - 1);
            Destroy(this.gameObject);
        }
    }
}
