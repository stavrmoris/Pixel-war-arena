using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    [SerializeField] private float runSpeed;
    private Animator _anim;
    private Rigidbody2D _rb;
    private float _horizontal;
    private float _vertical;
    private Camera _main;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _main = FindObjectOfType<Camera>();
    }

    void Update()
    {   
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical"); 
        
        _rb.velocity = new Vector2(_horizontal * runSpeed, _vertical * runSpeed); 
        
        if(_horizontal != 0 || _vertical != 0)
            _anim.SetBool("run", true);
        else
            _anim.SetBool("run", false);
        
        if(Input.mousePosition.x > _main.WorldToScreenPoint(transform.position).x)
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        
    }
}
