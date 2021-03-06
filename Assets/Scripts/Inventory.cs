﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }
    
    public List<Item> items;
    public List<Item> startItems;

    public GameObject itemPrefab;
    public Transform itemPool;
    
    private void Start()
    {
        foreach (Item item in startItems)
        {
            AddItem(item, true);
        }
    }

    public void ReturnItem(GameObject returnedItem)
    {
        if (returnedItem.GetComponent<ItemClick>() != null)
        {
            Destroy(returnedItem.GetComponent<ItemClick>());
        }
        itemPool.GetComponent<ItemPool>().AddItem(returnedItem);
    }
    
    public void AddItem(Item item, bool startItem)
    {
        Debug.Log("Add item: " + item.name);
        AssignItem(item);

        GameObject itemObj = Instantiate(itemPrefab, itemPool);
        ItemDisplay display = itemObj.GetComponent<ItemDisplay>();
        if (display != null)
            display.Setup(item);
    }

    public void AssignItem(Item item)
    {
        items.Add(item);
    }
    
    public void RemoveItem(Item item)
    {
        Debug.Log("Remove item. " + item.name);
        items.Remove(item);
    }

    public bool HasItem(Item item)
    {
        return items.Contains(item);
    }

    public int GetAmount()
    {
        return items.Count;
    }
}
