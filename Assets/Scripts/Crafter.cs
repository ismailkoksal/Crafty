using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter : MonoBehaviour
{
    public static Crafter instance;

    private void Awake()
    {
        instance = this;
    }

    public Item slot01;
    public Item slot02;

    public Recipe[] recipes;

    public Transform resultsParent;
    [SerializeField]
    private GameObject itemPrefab;
    public GameObject ghostItemPrefab;

    private void Start()
    {
        recipes = Resources.LoadAll<Recipe>("Recipes");
    }

    public void AddItem(Item item, int slot)
    {
        Debug.Log("Add item to Crafter: " + item.name);

        if (slot == 1)
        {
            slot01 = item;
        }
        else if (slot == 2)
        {
            slot02 = item;
        }

        UpdateResult();
    }

    public void RemoveItem(int slot)
    {
        Debug.Log("Remove from slot " + slot);

        if (slot == 1)
        {
            slot01 = null;
        }
        else if (slot == 2)
        {
            slot02 = null;
        }

        UpdateResult();
    }

    void UpdateResult()
    {
        ClearPreviousResult();

        Item result = GetResult();
        if (result != null)
        {
            if (!Inventory.instance.HasItem(result))
            {
                CreateItem(result);
            }
            else
            {
                CreateGhostItem(result);
            }
        }
    }

    void CreateItem(Item item)
    {
        GameObject itemObj = Instantiate(itemPrefab, resultsParent);
        ItemDisplay display = itemObj.GetComponent<ItemDisplay>();
        itemObj.AddComponent<ItemClick>();

        if (display != null)
            display.Setup(item);
    }

    void CreateGhostItem(Item item)
    {
        GameObject itemObj = Instantiate(ghostItemPrefab, resultsParent);
        ItemDisplay display = itemObj.GetComponent<ItemDisplay>();

        if (display != null)
            display.Setup(item);
    }

    void ClearPreviousResult()
    {
        foreach (Transform child in resultsParent)
        {
            Destroy(child.gameObject);
        }
    }

    Item GetResult()
    {
        if (slot01 == null || slot02 == null)
        {
            Debug.Log("NO RESULTS");
            return null;
        }
        else
        {
            foreach (Recipe recipe in recipes)
            {
                if ((recipe.input01 == slot01 && recipe.input02 == slot02) ||
                    (recipe.input01 == slot02 && recipe.input02 == slot01))
                {
                    Debug.Log("Crafted : " + recipe.result);
                    return recipe.result;
                }
            }
        }
        return null;
    }
}
