using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedDefault = 10f;
    public float health = 100f;
    public float maxHP;

    private Transform target;
    private int wavepointIndex = 0;
    public float speedtemp;
    Bullet bullet;
    private static bool isTakingDam = false;

    [SerializeField] private GameManager _gameManager;

    private bool _dead;
    public bool Dead => _dead;

    public HealthBar Healthbar;
    
    public void ApplySkill(Skill s)
    {
        s.UseSkill(this);
    }

    private void Start()
    {
        maxHP = health;
        _gameManager.RegisterCharacter(this);
        target = Waypoints.points[0];
        speedtemp = speedDefault;
        //HealthBar.SetHealth(health, maxHP);
    }

    public void TakingDamage(float amount)
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
        _dead = true;
        _gameManager.NotifyDeath(this);
        
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
            ScoreManager.instance.AddScore();
            _dead = true;
            _gameManager.NotifyDeath(this);
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
