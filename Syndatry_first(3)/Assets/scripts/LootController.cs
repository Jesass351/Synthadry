using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    // public List<WeaponBehaviour> Weapon = new List<WeaponBehaviour>();
    public GameObject Katana;
    public GameObject Shotgun;
    public GameObject Grenade;
    public GameObject Chest;
    private GameObject Weapon;
    public int goodChance;
    public int badChance;
    private int flag;

    // Update is called once per frame
    void Start()
    {
        flag = 1;
    }


    public void ButtonClick()
    {
        float eventChance = Random.Range(0, 99);
        if (eventChance < goodChance)
        {
            eventChance = Random.Range(0, 99);
            if (eventChance < 40)
            {
                eventChance = Random.Range(0, 2);
                if (eventChance == 0)
                {
                    Weapon = Shotgun;
                }
                else
                {
                    Weapon = Katana;
                }
            }
            else
            {
                Weapon = Grenade;
            }

            if (flag == 1)
            {
                Weapon = Instantiate(Weapon, Chest.transform.position, Quaternion.identity);
                Weapon.transform.position += transform.forward * 2 + transform.up * 2 - transform.right * 3.5f;
                flag = 0;
            }
        }
        else if (eventChance < goodChance + badChance)
        {
            Debug.Log("Отрицательное событие");
        }
        else
        {
            Debug.Log("Ничего");
        }
        
    }
}
