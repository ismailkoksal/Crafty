using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    public Item item;
    public Image icon;
    public TextMeshProUGUI nameText;

    public void Setup(Item item)
    {
        this.item = item;
        icon.sprite = this.item.icon;
        nameText.text = this.item.name;
    }
}
