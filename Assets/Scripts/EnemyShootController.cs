using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    [SerializeField] private float offset;  
    [SerializeField] private float speed = 10;
    [SerializeField] private Rigidbody2D bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1;
    [SerializeField] private float ratio;
    private EnemyMoveController _enemyMoveController;
    private EnemySearch _enemySearch;  
    private float _curTimeout;
    private Animator _anim;
    
    void Start()
    {
        _enemyMoveController = GetComponentInParent<EnemyMoveController>();
        _enemySearch = GetComponentInParent<EnemySearch>();
        _anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        _curTimeout += Time.deltaTime;

        if(Vector3.Distance(_enemySearch.triggerEnemy.transform.position, transform.position) < 14)
        {
            Fire();
        }
        
        Rotate();
    }

    void Rotate()
    {
        Vector3 diference = _enemySearch.triggerEnemy.transform.position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        Vector3 localScale = Vector3.one;

        if (rotateZ > 90 || rotateZ < -90)
            localScale.y = -1f;
        else
            localScale.y = 1f;

        transform.localScale = localScale;
    }
    
    void Fire()
    {
        var rate = Random.Range(fireRate + ratio, fireRate - ratio);
        if(_curTimeout >= rate)
        {
            _curTimeout = 0;
            _anim.SetTrigger("attack");
            if (!_enemyMoveController.closeCombat)
            {
                Rigidbody2D clone = Instantiate(bullet, firePoint.position, firePoint.rotation);
                clone.AddForce(firePoint.right * speed, ForceMode2D.Impulse);
            }
        }
    }
}
