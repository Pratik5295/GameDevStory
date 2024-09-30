using System;
using UnityEngine;

namespace DevStory.Currency
{
    [System.Serializable]
    public struct CurrencyData
    {
        public int Amount;
    }

    /// <summary>
    /// The singleton to handle all the currency management
    /// in the game.
    /// </summary>
    public class CurrencyManager : MonoBehaviour
    {
        public static CurrencyManager Instance = null;

        [SerializeField]
        private CurrencyData currency;

        public CurrencyData GetCurrency => currency;

        public Action<CurrencyData> OnCurrencyDataChange;

        public Action OnPoorEvent;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            //Init currency at start
            currency = new CurrencyData
            {
                Amount = 100
            };
        }

        public void SetCurrency(CurrencyData _currency)
        {
            currency = _currency;
            OnCurrencyDataChange?.Invoke(currency);
        }

        public void AddCurrency(int _amount)
        {
            currency.Amount += _amount;
            OnCurrencyDataChange?.Invoke(currency);
        }

        public void ReduceCurrency(int _amount)
        {
            if(currency.Amount - _amount >= 0)
            {
                currency.Amount -= _amount;
                OnCurrencyDataChange?.Invoke(currency);
            }
            else
            {
                Debug.Log("You have run out of money!");
                OnPoorEvent?.Invoke();
            }
        }
    }
}
