using TMPro;
using UnityEngine;

namespace DevStory.Currency
{
    /// <summary>
    /// UI representation handler of currency
    /// </summary>

    [DefaultExecutionOrder(1)]
    public class UICurrencyHandler : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI currencyText;


        [SerializeField]
        private CurrencyManager currencyManager;

        private void Start()
        {
            currencyManager = CurrencyManager.Instance;

            currencyText = GetComponent<TextMeshProUGUI>();

            if (currencyManager != null)
            {
                currencyManager.OnCurrencyDataChange +=
                    OnCurrencyDataChangeHandler;
            }

            OnCurrencyDataChangeHandler(currencyManager.GetCurrency);

        }

        private void OnDestroy()
        {
            if (currencyManager != null)
            {
                currencyManager.OnCurrencyDataChange -=
                    OnCurrencyDataChangeHandler;
            }
        }

        private void OnCurrencyDataChangeHandler(CurrencyData _newData) 
        {
            currencyText.text = $"£:{_newData.Amount}";
        }
    }
}
