using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AddObjectToInventory : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpItem(GameObject item)
    {
        if (item.GetComponent<ItemObject>().itemStat.type.ToString() is "firearms")
        {
            Debug.Log("is firearms");
        }
    }
}
