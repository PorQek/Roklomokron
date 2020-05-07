using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItem : MonoBehaviour
{
    public string myName = "myName";
    public Sprite sprite;
    public bool isOwned = false;
    public bool isEquipped = false;
    public int price = 0;

    private Image _image;
    public TextMeshProUGUI _text;

    private void Awake()
    {
        _image = transform.GetChild(0).GetComponent<Image>();
        _image.sprite = sprite;

        _text = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
        UpdateUI();
    }

    public void UpdateUI()
    {
        if(!isOwned)
            _text.text = price.ToString();
        else
        {
            if (isEquipped)
                _text.text = "Equipped";
            else
                _text.text = "Owned";
        }
    }

    public void OnClick()
    {
        if (!isOwned)
            Equipment.Buy(this);
        else
            Equipment.Equip(this);
    }
}
