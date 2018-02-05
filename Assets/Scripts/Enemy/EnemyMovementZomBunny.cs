using UnityEngine;
using System.Collections;

public class EnemyMovementZomBunny : MonoBehaviour
{
    Animator anim;
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    float dist;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        dist = Vector3.Distance(player.position, gameObject.transform.position);
        anim = GetComponent<Animator>();
    }


    void Update ()
    {
        dist = Vector3.Distance(player.position, gameObject.transform.position);

        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && dist < 10f)
        {
            anim.SetBool("InRange", true);
            nav.enabled = true;
            nav.SetDestination(player.position);
        }
        else
        {
            anim.SetBool("InRange", false);
            nav.enabled = false;
        }
    }
}
