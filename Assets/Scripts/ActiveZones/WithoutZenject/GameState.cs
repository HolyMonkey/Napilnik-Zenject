using System;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] private Text _coinsView;

    private uint _coins;

    public int Coins => (int)_coins;

    public void AddCoins(uint coins)
    {
        _coinsView.text = Coins.ToString();
        _coins += coins;
    }
}