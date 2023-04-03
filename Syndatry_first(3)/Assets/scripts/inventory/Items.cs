using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create new Item")]
[System.Serializable]

public class Items : ScriptableObject
{
    public int id;

    public string itemName;

    public string description;

    public enum Types
    {
        firearms,
        coldWeapons,
        extra
    };

    public enum Rarity
    {
        standart,
        rare,
        epic
    };

    public enum TypeOfMissile
    {
        bullet,
        electro,
        hand
    };

    public GameObject prefab;
    public Sprite iconActive1K;
    public Sprite iconDisable1K;

    public Types type;
    public Rarity rarity;
    public TypeOfMissile typeOfMissile;
    public float damage; //(0-100)
    public float rateOfFire; //(0-100)
    public int maximumAmmo; //� ��������/�������� � ��

}
