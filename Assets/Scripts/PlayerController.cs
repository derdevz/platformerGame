using System;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private PlayerHealth _healthScript;
    private Rigidbody2D rb;
    private Animator _anim;
    private CapsuleCollider2D _capsuleCollider;
    private float moveX;
    private bool jumpRequest = false;
    private float nextJumpTime = 0f;
    private float jumpCooldown = 0.2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
       moveX = Input.GetAxis("Horizontal");

       _anim.SetBool("Run", moveX != 0);
       _anim.SetBool("Grounded", isGrounded());

       if (Input.GetKey(KeyCode.Space) && isGrounded() && Time.time >= nextJumpTime)
        {
        jumpRequest = true;
    
        nextJumpTime = Time.time + jumpCooldown; 
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * _speed, rb.linearVelocity.y);

        if(moveX > 0.01f)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        
        else if(moveX < -0.01f)
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
        }

        if (jumpRequest)
        {
            Jump();
            jumpRequest = false;
        }
    }

    private void Jump()
    {
         rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); 
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, _jumpForce);
        _anim.SetTrigger("Jump");
    }

    private bool isGrounded()
    {
        Vector2 boxSize = _capsuleCollider.bounds.size;

        boxSize.x = boxSize.x * 0.8f;

        RaycastHit2D raycastHit = Physics2D.BoxCast(_capsuleCollider.bounds.center, boxSize, 0, Vector2.down, 0.1f, groundLayer);
          
         return raycastHit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("diken"))
        {
            _healthScript.Damaged(1);
        }

        if (collision.CompareTag("Chicken"))
        {
            _healthScript.Damaged(1);
        }
    }

    private void SetCheckPoint()
    {
        
    }
}
