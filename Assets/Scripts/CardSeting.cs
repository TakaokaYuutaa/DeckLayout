using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSeting : MonoBehaviour
{
    [SerializeField] GameObject _select;
    [SerializeField] GameObject _notSelect;
    [SerializeField] Transform _content;
    [SerializeField] GameObject[] _cards;
    [SerializeField] Text _sortText;
    List<Transform> _cardDate = new();
    int sortPattern = 0;
    int set_A_card = 10;
    private void Start()
    {
        for (int i = 0; i < set_A_card; i++)
        {
            GameObject Card = Instantiate(_cards[Random.Range(0, _cards.Length)]);
            Card.GetComponent<CardMovement>().cardNo = i;
            Card.GetComponent<CardMovement>()._select = this._select;
            Card.GetComponent<CardMovement>()._notSelect = this._notSelect;
            Card.transform.parent = _notSelect.transform;
        }
        SortSeting();

    }
    public void ClickThis()
    {
        sortPattern++;
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
                sortPattern = 0;
                break;
        }

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
        _cardDate.Sort((a, b) => string.Compare(a.name, b.name));
        for (int i = 0; i < _cardDate.Count; i++)
        {
            _cardDate[i].SetSiblingIndex(i);
        }
    }
    void HPSort()
    {
        _cardDate.Sort((a, b) => b.GetComponent<CardMovement>().hitPoint - a.GetComponent<CardMovement>().hitPoint);
        for (int i = 0; i < _cardDate.Count; i++)
        {
            _cardDate[i].SetSiblingIndex(i);
        }
    }
    void CostSort()
    {
        _cardDate.Sort((a, b) => b.GetComponent<CardMovement>().cost - a.GetComponent<CardMovement>().cost);
        for (int i = 0; i < _cardDate.Count; i++)
        {
            _cardDate[i].SetSiblingIndex(i);
        }
    }
    void　NumberSort()
    {
        _cardDate.Sort((a, b) => a.GetComponent<CardMovement>().cardNo - b.GetComponent<CardMovement>().cardNo);
        for (int i = 0; i < _cardDate.Count; i++)
        {
            _cardDate[i].SetSiblingIndex(i);
        }
    }
}