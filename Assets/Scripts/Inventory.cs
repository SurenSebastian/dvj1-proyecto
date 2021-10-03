using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory(GameObject go)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (isFull[i] == false)
            {
                GameObject itemButton = go.GetComponent<Pickup>().itemButton;
                // Add Item to Slot
                isFull[i] = true;
                Instantiate(itemButton, slots[i].transform, false);
                Destroy(go);
                break;
            }
        }
    }

    public void clearSlot(int pos)
    {
        isFull[pos] = false;
        slots[pos] = null;
    }
}

