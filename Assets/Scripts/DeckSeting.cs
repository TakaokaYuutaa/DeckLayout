using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSeting : MonoBehaviour
{
    public List<bool> cardSeting = new List<bool>()
    {
        false,false,false,false
    };
    [SerializeField] GameObject[] _slot;
}
