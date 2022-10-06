using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBehaviour : MonoBehaviour
{
    private CustomCharacterController _playerManager;
    
    [SerializeField] public int damage;
    [SerializeField] public Sprite weaponIcon;
    [SerializeField] public int how_hits;
    //private List<WeaponBehaviour> cl = new List<WeaponBehaviour>();
    //private GridLayoutGroup _grid;
    private bool isfind = false;
    //Image img = _grid.GetComponentInChildren<Image>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("videoCharacter"))
        { 

            if (this.tag.Equals("debuf"))
            {
                for (int i = 0;i < _playerManager.InventoryForDeb.Count;i++)
                {
                    if (_playerManager.InventoryForDeb[i].weaponIcon == this.weaponIcon)
                    {
                        string debaf = "debaf_count" + i.ToString();
                        Text text = GameObject.Find(debaf).GetComponent<Text>();
                        int b = int.Parse(text.text);
                        text.text = (b + 1).ToString();
                        Destroy(this.gameObject);
                        isfind = true;
                        break;
                    }
                }
                if (!isfind)
                {
                    if (_playerManager.InventoryForDeb.Count < 2)
                    {
                        //string grenade = "grenade_count";
                        //Text text = GameObject.Find(grenade).GetComponent<Text>();
                        //int b = int.Parse(text.text);
                        //text.text = (b + 1).ToString();
                        _playerManager.InventoryForDeb.Add(this);
                        //_playerManager.Inventory.Add(this);
                        int a = _playerManager.InventoryForDeb.Count - 1;
                        string debaf = "debaf_count" + a.ToString();
                        Text text = GameObject.Find(debaf).GetComponent<Text>();
                        int b = int.Parse(text.text);
                        text.text = (b + 1).ToString();
                        Destroy(this.gameObject);
                    }
                }
            }
            else if (_playerManager.Inventory.Count < 3)
            {
                _playerManager.Inventory.Add(this);
                Destroy(this.gameObject);
            }
            else
            {
                Text text = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
                text.text = "Урон = " + damage.ToString() + "\n" + "Кол-во ударов = " + how_hits.ToString();
            }
          
            
            //Debug.Log("qqqqqq");
            
            //Debug.Log(_playerManager.Inventory[0]);
            //Debug.Log(_playerManager.Inventory.Count);
            Debug.Log(_playerManager.InventoryForDeb.Count);
            //img = _playerManager.Inventory[0].weaponIcon;
            for (int i=0;i<_playerManager.Inventory.Count;i++)
            {
                string str = "weaponIcon" + i.ToString();
                Image img = GameObject.Find(str).GetComponent<Image>();
                img.sprite = _playerManager.Inventory[i].weaponIcon;
                img.color = new Color(255, 255, 255, 1f);
                Debug.Log(_playerManager.Inventory[i].weaponIcon);
                Debug.Log(_playerManager.Inventory[i].damage);
                Debug.Log(_playerManager.Inventory[i]);
                Debug.Log(_playerManager.Inventory[0].damage);
            }
            for (int i = 0; i<_playerManager.InventoryForDeb.Count;i++)
            {
                Debug.Log(_playerManager.InventoryForDeb[i].weaponIcon);
                string str = "debaf" + i.ToString();
                Image img = GameObject.Find(str).GetComponent<Image>();
                img.sprite = _playerManager.InventoryForDeb[i].weaponIcon;
                img.color = new Color(255, 255, 255, 1f);
            }
        }

        

    }

    private void OnTriggerExit(Collider other)
    {
        Text text = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
        text.text = null;
    }


    private void Start()
    {
        _playerManager = GameObject.Find("videoCharacter").GetComponent<CustomCharacterController>();
        //_grid = _playerManager.canvas.GetComponentInChildren<GridLayoutGroup>();
        
    }
   
}
