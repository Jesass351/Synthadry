using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private List<GameObject> mainGuns;
    [SerializeField] private List<GameObject> extraGuns;

    [SerializeField] private List<GameObject> UiMainGuns;
    [SerializeField] private List<GameObject> UiExtraGuns;

    [SerializeField] private int activeMainGun = 0;


    [SerializeField] private List<GameObject> UiBuffs;

    [SerializeField] private List<GameObject> hpBuffs;
    [SerializeField] private List<GameObject> powerBuffs;
    [SerializeField] private List<GameObject> speedBuffs;

    [SerializeField] private int activeBuff = 0;

    private List<int> notEmpty;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //—Ã≈Õ¿ ¿ “»¬ÕŒ√Œ ¡¿‘‘¿
        {
            activeBuff = (activeBuff + 1) % 3;
            UpdateInventoryUIBuffs();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeMainGun = 0;
            UpdateInventoryUIItems(activeMainGun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeMainGun = 1;
            UpdateInventoryUIItems(activeMainGun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeMainGun = 2;
            UpdateInventoryUIItems(activeMainGun);
        }
        if (Input.GetKeyDown(KeyCode.G)) //¬€ »Õ”“‹ œ–≈ƒÃ≈“
        {
            DiscardTheItem(activeMainGun);
            UpdateInventoryUIItems(activeMainGun);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // ŒÀ®—» ŒÃ ¬œ≈–®ƒ
        {
            activeMainGun = (activeMainGun + 1) % 3;
            UpdateInventoryUIItems(activeMainGun);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // ŒÀ®—» ŒÃ Õ¿«¿ƒ
        {
            activeMainGun = (3 + activeMainGun - 1) % 3;
            UpdateInventoryUIItems(activeMainGun);
        }
    }


    //-------------œŒƒŒ¡–¿“‹ »À» ¬€¡–Œ—»“‹ œ–≈ƒÃ≈“ (Œ–”∆»≈ » √–¿Õ¿“€)---------------
    public void DiscardTheItem(int active)
    {
        mainGuns[active].transform.position = player.position;
        mainGuns[active].SetActive(true);
        mainGuns.Remove(mainGuns[active]);
    }
    public void PickUpItem(GameObject item)
    {
        if (item.GetComponent<ItemObject>().itemStat.type.ToString() is "firearms" || item.GetComponent<ItemObject>().itemStat.type.ToString() is "coldWeapons")
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
                UpdateInventoryUIItems(activeMainGun);
            } else
            {
                Debug.Log("---------");
                Debug.Log("ŒÒÌÓ‚ÌÓÈ ËÌ‚ÂÌÚ‡¸ ÛÊÂ ÔÓÎÌ˚È");
            }

        }
        else if (item.GetComponent<ItemObject>().itemStat.type.ToString() is "extra")
        {
            if (extraGuns.Count < 9)
            {
                Debug.Log("------------");
                Debug.Log("extraGuns:");
                extraGuns.Add(item);

                UpdateInventoryUIItems(activeMainGun);
            }
            else
            {
                Debug.Log("---------");
                Debug.Log("ƒÓÔÓÎÌËÚÂÎ¸Ì˚È („‡Ì‡ÚÌ˚È) ËÌ‚ÂÌÚ‡¸ ÛÊÂ ÔÓÎÌ˚È");
            }

        }

    }

    public void UpdateInventoryUIItems(int active = 0)
    {
        /* for (int i = 0; i < UiMainGuns.Count; i++)
         {
             UiMainGuns[i].GetComponent<Image>().sprite = null;
             UiMainGuns[i].SetActive(false);
         }
         for (int i = 0; i < mainGuns.Count; i++)
         {
             UiMainGuns[i].SetActive(true);
             UiMainGuns[i].GetComponent<Image>().sprite = mainGuns[i].GetComponent<ItemObject>().itemStat.iconDisable1K;
         }
         UiMainGuns[active].GetComponent<Image>().sprite = mainGuns[active].GetComponent<ItemObject>().itemStat.iconActive1K;*/
        if (mainGuns.Count > 0)
        {
            UiMainGuns[0].SetActive(true);
            UiMainGuns[0].GetComponent<Image>().sprite = mainGuns[active].GetComponent<ItemObject>().itemStat.iconActive1K;
        }
        if (extraGuns.Count > 0)
        {
            UiExtraGuns[0].SetActive(true);
            UiExtraGuns[1].SetActive(true);
            UiExtraGuns[0].GetComponent<Image>().sprite = extraGuns[0].GetComponent<ItemObject>().itemStat.iconActive1K;
            UiExtraGuns[1].GetComponent<TextMeshProUGUI>().text = extraGuns.Count.ToString();
        }
    }


    //-------------œŒƒŒ¡–¿“‹ ¡¿‘‘€ (’œ, —»À¿, — Œ–Œ—“‹)---------------
    public void PickUpBuff(GameObject item)
    {
        if (item.GetComponent<BuffObject>().BuffStat.type.ToString() is "hp")
        {
            if (hpBuffs.Count < 9)
            {
                Debug.Log("------------");
                Debug.Log("hpBuffs:");
                hpBuffs.Add(item);
                for (int i = 0; i < hpBuffs.Count; i++)
                {
                    Debug.Log(hpBuffs[i]);
                }
                UpdateInventoryUIBuffs();
            }
            else
            {
                Debug.Log("---------");
                Debug.Log("’œ ËÌ‚ÂÌÚ‡¸ ÛÊÂ ÔÓÎÌ˚È");
            }
        }
        else if (item.GetComponent<BuffObject>().BuffStat.type.ToString() is "speed")
        {
            if (speedBuffs.Count < 9)
            {
                Debug.Log("------------");
                Debug.Log("speedBuffs:");
                speedBuffs.Add(item);
                for (int i = 0; i < speedBuffs.Count; i++)
                {
                    Debug.Log(speedBuffs[i]);
                }
                UpdateInventoryUIBuffs();
            }
            else
            {
                Debug.Log("---------");
                Debug.Log("Speed ËÌ‚ÂÌÚ‡¸ ÛÊÂ ÔÓÎÌ˚È");
            }
        }
        else if (item.GetComponent<BuffObject>().BuffStat.type.ToString() is "power")
        {
            if (powerBuffs.Count < 9)
            {
                Debug.Log("------------");
                Debug.Log("powerBuffs:");
                powerBuffs.Add(item);
                for (int i = 0; i < powerBuffs.Count; i++)
                {
                    Debug.Log(powerBuffs[i]);
                }
                UpdateInventoryUIBuffs();
            }
            else
            {
                Debug.Log("---------");
                Debug.Log("Power ËÌ‚ÂÌÚ‡¸ ÛÊÂ ÔÓÎÌ˚È");
            }
        }
    }

    public void UpdateInventoryUIBuffs()
    {
        UiBuffs[0].SetActive(true);
        UiBuffs[1].SetActive(true);
        if (activeBuff == 0 && hpBuffs.Count != 0)
        {
            UiBuffs[0].GetComponent<Image>().sprite = hpBuffs[0].GetComponent<BuffObject>().BuffStat.iconActive1K;
            UiBuffs[1].GetComponent<TextMeshProUGUI>().text = hpBuffs.Count.ToString();
            return;

        } else if (activeBuff == 1 && powerBuffs.Count != 0)
        {
            UiBuffs[0].GetComponent<Image>().sprite = powerBuffs[0].GetComponent<BuffObject>().BuffStat.iconActive1K;
            UiBuffs[1].GetComponent<TextMeshProUGUI>().text = powerBuffs.Count.ToString();
            return;

        } else if (activeBuff == 2 && speedBuffs.Count != 0)
        {
            UiBuffs[0].GetComponent<Image>().sprite = speedBuffs[0].GetComponent<BuffObject>().BuffStat.iconActive1K;
            UiBuffs[1].GetComponent<TextMeshProUGUI>().text = speedBuffs.Count.ToString();
            return;
        } else
        {
            UiBuffs[0].SetActive(false);
            UiBuffs[1].SetActive(false);
        }

    }
}
