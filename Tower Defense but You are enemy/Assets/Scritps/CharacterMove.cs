using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedDefault = 10f;
    public int health = 100;

    private Transform target;
    private int wavepointIndex = 0;
    public float speedtemp;
    Bullet bullet;
    private static bool isTakingDam = false;
    
    public void ApplySkill(Skill s)
    {
        s.UseSkill(this);
    }

    private void Start()
    {
        target = Waypoints.points[0];
        speedtemp = speedDefault;
    }

    public void TakingDamage(int amount)
    {
        
        health -= amount;
        
        if(health <= 0)
        {
            Die();
        }
    }
    public bool Immune()
    {
        return isTakingDam;
    }
  

    void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speedDefault * Time.deltaTime,Space.World);

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

    public void setImmune(bool set)
    {
        isTakingDam = set;
    }
}
