using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> mainGuns;
    [SerializeField] private List<GameObject> extraGuns;
    [SerializeField] private List<GameObject> dedufs;
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
            if (mainGuns.Count < 3)
            {
                Debug.Log("------------");
                Debug.Log("mainGuns:");
                mainGuns.Add(item);
                for (int i = 0; i < mainGuns.Count; i++)
                {
                    Debug.Log(mainGuns[i]);
                }
            } else
            {
                Debug.Log("---------");
                Debug.Log("Основной инвентарь уже полный");
            }

        }
    }
}
