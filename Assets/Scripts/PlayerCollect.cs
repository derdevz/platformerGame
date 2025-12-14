using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public AppleCollectable _acScript;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            _acScript._appleCount++;
            Destroy(other.gameObject);
        }
    }
}
