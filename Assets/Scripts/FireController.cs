using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
	[SerializeField] private Rigidbody2D bullet;
	[SerializeField] private Transform firePoint;
	[SerializeField] private float fireRate = 1;
    [SerializeField] private Animator anim;
	[SerializeField] private float curTimeout;
	
    public void Start() => anim = GetComponent<Animator>();
    
	void Update()
	{
		curTimeout += Time.deltaTime;

		if(Input.GetMouseButton(0))
		{
			Fire();
		}
	}

	void Fire()
	{
		if(curTimeout >= fireRate)
		{
			curTimeout = 0;
			anim.SetTrigger("attack");
			Rigidbody2D clone = Instantiate(bullet, firePoint.position, firePoint.rotation) as Rigidbody2D;
			clone.AddForce(firePoint.right * speed, ForceMode2D.Impulse);
		}
	}
}
