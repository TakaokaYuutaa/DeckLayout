using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardProgram : MonoBehaviour,IDragHandler, IDropHandler
{
    public SlotData _slotData;
    [SerializeField] Text _text;
    public int cost, hitPoint;
    int costLeast = 1, costHighest = 7;
    int hitPointLeast = 10, hitPointHighest = 255;
    string slotName;
    Vector3 setPosition;
    void Start()
    {
        setPosition = this.transform.position;
        cost = SetCost();
        hitPoint = SetHitPoint();
        SetParameter(cost, hitPoint);
    }
    public int SetCost()
    {
        int cost = Random.Range(costLeast, costHighest + 1);
        return cost;
    }
    public int SetHitPoint()
    {
        int HP = Random.Range(hitPointLeast, hitPointHighest + 1);
        return HP;
    }
    public void SetParameter(int cost, int hitpoint)
    {
        _text.text = "�R�X�g:" + cost + "\n" +
                     "HP:" + hitpoint;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
    public void OnDrop(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (var r in results)
        {
            if (r.gameObject.tag=="Set")
            {
                _slotData = r.gameObject.GetComponent<SlotData>();
                if (_slotData.hp == 0 && _slotData.cost == 0)
                {
                    _slotData.hp = hitPoint; _slotData.cost = cost;
                    transform.position = r.gameObject.transform.position;
                }
                else
                {
                    _slotData = null;
                }
            }
            else
            {
                if (_slotData != null)
                {
                    _slotData.hp = 0; _slotData.cost = 0;
                    _slotData=null;
                }
                this.transform.position = setPosition;
            }
        }
    }
}
