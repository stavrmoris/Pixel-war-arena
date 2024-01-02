using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool killMyself;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gladiator"))
        {
            other.gameObject.GetComponent<EnemyHealthController>().hp -= damage;
            
            if(killMyself)
                Destroy(gameObject);
        }
    }
}
