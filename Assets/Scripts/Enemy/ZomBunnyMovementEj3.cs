using UnityEngine;
using System.Collections;

public class ZomBunnyMovementEj3 : MonoBehaviour
{
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    SafeZone safeZone;
    GameObject spawnBunny;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        safeZone = GameObject.FindGameObjectWithTag ("SafeZone").GetComponent<SafeZone>();
        spawnBunny = GameObject.FindGameObjectWithTag("SpawnBunny");
    }


    void Update ()
    {
        Debug.Log(safeZone.PlayerIsInside());

        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !safeZone.PlayerIsInside())
        {
            nav.SetDestination(player.transform.position);
        }
        else if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && safeZone.PlayerIsInside())
        {          
            nav.SetDestination(spawnBunny.transform.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
