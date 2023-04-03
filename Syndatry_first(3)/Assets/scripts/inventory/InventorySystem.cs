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

    public List<GameObject> mainGuns;
    public List<GameObject> extraGuns;

    [SerializeField] private List<GameObject> UiMainGuns;
/*   0 - иконка
     1 - сейчас партронов
     2 - всего патронов*/

    [SerializeField] private List<GameObject> UiExtraGuns;
/*   0 - иконка
     1 - количество*/

    [SerializeField] private int activeMainGun = 0;


    [SerializeField] private List<GameObject> UiBuffs;

    public List<GameObject> hpBuffs;
    public List<GameObject> armorBuffs;
    public List<GameObject> speedBuffs;

    [SerializeField] private int activeBuff = 0;

    private ItemObject itemObject;

    private HPAndArmor hpAndArmor;

    // Start is called before the first frame update
    void Start()
    {
        hpAndArmor = player.GetComponent<HPAndArmor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //СМЕНА АКТИВНОГО БАФФА
        {
            activeBuff = (activeBuff + 1) % 3;
            UpdateInventoryUIBuffs();
        }

        if (Input.GetKeyDown(KeyCode.X)) //СМЕНА АКТИВНОГО БАФФА
        {
            UseBuff(activeBuff);
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
        if (Input.GetKeyDown(KeyCode.G)) //ВЫКИНУТЬ ПРЕДМЕТ
        {
            DiscardTheItem(activeMainGun);
            UpdateInventoryUIItems(activeMainGun);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) //КОЛЁСИКОМ ВПЕРЁД
        {
            activeMainGun = (activeMainGun + 1) % 3;
            UpdateInventoryUIItems(activeMainGun);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) //КОЛЁСИКОМ НАЗАД
        {
            activeMainGun = (3 + activeMainGun - 1) % 3;
            UpdateInventoryUIItems(activeMainGun);
        }
    }


    //-------------ПОДОБРАТЬ ИЛИ ВЫБРОСИТЬ ПРЕДМЕТ (ОРУЖИЕ И ГРАНАТЫ)---------------
    public void DiscardTheItem(int active)
    {
        mainGuns[active].transform.position = player.position;
        mainGuns[active].SetActive(true);
        mainGuns.Remove(mainGuns[active]);
        if (mainGuns[active - 1] != null)
        {
            activeMainGun = active - 1;
        } else if (mainGuns[active + 1] != null)
        {
            activeMainGun = active + 1;
        } else
        {
            activeMainGun = 0;
        }
        UpdateInventoryUIItems(activeMainGun);
    }

    public void SetActiveMainGun(int active)
    {
        activeMainGun = active;
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
                Debug.Log("Основной инвентарь уже полный");
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
                Debug.Log("Дополнительный (гранатный) инвентарь уже полный");
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
            UiMainGuns[1].SetActive(true);
            UiMainGuns[2].SetActive(true);
            itemObject = mainGuns[active].GetComponent<ItemObject>();
            UiMainGuns[0].GetComponent<Image>().sprite = mainGuns[active].GetComponent<ItemObject>().itemStat.iconActive1K;
            if (itemObject.itemStat.type.ToString() is "coldWeapons")
            {
                UiMainGuns[1].GetComponent<TextMeshProUGUI>().text = "∞";
                UiMainGuns[2].GetComponent<TextMeshProUGUI>().text = "/ ∞";
            } else
            {
                UiMainGuns[1].GetComponent<TextMeshProUGUI>().text = mainGuns[active].GetComponent<ItemObject>().currentAmmo.ToString();
                UiMainGuns[2].GetComponent<TextMeshProUGUI>().text = "/ " + mainGuns[active].GetComponent<ItemObject>().allAmmo.ToString();
            }
        } else
        {
            UiMainGuns[0].SetActive(false);
            UiMainGuns[1].SetActive(false);
            UiMainGuns[2].SetActive(false);
        }
        if (extraGuns.Count > 0)
        {
            UiExtraGuns[0].SetActive(true);

            UiExtraGuns[0].GetComponent<Image>().sprite = extraGuns[0].GetComponent<ItemObject>().itemStat.iconActive1K;

            UiExtraGuns[1].GetComponent<TextMeshProUGUI>().text = extraGuns.Count.ToString();
            

        } else
        {
            UiExtraGuns[0].SetActive(false);
        }
    }


    //-------------ПОДОБРАТЬ БАФФЫ (ХП, СИЛА, СКОРОСТЬ)---------------
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
                Debug.Log("ХП инвентарь уже полный");
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
                Debug.Log("Speed инвентарь уже полный");
            }
        }
        else if (item.GetComponent<BuffObject>().BuffStat.type.ToString() is "armor")
        {
            if (armorBuffs.Count < 9)
            {
                Debug.Log("------------");
                Debug.Log("armorBuffs:");
                armorBuffs.Add(item);
                for (int i = 0; i < armorBuffs.Count; i++)
                {
                    Debug.Log(armorBuffs[i]);
                }
                UpdateInventoryUIBuffs();
            }
            else
            {
                Debug.Log("---------");
                Debug.Log("armor инвентарь уже полный");
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

        } else if (activeBuff == 1 && armorBuffs.Count != 0)
        {
            UiBuffs[0].GetComponent<Image>().sprite = armorBuffs[0].GetComponent<BuffObject>().BuffStat.iconActive1K;
            UiBuffs[1].GetComponent<TextMeshProUGUI>().text = armorBuffs.Count.ToString();
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

    public void UseBuff(int active)
    {
        if (activeBuff == 0 && hpBuffs.Count != 0)
        {
            hpAndArmor.TakeHeal(hpBuffs[0].GetComponent<BuffObject>().BuffStat.increase, hpBuffs[0].GetComponent<BuffObject>().BuffStat.type.ToString());
            hpBuffs.RemoveAt(0);
            UpdateInventoryUIBuffs();
            return;

        }
        else if (activeBuff == 1 && armorBuffs.Count != 0)
        {
            hpAndArmor.TakeHeal(armorBuffs[0].GetComponent<BuffObject>().BuffStat.increase, armorBuffs[0].GetComponent<BuffObject>().BuffStat.type.ToString());
            armorBuffs.RemoveAt(0);
            UpdateInventoryUIBuffs();
            return;

        }
        else if (activeBuff == 2 && speedBuffs.Count != 0)
        {
            UiBuffs[0].GetComponent<Image>().sprite = speedBuffs[0].GetComponent<BuffObject>().BuffStat.iconActive1K;
            UiBuffs[1].GetComponent<TextMeshProUGUI>().text = speedBuffs.Count.ToString();
            return;
        }
        else
        {
            UiBuffs[0].SetActive(false);
            UiBuffs[1].SetActive(false);
        }
    }
}
