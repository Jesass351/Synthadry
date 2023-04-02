using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MouseOverPart : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> UiElems;
    /*   0 - иконка
         1 - сейчас партронов
         2 - всего патронов
         3 - номер клавиши
    */
    [SerializeField] private int indexOfUi;

    private InventorySystem inventorySystem;

    void ClearBuffs()
    {
        for (var i = 0; i < UiElems.Count; i++)
        {
            UiElems[i].transform.GetChild(0).gameObject.SetActive(false);
            UiElems[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    void OnDisable()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
        UiElems[0].GetComponent<Image>().sprite = null;
        UiElems[0].SetActive(false);
        UiElems[3].SetActive(false);
        UiElems[1].GetComponent<TextMeshProUGUI>().text = "";
        UiElems[2].GetComponent<TextMeshProUGUI>().text = "";
    }

    void OnEnable()
    {
        inventorySystem = player.GetComponent<InventorySystem>();
        
        if (indexOfUi < 10)
        {
            if (inventorySystem.mainGuns[indexOfUi] != null)
            {
                UiElems[0].SetActive(true);
                UiElems[3].SetActive(true);
                UiElems[0].GetComponent<Image>().sprite = inventorySystem.mainGuns[indexOfUi].GetComponent<ItemObject>().itemStat.iconActive1K;
                if (inventorySystem.mainGuns[indexOfUi].GetComponent<ItemObject>().itemStat.type.ToString() is "coldWeapons")
                {
                    UiElems[1].GetComponent<TextMeshProUGUI>().text = "∞";
                    UiElems[2].GetComponent<TextMeshProUGUI>().text = "/ ∞";
                } else
                {
                    UiElems[1].GetComponent<TextMeshProUGUI>().text = inventorySystem.mainGuns[indexOfUi].GetComponent<ItemObject>().currentAmmo.ToString();
                    UiElems[2].GetComponent<TextMeshProUGUI>().text = "/ " + inventorySystem.mainGuns[indexOfUi].GetComponent<ItemObject>().allAmmo.ToString();
                }
        }

        } else if (indexOfUi >= 10 && indexOfUi < 20) {
            if (inventorySystem.extraGuns.Count > 0)
            {
                UiElems[0].SetActive(true);
                UiElems[0].GetComponent<Image>().sprite = inventorySystem.extraGuns[0].GetComponent<ItemObject>().itemStat.iconActive1K;
                UiElems[1].GetComponent<TextMeshProUGUI>().text = inventorySystem.extraGuns.Count.ToString();
            }
        } else if (indexOfUi >= 20)
        {
            if (inventorySystem.hpBuffs.Count > 0)
            {
                UiElems[0].transform.GetChild(0).gameObject.SetActive(true);
                UiElems[0].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = inventorySystem.hpBuffs.Count.ToString();
            }
            if (inventorySystem.speedBuffs.Count > 0)
            {
                UiElems[1].transform.GetChild(0).gameObject.SetActive(true);
                UiElems[1].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = inventorySystem.speedBuffs.Count.ToString();
            }
            if (inventorySystem.powerBuffs.Count > 0)
            {
                UiElems[2].transform.GetChild(0).gameObject.SetActive(true);
                UiElems[2].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = inventorySystem.powerBuffs.Count.ToString();
            }

        }
            
    }
        

    public void ShowActivePart(int number)
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(gameObject);
        ShowActivePart(indexOfUi);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
    }
}