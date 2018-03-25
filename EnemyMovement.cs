using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public AudioClip LoseLifeSound;
    private Transform target;
    private int wavepointIndex = 0;



    private Enemy enemy;
    //initiating the enemy prefab from the first way point
    void Start()

    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }
    void Update()
    {
      //  print(enemy.isDead);
        if (enemy.isDead) return;

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 1f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
        transform.LookAt(target);
    }
    //sends the enemy from on way point to the next
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    //losing 1 life for every enemy reaching the end point
    void EndPath()
    {
        AudioSource.PlayClipAtPoint(LoseLifeSound, Camera.main.transform.position);
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}


