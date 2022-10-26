using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject targetToAttack;
    public float range;
    public string targetsTag = "Target";
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    

    void UpdateTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetsTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestTarget = null;
        foreach(GameObject target in targets)
        {
            float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
            if(distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = target;
            }
        }
        if(nearestTarget != null && shortestDistance <= range)
        {
            targetToAttack = nearestTarget ;
        }
        else
        {
            targetToAttack = null; 
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(targetToAttack == null)
        {
            UpdateTarget(); 
  
        }else
        {
            if (Vector2.Distance(targetToAttack.transform.position, transform.position) > range)
            {
                UpdateTarget(); 
             
            }
        }

        if (targetToAttack == null)
        {
            return;
        }

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    void Shoot()
    {
        Debug.Log("Shoot!");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(targetToAttack.transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
