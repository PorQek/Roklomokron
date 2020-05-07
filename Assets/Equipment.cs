using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public  static SpriteRenderer _spriteRenderer;
    public List<EquipmentItem> equipmentItems = new List<EquipmentItem>();
    public static EquipmentItem currentlyEquippedItem;

    
    void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button
        if (false)
        {
            if (GUI.Button(new Rect(0, 0, 100, 50), "Delete"))
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetInt("HighScore", 0);
            }
        }
    }
    
    void OnEnable()
    {
        _spriteRenderer = FindObjectOfType<Player_Movement>().transform.GetComponent<SpriteRenderer>();
        foreach (EquipmentItem item in equipmentItems)
        {
            if (PlayerPrefs.HasKey(item.myName))
            {
                item.isOwned = true;
            }
        }

        string currentName = PlayerPrefs.GetString("CurrentlyEquippedItem");
        foreach (EquipmentItem item in equipmentItems)
        {
            if (currentName == item.myName)
                currentlyEquippedItem = item;
        }

        if (!currentlyEquippedItem)
        {
            currentlyEquippedItem = equipmentItems[0];
            PlayerPrefs.SetString("CurrentlyEquippedItem", currentlyEquippedItem.myName);
        }
        
        Equip(currentlyEquippedItem);
        print("CURRENT ITEM " + currentlyEquippedItem.myName);

        PlayerPrefs.Save();
    }

    public static void Buy(EquipmentItem item)
    {
        print($"Trying to buy | {HighScore.number}");
        if (item.price <= HighScore.number)
        {
            HighScore.number -= item.price;
            PlayerPrefs.SetInt("Score", ScoreScript.scoreValue);
            PlayerPrefs.SetInt(item.myName, 1);
            item.isOwned = true;
            print("Bought");
            Equip(item);
        }
        PlayerPrefs.Save();
    }

    public static void Equip(EquipmentItem item)
    {
        print("Trying to equip");
        if (currentlyEquippedItem)
        {
            print("Trying to unequip current item | " + currentlyEquippedItem.myName);
            currentlyEquippedItem.isEquipped = false;
            currentlyEquippedItem.UpdateUI();   
            print("Current item unequipped");
        }

        print("Trying to equip new item");
        currentlyEquippedItem = item;
        PlayerPrefs.SetString("CurrentlyEquippedItem", currentlyEquippedItem.myName);
        
        currentlyEquippedItem.isEquipped = true;
        currentlyEquippedItem.UpdateUI();
        _spriteRenderer.sprite = currentlyEquippedItem.sprite;
        print("Equipped new item");
        PlayerPrefs.Save();
    }
}
