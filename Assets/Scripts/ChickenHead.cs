using System.Numerics;
using UnityEngine;

public class ChickenHead : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D _rbPlayer = other.GetComponent<Rigidbody2D>();

            if (_rbPlayer != null)
            {
                _rbPlayer.linearVelocity = new UnityEngine.Vector2(_rbPlayer.linearVelocity.x, 8f);
            }

            ChickenAI _mainScript = GetComponentInParent<ChickenAI>();

            if (_mainScript != null)
            {
                _mainScript.Die();
            }
        }
    }
}
