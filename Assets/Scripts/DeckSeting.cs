using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DeckSeting : MonoBehaviour
{
    [SerializeField] SlotData[] _slotDate;
    [SerializeField] Text _costText;
    [SerializeField] Text _errorMessage;
    int cost;
    private void Update()
    {
        cost = CostCalculate();
        _costText.text = "ƒRƒXƒg:" + cost;
        if (cost >= 10)
        {
            _costText.color = Color.red;
        }
        else
        {
            _costText.color = Color.white;
        }
    }
    int CostCalculate()
    {
        int cost = 0;
        foreach (SlotData slotData in _slotDate)
        {
            cost += slotData.cost;
        }
        return cost;
    }
    public void Decision()
    {
        if (cost < 10)
        {
            Debug.Log("success");
        }
        else
        {
            var ct = this.GetCancellationTokenOnDestroy();
            _ = ErorrTextDisplay(ct);
        }
    }
    async UniTask ErorrTextDisplay(CancellationToken cancel)
    {
        int displayTime =3, magnification = 1000;
        _errorMessage.gameObject.SetActive(true);
        await UniTask.Delay(displayTime*magnification);
        _errorMessage.gameObject.SetActive(false);
    }
}
