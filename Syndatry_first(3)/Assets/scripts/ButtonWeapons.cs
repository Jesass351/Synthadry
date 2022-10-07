using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonWeapons : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool a = false;
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        a = true;
    }

    // Start is called before the first frame update
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        a = false;
        button.interactable=false;
    }
}
