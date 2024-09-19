using System;
using UnityEngine;

namespace CollectableCoin
{
    public class CoinComponent : MonoBehaviour
    {
        public CoinController CoinController;

        private void Awake()
        {
            var view = new CoinView();
            var service = new CoinService();
            CoinController = new CoinController(view, service);
        }
    }
}