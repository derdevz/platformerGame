using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AppleCollectable : MonoBehaviour
{   
    [Header("Apple Settings")]
    public int _appleCount;
    public TextMeshProUGUI _appleText;
    public GameObject Lock;
    public GameObject Lock1;
    private bool _doorBool;

    [Header("Coin Settings")]
    public int _coinCount;
    public TextMeshProUGUI _coinText;

    [Header("FireBall Setting")]
    public int _fireballCount;
    public TextMeshProUGUI _fireballText;

    void Update()
    {
        _appleText.text = "x" + _appleCount.ToString();

        if (_appleCount == 5)
        {
            Destroy(Lock);
            Destroy(Lock1);
        }

        _coinText.text = "x" + _coinCount.ToString();

        _fireballText.text = "x" + _fireballCount.ToString();

        if (Input.GetKeyDown(KeyCode.Y))
        {
            _coinCount++;
        }
    }
}
