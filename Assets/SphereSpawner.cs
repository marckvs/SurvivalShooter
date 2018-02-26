using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour {

    public GameObject sphere;
    public float spawnTime;

    [HideInInspector]
    public int numSpheres;

    private float time;

    // Use this for initialization
    void Start () {
        numSpheres = 0;
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        if (time >= spawnTime && numSpheres < 3)
        {
            time = 0;
            Invoke("SpawnSphere", spawnTime);
        }
    }

    Vector3 GeneratePosition()
    {
        Vector3 position = new Vector3(Random.Range(-33, 33), 0.5f , Random.Range(-7, 7));
        return position;
    }

    void SpawnSphere()
    {
        Vector3 position = GeneratePosition();
        numSpheres++;
        Instantiate(sphere, position, Quaternion.identity);
    }

    public int GetNumSpheres()
    {
        return numSpheres;
    }

    public void SetNumSpheres(int n) {
        numSpheres = n;
    }

    
    
    


}
