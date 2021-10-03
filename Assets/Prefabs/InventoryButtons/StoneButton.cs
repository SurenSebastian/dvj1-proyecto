using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneButton : MonoBehaviour
{
    public GameObject stone;

    public void Start()
    {
    }

    public void BringBackToTable()
    {
        print("SE LO DOY AL LOBO Y LO EXPLOTO");
        Instantiate(stone, new Vector3(1, 1), transform.rotation);
        Destroy(gameObject);
    }
}
