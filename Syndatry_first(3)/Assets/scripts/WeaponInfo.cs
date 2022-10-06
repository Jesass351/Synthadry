using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponInfo : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private int index;
    private CustomCharacterController _playerManager;
    private void Start()
    {
        _playerManager = GameObject.Find("videoCharacter").GetComponent<CustomCharacterController>();

    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Text text = GameObject.Find("infoAboutSlots").GetComponent<Text>();
        Image img = GetComponent<Image>();
        Text who = GameObject.Find("infoAboutWeapons").GetComponent<Text>();
        
        if ((_playerManager.Inventory.Count == 3) && (who.text.Length > 1))
        {
            img.sprite = null;
            img.color = new Color(255, 255, 255, 0f);
            _playerManager.Inventory.RemoveAt(index);
            
        }


        
        if (img.sprite != null)
        {
            for (int i = 0; i < _playerManager.Inventory.Count; i++)
            {
                if (_playerManager.Inventory[i].weaponIcon == img.sprite)
                {
                    
                    text.text = "Урон = " + _playerManager.Inventory[i].damage + "\nКол-во ударов = " + _playerManager.Inventory[i].how_hits;
                }
            }
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
       
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Image img = GetComponent<Image>();
        if (img.sprite != null)
        {
            Text text = GameObject.Find("infoAboutSlots").GetComponent<Text>();
            text.text = null;
        }
    }
}
