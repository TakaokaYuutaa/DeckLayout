using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSeting : MonoBehaviour
{
    [SerializeField] GameObject _select;
    [SerializeField] GameObject _notSelect;
    [SerializeField] DeckSeting _deckSeting;
    [SerializeField] Transform _content;
    [SerializeField] GameObject[] _cards;
    [SerializeField] Text _sortText;
    [SerializeField] Text _orderText;
    List<Transform> _cardDate = new();
    int sortPattern = 1;
    int set_A_card = 10;
    bool order = false;
    private void Start()
    {
        for (int i = 0; i < set_A_card; i++)
        {
            GameObject Card = Instantiate(_cards[Random.Range(0, _cards.Length)]);
            Card.GetComponent<CardMovement>().cardNo = i;
            Card.GetComponent<CardMovement>()._select = this._select;
            Card.GetComponent<CardMovement>()._notSelect = this._notSelect;
            Card.GetComponent<CardMovement>()._deckSeting = this._deckSeting;
            Card.transform.SetParent(_notSelect.transform,false); 
        }
        SortSeting();
    }
    public void SortPatternChange_ClickThis()
    {
        if (sortPattern >= 4)
        {
            sortPattern = 0;
        }
        sortPattern++;
        Sort();
    }
    void Sort()
    {
        switch (sortPattern)
        {
            case 1:
                NumberSort();
                _sortText.text = "獲得順";
                break;
            case 2:
                CostSort();
                _sortText.text = "コスト順";
                break;
            case 3:
                HPSort();
                _sortText.text = "HP順";
                break;
            case 4:
                NameSort();
                _sortText.text = "名前順";
                break;
        }
    }
    public void OrderCard_CrickThis()
    {
        if (order)
        {
            order = false;
            _orderText.text = "降順";
        }
        else
        {
            order = true;
            _orderText.text = "昇順";
        }
        Sort();
    }
    void SortSeting()
    {
        _cardDate.Clear();
        foreach (Transform chi in _content)
        {
            _cardDate.Add(chi);
        }
    }
    void NameSort()
    {
        if (order)
        {
            _cardDate.Sort((a, b) => string.Compare(b.name, a.name));
            for (int i = 0; i < _cardDate.Count; i++)
            {
                _cardDate[i].SetSiblingIndex(i);
            }
        }
        else
        {
            _cardDate.Sort((a, b) => string.Compare(a.name, b.name));
            for (int i = 0; i < _cardDate.Count; i++)
            {
                _cardDate[i].SetSiblingIndex(i);
            }
        }
    }
    void HPSort()
    {
        if (order)
        {
            _cardDate.Sort((a, b) => a.GetComponent<CardMovement>().hitPoint - b.GetComponent<CardMovement>().hitPoint);
            for (int i = 0; i < _cardDate.Count; i++)
            {
                _cardDate[i].SetSiblingIndex(i);
            }
        }
        else
        {
            _cardDate.Sort((a, b) => b.GetComponent<CardMovement>().hitPoint - a.GetComponent<CardMovement>().hitPoint);
            for (int i = 0; i < _cardDate.Count; i++)
            {
                _cardDate[i].SetSiblingIndex(i);
            }
        }
    }
    void CostSort()
    {
        if (order)
        {
            _cardDate.Sort((a, b) => a.GetComponent<CardMovement>().cost - b.GetComponent<CardMovement>().cost);
            for (int i = 0; i < _cardDate.Count; i++)
            {
                _cardDate[i].SetSiblingIndex(i);
            }
        }
        else
        {
            _cardDate.Sort((a, b) => b.GetComponent<CardMovement>().cost - a.GetComponent<CardMovement>().cost);
            for (int i = 0; i < _cardDate.Count; i++)
            {
                _cardDate[i].SetSiblingIndex(i);
            }
        }
    }
    void　NumberSort()
    {
        if (order)
        {
            _cardDate.Sort((a, b) => a.GetComponent<CardMovement>().cardNo - b.GetComponent<CardMovement>().cardNo);
            for (int i = 0; i < _cardDate.Count; i++)
            {
                _cardDate[i].SetSiblingIndex(i);
            }
        }
        else
        {
            _cardDate.Sort((a, b) => b.GetComponent<CardMovement>().cardNo - a.GetComponent<CardMovement>().cardNo);
            for (int i = 0; i < _cardDate.Count; i++)
            {
                _cardDate[i].SetSiblingIndex(i);
            }
        }       
    }
}