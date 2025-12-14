using UnityEngine;

public class Item
{
   public enum ItemType
    {
        Can,
        DoubleJump,
        FireBall
    }

    public static int GetCost(ItemType _itemType)
    {
        switch (_itemType)
        {
            case ItemType.Can: return 1;
            case ItemType.DoubleJump: return 2;
            case ItemType.FireBall: return 1;
            default: return 0;
        }
    }

    
}
