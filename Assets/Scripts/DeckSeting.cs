using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DeckSeting : MonoBehaviour
{
    [SerializeField] SlotData[] _slotDate;
    [SerializeField] Text _costText;
    [SerializeField] Text _errorMessage;
    int cost;
    int displayTime = 3, magnification = 1000;// 1s = 1,000
    public bool precomputed = false;
    private void Update()
    {
        if (precomputed)
        {
            cost = CostCalculate();
            _costText.text = "�R�X�g:" + cost;
            precomputed = false;
        }
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
    public void Decision_ClickThis()
    {
        if (cost < 10)
        {
            Debug.Log("success");
        }
        else
        {
            var ct = this.GetCancellationTokenOnDestroy();
            ErorrTextDisplay(ct).Forget();
        }
    }
    async UniTask ErorrTextDisplay(CancellationToken cancel)
    {
        _errorMessage.gameObject.SetActive(true);
        await UniTask.Delay(displayTime * magnification);
        _errorMessage.gameObject.SetActive(false);
    }
}
