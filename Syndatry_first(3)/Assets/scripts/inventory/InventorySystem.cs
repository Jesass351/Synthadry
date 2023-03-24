using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> mainGuns;
    [SerializeField] private List<GameObject> extraGuns;
    [SerializeField] private List<GameObject> debufs;

    [SerializeField] private List<GameObject> UiMainGuns;
    [SerializeField] private List<GameObject> UiExtraGuns;
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
                UpdateInventoryUI();
            } else
            {
                Debug.Log("---------");
                Debug.Log("Основной инвентарь уже полный");
            }

        } else if (item.GetComponent<ItemObject>().itemStat.type.ToString() is "extra")
        {
            if (extraGuns.Count < 9)
            {
                Debug.Log("------------");
                Debug.Log("extraGuns:");
                extraGuns.Add(item);
                for (int i = 0; i < extraGuns.Count; i++)
                {
                    Debug.Log(extraGuns[i]);
                }
                UpdateInventoryUI();
            }
            else
            {
                Debug.Log("---------");
                Debug.Log("Дополнительный (гранатный) инвентарь уже полный");
            }

        }

    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < mainGuns.Count; i++)
        {
            UiMainGuns[i].SetActive(true);
            UiMainGuns[i].GetComponent<Image>().sprite = mainGuns[i].GetComponent<ItemObject>().itemStat.iconDisable1K;
        }
        if (extraGuns.Count > 0)
        {
            UiExtraGuns[0].SetActive(true);
            UiExtraGuns[1].SetActive(true);
            UiExtraGuns[0].GetComponent<Image>().sprite = extraGuns[0].GetComponent<ItemObject>().itemStat.iconActive1K;
            UiExtraGuns[1].GetComponent<Text>().text = extraGuns.Count.ToString();
        }
    }
}
