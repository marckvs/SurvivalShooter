using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text TextNumBadBunny;
    public Text TextNumHellephant;
    public Text TextNumZomBear;

    private int numBadBunny;
    private int numZomBear;
    private int numHellephant;

    void Start()
    {
        numBadBunny = 0;
        numHellephant = 0;
        numZomBear = 0;

    }

    public void IncreaseNumBunny()
    {
        numBadBunny++;
        TextNumBadBunny.text = "BadBunny: " + numBadBunny;
    }

    public void DecreaseNumBunny()
    {
        numBadBunny--;
        TextNumBadBunny.text = "BadBunny: " + numBadBunny;
    }

    public void IncreaseNumBear()
    {
        numZomBear++;
        TextNumZomBear.text = "ZomBear: " + numZomBear;
    }

    public void DecreaseNumBear()
    {
        numZomBear--;
        TextNumZomBear.text = "ZomBear: " + numZomBear;
    }

    public void IncreaseNumHellephant()
    {
        numHellephant++;
        TextNumHellephant.text = "Hellephant: " + numHellephant;
    }

    public void DecreaseNumHellephant()
    {
        numHellephant--;
        TextNumHellephant.text = "Hellephant: " + numHellephant;
    }
}
