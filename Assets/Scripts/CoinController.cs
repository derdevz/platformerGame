using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float _magnetRange;
    public float _flySpeed;

    private Rigidbody2D _rb;
    private Transform _playerTransform;
    private Collider2D _collider;
    private bool _isMagnetActive = false;

    void Start()
    {
        Rigidbody2D _rb = GetComponent<Rigidbody2D>();
        Collider2D _collider = GetComponent<Collider2D>();

        GameObject _playerobject = GameObject.FindGameObjectWithTag("Player");

        if (_playerobject != null)
        {
            _playerTransform = _playerobject.transform;
        }
    }

    void Update()
    {
        if (_playerTransform == null) return;

        float _distance = Vector2.Distance(transform.position, _playerTransform.position);

        if (_magnetRange > _distance)
        {
            ActivateMagnet();
        }
    }

    private void ActivateMagnet()
    {
        if (_rb != null)
        {
            _rb.gravityScale = 0;
            _rb.linearVelocity = Vector2.zero;
        }

        if (_collider != null)
        {
            _collider.isTrigger = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _flySpeed * Time.deltaTime);
    }
}
