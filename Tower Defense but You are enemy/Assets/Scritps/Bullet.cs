using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    public int damage = 50;
    
    

    public void Seek(Transform _target)
    {
        target = _target;  

    }
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget(target);
            Destroy(gameObject);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(Transform hitTarget)
    {
        Debug.Log("hit");
        CharacterMove characterMove = hitTarget.GetComponent<CharacterMove>();
        if(characterMove != null && characterMove.Immune() == false)
        {
            characterMove.TakingDamage(damage);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Target"))
    //    {
            
    //    }
    //}
   
    
}
