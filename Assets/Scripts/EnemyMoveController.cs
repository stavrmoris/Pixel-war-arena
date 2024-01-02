using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private EnemySearch enemySearch;
    public bool closeCombat;
    private Animator _anim;

    void Start()
    {
        enemySearch = GetComponent<EnemySearch>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(enemySearch.triggerEnemy.transform.position, transform.position) > 9 && !closeCombat)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemySearch.triggerEnemy.transform.position, speed * Time.deltaTime);
            _anim.SetBool("run", true);
        }
        else if (Vector3.Distance(enemySearch.triggerEnemy.transform.position, transform.position) < 5 && !closeCombat)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemySearch.triggerEnemy.transform.position, -speed * 0.4f * Time.deltaTime);
            _anim.SetBool("run", true);
        }            
        else if (Vector3.Distance(enemySearch.triggerEnemy.transform.position, transform.position) > 2 && closeCombat)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemySearch.triggerEnemy.transform.position, speed * Time.deltaTime);
            _anim.SetBool("run", true);
        }
        else if (Vector3.Distance(enemySearch.triggerEnemy.transform.position, transform.position) < 1 && closeCombat)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemySearch.triggerEnemy.transform.position, -speed * 0.8f * Time.deltaTime);
            _anim.SetBool("run", true);
        }
        else
        {
            _anim.SetBool("run", false);
        }
        
        if(enemySearch.triggerEnemy.transform.position.x > transform.position.x)
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        
    }
}
