using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace WithZenject 
{
    public class CoinsRewind : MonoBehaviour
    {
        private GameState _game;
        private List<IDonable> _donables;

        [Inject]
        private void Contructor(List<IDonable> donables, GameState game) 
            => (_donables, _game) = (donables, game);

        private void OnEnable()
        {
            _donables.ForEach(paddock => paddock.Done += OnZombieDone);
        }

        private void OnDisable()
        {
            _donables.ForEach(paddock => paddock.Done -= OnZombieDone);
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
}