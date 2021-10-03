using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryState : MonoBehaviour
{
    private static InventoryState instance;

    // Start is called before the first frame update
    void Start()
    {
        initSingletionInstance();
    }
    void initSingletionInstance()
    {
        if (instance == null) // This is first object, set the static reference
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
