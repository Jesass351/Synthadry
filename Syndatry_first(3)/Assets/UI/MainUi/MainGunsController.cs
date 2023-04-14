using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class MainGunsController : MonoBehaviour
{
    [SerializeField] private InventorySystem PlayerInventory;

    [SerializeField] private GameObject UiMainGuns;
    /*   0 - иконка
         1 - сейчас партронов
         2 - всего патронов*/

    public void UpdateMainGunsUi(int MainGunNum)
    {
        if (MainGunNum < PlayerInventory.mainGuns.Count)
        {
            UiMainGuns.transform.GetChild(1).gameObject.SetActive(true);
            UiMainGuns.transform.GetChild(1).GetComponent<Image>().sprite = PlayerInventory.mainGuns[MainGunNum].GetComponent<ItemObject>().itemStat.iconActive1K;

            if (PlayerInventory.mainGuns[MainGunNum].GetComponent<ItemObject>().itemStat.typeOfMissile.ToString() is "hand")
            {
                UiMainGuns.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "/∞";
                UiMainGuns.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "∞";
            } else
            {
                UiMainGuns.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "/" + PlayerInventory.mainGuns[MainGunNum].GetComponent<ItemObject>().allAmmo.ToString();
                UiMainGuns.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = PlayerInventory.mainGuns[MainGunNum].GetComponent<ItemObject>().currentAmmo.ToString();
            }
        } else
        {
            UiMainGuns.transform.GetChild(1).gameObject.SetActive(false);
            UiMainGuns.transform.GetChild(1).GetComponent<Image>().sprite = null;
            UiMainGuns.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
            UiMainGuns.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "";
        }


       /* for (var i = 0; i < UiMainGuns.Count; i++)
        {
            if (i < PlayerInventory.mainGuns.Count)
            {
                UiMainGuns[i].transform.GetChild(1).GetComponent<Image>().sprite = PlayerInventory.mainGuns[i].GetComponent<ItemObject>().itemStat.iconActive1K;
                UiMainGuns[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = PlayerInventory.mainGuns[i].GetComponent<ItemObject>().allAmmo.ToString();
                UiMainGuns[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = PlayerInventory.mainGuns[i].GetComponent<ItemObject>().currentAmmo.ToString();
            } else
            {
                UiMainGuns[i].SetActive(false);
            }
        }
        UiMainGuns[MainGunNum].SetActive(true);*/
    }

   

}
