using UnityEngine;

public class UI_Shop : MonoBehaviour
{
    public GameObject _buttonE;
   private Transform _container;
   private Transform _shopItemTemplate;

    private void Awake()
    {
        _container = transform.Find("Container");
        _shopItemTemplate = transform.Find("ShopItemTemplate");
        _shopItemTemplate.gameObject.SetActive(false);
        
        _buttonE.SetActive(false);
    }
}
