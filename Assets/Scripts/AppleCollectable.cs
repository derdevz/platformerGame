using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppleCollectable : MonoBehaviour
{
    public int _appleCount;
    public TextMeshProUGUI _appleText;
    public GameObject Lock;
    public GameObject Lock1;
    private bool _doorBool;

    void Update()
    {
        _appleText.text = "x" + _appleCount.ToString();

        if (_appleCount == 5)
        {
            Destroy(Lock);
            Destroy(Lock1);
        }
    }
}
