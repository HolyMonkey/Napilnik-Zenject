using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CoinsRewind : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> _donables;
    [SerializeField] private GameState _game;

    private List<IDonable> _typedDonables;

    private void OnValidate()
    {
        _donables.RemoveAll(d => d is IDonable == false);
    }

    private void Awake()
    {
        _typedDonables = _donables.Cast<IDonable>().ToList();
    }

    private void OnEnable()
    {
        _typedDonables.ForEach(paddock => paddock.Done += OnZombieDone);
    }

    private void OnDisable()
    {
        _typedDonables.ForEach(paddock => paddock.Done -= OnZombieDone);
    }

    private void OnZombieDone()
    {
        _game.AddCoins(10);
    }

}

public interface IDonable
{
    event Action Done;
}
