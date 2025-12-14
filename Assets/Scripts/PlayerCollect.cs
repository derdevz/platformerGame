using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public AppleCollectable _acScript;
    void OnTriggerEnter2D(Collider2D other)
    {
       CollectItem(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        CollectItem(other.gameObject);
    }

    private void CollectItem(GameObject item)
    {
         if (item.gameObject.CompareTag("Apple"))
        {
            _acScript._appleCount++;
            Destroy(item.gameObject);

            
        }
        if (item.gameObject.CompareTag("Coin"))
            {
                Debug.Log("collectitem calisiyor");
            _acScript._coinCount++;
                Destroy(item.gameObject);
            }
    }
}
