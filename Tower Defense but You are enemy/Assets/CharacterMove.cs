using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public int health = 100;

    private Transform target;
    private int wavepointIndex = 0;
    float speedtemp;
    Bullet bullet;

    private void Start()
    {
        target = Waypoints.points[0];
        speedtemp = speed;
    }

    public void TakingDamage(int amount)
    {
        health -= amount;
        
        if(health <= 0)
        {
            Die();
        }
    }
  

    void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        if(Spawner.area < 5)
        {
            speed = 0;
        }
        else
        {
            speed = speedtemp;
        }
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
