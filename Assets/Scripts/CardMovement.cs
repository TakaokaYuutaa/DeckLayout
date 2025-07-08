using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardMovement: MonoBehaviour,IDragHandler, IDropHandler
{
    public SlotData _slotData;
    [SerializeField] Text _text;
    [SerializeField] public GameObject _select;
    [SerializeField] public GameObject _notSelect;
    [SerializeField] public DeckSeting _deckSeting;
    public int cost, hitPoint,cardNo;
    int costLeast = 1, costHighest = 5;
    int hitPointLeast = 10, hitPointHighest = 255;
    void Start()
    {
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
        _text.text = "ÉRÉXÉg:" + cost + "\n" +
                     "HP:" + hitpoint;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.SetParent(_select.transform,false); 
        transform.position = eventData.position;
        if (_slotData != null)
        {
            _slotData.hp = 0; _slotData.cost = 0;
            _slotData.setCard = null;
            _slotData = null;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (var r in results)
        {
            if (r.gameObject.tag == "Set")
            {
                if (r.gameObject.GetComponent<SlotData>().setCard == null)
                {
                    _slotData = r.gameObject.GetComponent<SlotData>();
                    if (_slotData.hp == 0 && _slotData.cost == 0)
                    {
                        _slotData.setCard = this;
                        _slotData.hp = hitPoint; _slotData.cost = cost;
                        transform.position = r.gameObject.transform.position;
                        _deckSeting.precomputed = true;
                    }
                }
            }
        }
        if (_slotData == null)
        {
            transform.SetParent(_notSelect.transform, false);
            _deckSeting.precomputed = true;
        }
    }
}
