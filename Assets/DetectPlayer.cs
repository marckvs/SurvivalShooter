using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

    private bool inArea;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inArea = false;
        }
    }

    public bool InArea() {
        return inArea;
    }
}
