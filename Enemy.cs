using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    public AudioClip DieSound;
    Animator animator;
    
  //  bool isWalking = true;
  //  float inputX = 0f;
    float inputZ = 0f;
    public float moveSpeed = 0f;
   // float runSpeed = 0f;
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;
    
    public float startHealth = 100;
    private float health;

    public int worth = 30;

   // public GameObject deathEffect;

    public bool isDead = false;

    [Header("Unity Stuff")]
    public Image healthBar;
   // public GameObject CloseHealthBar;

    void Start()
    {

       
        animator = GetComponent<Animator>();
        
        speed = startSpeed;
        health = startHealth;
    }
    void Update()
    {
        //print(name + " " + moveSpeed);
        animator.SetFloat("moveSpeed", moveSpeed);
    }

   
    //method for killing enemy if health is 0 + healthbar
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(DieSound, Camera.main.transform.position);
            Die();
           
        }
    }

    //method for slowing down enemies when using laser
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
    //killing enemies + take money
    public void Die()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        PlayerStats.Money += worth;
        isDead = true;

        //no rotation = quaterinion.identity
     //   GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect);

        animator.SetTrigger("die");
        WaveSpawner.EnemiesAlive--;
       // Debug.Log("dasdasdasd" + " " + name);
        //Destroy(gameObject);
    }
    //destroy enemy object
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    //animation
    void Walk()
    {
        animator.SetBool("isWalking", inputZ != 0f);
        animator.SetFloat("moveSpeed", inputZ);
    }
}