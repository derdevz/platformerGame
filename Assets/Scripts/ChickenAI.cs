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

    [Header("Loot Ayarlari")]
    [SerializeField] private GameObject _coin;
    [SerializeField] private int _maxCount;
    [SerializeField] private int _minCount;
    private int _dropCount;

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

    public void Die()
    {
        CoinDrop();
        Destroy(gameObject);
    }

    private void CoinDrop()
    {
        if (_coin == null) return;

        _dropCount = Random.Range(_minCount, _maxCount+1);

        for (int i = 0; i < _dropCount; i++)
        {
            GameObject _tempCoin = Instantiate(_coin, transform.position, Quaternion.identity);

            Rigidbody2D _rbCoin = _tempCoin.GetComponent<Rigidbody2D>();
            if (_rbCoin != null)
            {
                Vector2 _randomForce = new Vector2(Random.Range(-2f, 2f), Random.Range(2f, 5f));

                _rbCoin.AddForce(_randomForce, ForceMode2D.Impulse);
            }
        }
    }
}
