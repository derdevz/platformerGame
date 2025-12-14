using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class ChickenAI : MonoBehaviour
{
    public float _speed;
    public float _radius;
    private Rigidbody2D _chickenRbBody;
    public GameObject _groundCheck;
    public LayerMask _groundLayer;
    public bool _facingRight;
    public bool _duvarDegdimi;

    private void Start()
    {
        _chickenRbBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!_facingRight)
        {
        _chickenRbBody.linearVelocity = new Vector2(_speed, _chickenRbBody.linearVelocity.y);
        }
        else
        {
            _chickenRbBody.linearVelocity = new Vector2(-_speed, _chickenRbBody.linearVelocity.y);
        }

        _duvarDegdimi = Physics2D.OverlapCircle(_groundCheck.transform.position, _radius, _groundLayer);
        if (_duvarDegdimi == true)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth _healthScript = other.gameObject.GetComponent<PlayerHealth>();
            
            _healthScript.Damaged(1);
        }
    }
}
