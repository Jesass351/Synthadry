using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    // public List<WeaponBehaviour> Weapon = new List<WeaponBehaviour>();
    public GameObject Weapon;
    public GameObject Chest;
    private GameObject newWeapon;
    private int flag;

    // Update is called once per frame
    void Start()
    {
        flag = 1;
    }

    public void ButtonClick()
    {
        if (flag == 1)
        {
            newWeapon = Instantiate(Weapon, Chest.transform.position, Quaternion.identity);
            newWeapon.transform.position += transform.forward * 2 + transform.up * 2 - transform.right * 3.5f;
            flag = 0;
        }
    }
}
