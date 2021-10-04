using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StoneButton : MonoBehaviour
{
    public GameObject stone;
    public int xPos;
    public int yPos;

    public void Start()
    {
    }

    public void BringBackToTable()
    {
        var inventory = GameObject.FindGameObjectWithTag("Lobi").GetComponent<Inventory>();
        int slotPos = gameObject.transform.parent.GetComponent<Slot>().slotPosition - 1;
        Instantiate(stone, new Vector3(xPos, yPos), transform.rotation);
        inventory.clearSlot(slotPos);
        Destroy(gameObject);
    }
}
