using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    float infiniteDamagePerShot = Mathf.Infinity;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    float timer;
    float timerGreenShot = 4;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    bool greenShot;
    Color color;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponentInChildren<ParticleSystem> ();
        gunLine = GetComponentInChildren<LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponentInChildren<Light> ();
    }

    void CheckGreenLight()
    {
        Debug.Log("green");
    }

    void OnTriggerEnter(Collider c)
    {
        greenShot = true;
        CheckGreenLight();
    }

    void Update ()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && greenShot)
        {
            Debug.Log("greenShot");
            greenShot = false;
            Shoot();
        }
        else if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if (greenShot)
            {
                Debug.Log("infinito");
                enemyHealth.TakeDamage((int)infiniteDamagePerShot, shootHit.point);
            }

            else if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }

    public void SetGreenShot(bool b)
    {
        greenShot = b;
    }
}
