using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace WithZenject
{
    public class GameState
    {
        private Text _coinsView;
        private uint _coins;

        public int Coins => (int)_coins;

        [Inject]
        private void Contructor([Inject(Id = UIElement.Coins)] Text coinsView)
            => (_coinsView) = (coinsView);

        public void AddCoins(uint coins)
        {
            _coins += coins;
            _coinsView.text = Coins.ToString();
        }
    }
}