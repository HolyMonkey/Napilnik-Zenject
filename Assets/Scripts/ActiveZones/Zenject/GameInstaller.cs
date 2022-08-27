using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace WithZenject
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Text _coinsView;

        public override void InstallBindings()
        {
            Container.Bind<Text>()
                .WithId(UIElement.Coins)
                .FromInstance(_coinsView);

            Container.Bind<GameState>()
                .AsSingle();

            BindDonables();
        }

        private void BindDonables()
        {
            List<IDonable> donables = GameObject.FindObjectsOfType<MonoBehaviour>()
                .Where(m => m is IDonable)
                .Cast<IDonable>()
                .ToList();

            Container.Bind<List<IDonable>>()
                .FromInstance(donables);
        }
    }
}