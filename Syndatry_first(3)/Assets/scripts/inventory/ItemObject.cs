using TMPro;
using UnityEngine;
using System;

public class ItemObject : MonoBehaviour
{
    public Items itemStat;
    public int amount;
    public int currentAmmo = 5;
    public int allAmmo = 20;

    [Header("0 - 100")]
    public float damage; 
    public float rateOfFire; 

    [Header("Ã¿ —»Ã”Ã ¬ Ã¿√¿«»Õ≈ (0 - 99)")]
    public int maximumAmmo; //‚ ·‡‡·‡ÌÂ/Ï‡„‡ÁËÌÂ ˇ ıÁ

    [Header("— Œ–Œ—“–≈À‹ÕŒ—“‹")]
    public int maxLevelRateOfFire = 5;
    public int levelRateOfFire = 0;

    [Header("”–ŒÕ")]
    public int maxLevelDamage = 5;
    public int levelDamage = 0;

    [Header("¬ Ã¿√¿«»Õ≈")]
    public int maxLevelAmmo = 5;
    public int levelAmmo = 0;


    [Header("Õ¿¬≈—€")]
    public GameObject lantern;
    public GameObject light;
    public GameObject aim;

    [Header("› –¿Õ")]
    public TextMeshProUGUI allAmmoInGameUi;
    public TextMeshProUGUI currentAmmoInGameUi;

    private void OnEnable()
    {
        UpdateInGameUi();
    }

    public void UpdateInGameUi()
    {
        allAmmoInGameUi.text = allAmmo.ToString();
        currentAmmoInGameUi.text = currentAmmo.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) //¬ Àﬁ◊»“‹ ‘ŒÕ¿–» 
        {
            if (gameObject.activeInHierarchy)
            {
                if (lantern.activeInHierarchy)
                {
                    if (!light.activeInHierarchy)
                    {
                        light.SetActive(true);
                    }
                    else
                    {
                        light.SetActive(false);
                    }
                }
            }
        }
    }

    public void AddLantern()
    {
        lantern.SetActive(true);
    }

    public void RemoveLantern()
    {
        lantern.SetActive(false);
    }

    public void AddAim()
    {
        aim.SetActive(true);
    }

    public void RemoveAim()
    {
        aim.SetActive(false);
    }




    public void IncreaseRateOfFire(float num)
    {
        rateOfFire = Math.Min(100, rateOfFire + num);
    }

    public void DecreaseRateOfFire(float num)
    {
        rateOfFire = Math.Max(0, rateOfFire - num);
    }

    public void IncreaseDamage(float num)
    {
        damage = Math.Min(100, damage + num);
    }

    public void DecreaseRateDamage(float num)
    {
        damage = Math.Max(0, damage - num);
    }

    public void IncreaseMaxAmmo(int num)
    {
        maximumAmmo = Math.Min(1, maximumAmmo + num);
    }

    public void DecreaseMaxAmmo(int num)
    {
        maximumAmmo = Math.Max(0, maximumAmmo - num);
    }

    public void IncreaseAllAmmo(int num)
    {
        allAmmo = Math.Min(1000, allAmmo + num);
    }

    public void DecreaseAllAmmo(int num)
    {
        allAmmo = Math.Max(0, allAmmo - num);

    }

    public void IncreaseCurrentAmmo(int num)
    {
        currentAmmo = Math.Min(maximumAmmo, currentAmmo + num);
    }

    public void DecreaseCurrentAmmo(int num)
    {
        currentAmmo = Math.Max(0, currentAmmo - num);

    }
}
