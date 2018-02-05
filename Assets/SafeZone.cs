using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour {

    private bool playerIsInside = false;

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsInside = false;
        }
    }
    
    public bool PlayerIsInside()
    {
        return playerIsInside;
    }
}
