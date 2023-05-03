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
    public float rateOfFire; //100 = 10 ��������� � ������� (��74 ��� ��������)

    [Header("�������� � �������� (0 - 99)")]
    public int maximumAmmo; //� ��������/�������� � ��

    [Header("����������������")]
    public int maxLevelRateOfFire = 5; //��������� �� 5 � �����
    public int levelRateOfFire = 0;

    [Header("����")]
    public int maxLevelDamage = 5;
    public int levelDamage = 0;

    [Header("� ��������")]
    public int maxLevelAmmo = 5;
    public int levelAmmo = 0;


    [Header("������")]
    public GameObject lantern;
    public GameObject light;
    public GameObject aim;

    [Header("�����")]
    public TextMeshProUGUI allAmmoInGameUi;
    public TextMeshProUGUI currentAmmoInGameUi;

    [Header("��������")]
    public GameObject bullet;
    public int bulletAlive;
    public Transform spawnPoint;
    /*    public GameObject VFX;*/


    private MainGunsController mainGunsController;


/*    private void Start()
    {
        mainGunsController = GameObject.Find("MainGuns").GetComponent<MainGunsController>();
    }*/

    private void OnEnable()
    {
        UpdateInGameUi();
    }

    public void Shoot()
    {
        //������ ���������� ��� �������� ��� �� ��� ��� ���������������� <3
        if (currentAmmo > 0)
        {


            currentAmmo -= 1;
            UpdateInGameUi();
        } else
        {
            //���� ������ ��� ����������� (����� ������)
        }


    }

    public void UpdateInGameUi()
    {
        allAmmoInGameUi.text = allAmmo.ToString();
        currentAmmoInGameUi.text = currentAmmo.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.B)) //�������� �������
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
