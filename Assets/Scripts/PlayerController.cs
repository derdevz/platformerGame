using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _jumpMount = 1;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private Animator _anim;
    private BoxCollider2D _boxCollider;
    private float moveX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
       moveX = Input.GetAxis("Horizontal");

       _anim.SetBool("Run", moveX != 0);
       _anim.SetBool("Grounded", isGrounded());
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * _speed, rb.linearVelocity.y);

        if(moveX > 0.01f )
        {
            transform.localScale = Vector3.one;
        }
        
        else if(moveX < -0.01f )
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(Input.GetKey(KeyCode.Space) && isGrounded() == true)
        {
           Jump();
        }
    }

    private void Jump()
    {
         rb.linearVelocity = new Vector2(rb.linearVelocity.x, _jumpForce);
         _anim.SetTrigger("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
