using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSeting : MonoBehaviour
{
    [SerializeField] GameObject _select;
    [SerializeField] GameObject _notSelect;
    [SerializeField] GameObject[] _cards;

    int set_A_Sheet = 10;
    private void Start()
    {
        for (int i = 0; i < set_A_Sheet; i++)
        {
            GameObject Card = Instantiate(_cards[Random.Range(0, _cards.Length)]);
            Card.gameObject.GetComponent<CardProgram>()._select = this._select;
            Card.gameObject.GetComponent<CardProgram>()._notSelect = this._notSelect;
            Card.transform.parent = _notSelect.transform;
        }
    }
}