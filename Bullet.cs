using UnityEngine;


public class Bullet : MonoBehaviour
{
    
    public AudioClip ShootSound;
    private Transform target;
    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;
    public GameObject impactEffect;


    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame && !target.GetComponent<Enemy>().isDead)
        {
            AudioSource.PlayClipAtPoint(ShootSound, Camera.main.transform.position);
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        //make the missile follow the target in right direction
        transform.LookAt(target);

    }
    //hitting the target and area of effect for missile bullet
    void HitTarget()
    {
        GameObject effectsInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(effectsInstance, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        //Destroy(target.gameObject);
        Destroy(gameObject);
    }
    // if the bullet hits a collider damage the enemy.
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        {
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }
        }
    }
    //make enemy take damage from bullets
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {

            e.TakeDamage(damage);
        }


    }
    //debug to see range of tower inside scene.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
