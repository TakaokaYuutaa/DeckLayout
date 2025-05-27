using UnityEngine;
using UnityEngine.UI;

public class CardParameterSeting : MonoBehaviour
{
    int cost, hitPoint;
    int costLeast = 1, costHighest = 5;
    int hitPointLeast = 10, hitPointHighest = 255;
    [SerializeField] Text _text;
    void Start()
    {
        cost = SetCost();
        hitPoint = SetHitPoint();
        SetParameter(cost,hitPoint);
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
    public void SetParameter(int cost,int hitpoint)
    {
        _text.text = "ÉRÉXÉg:" + cost + "\n" +
                     "HP:" + hitpoint;
    }
}
