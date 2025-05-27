using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardvariableSeting : MonoBehaviour
{
    Parameter _para;
    [SerializeField] GameObject[] _card;
    public class Parameter
    {
        int cost, hitPoint;
        int costLeast = 1, costHighest = 5;
        int hitPointLeast = 10, hitPointHighest = 255;
        public int SetCost()
        {
            int cost=Random.Range(costLeast, costHighest + 1);
            return cost;
        }
        public int SetHitPoint()
        {
            int HP =Random.Range(hitPointLeast, hitPointHighest + 1);
            return HP;
        }
    }
    private void Start()
    {
        
    }
}
