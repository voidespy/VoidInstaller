using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Items : MonoBehaviour
{
    public string itemName;
    public int itemID;
    public Sprite itemIcon;

    // Was going to implement something with this, but not with this project. The idea was to click boxes until they break and it would have an object inside. The item type would then be sold for Amagus on a type of "black market".
    public enum ItemType
    {
        None,
        Weapon,
        Food,
        Tradeable
    }

    public ItemType itemType;

    public void Action()
    {
        switch(itemType)
        {
            case ItemType.None:
                Debug.Log("Nothing.");
                break;

            case ItemType.Weapon:
                Debug.Log("Weapon selected");
                break;

            case ItemType.Food:
                Debug.Log("Food gathered");
                break;

            case ItemType.Tradeable:
                Debug.Log("Tradeable item");
                break;
        }
    }
}
