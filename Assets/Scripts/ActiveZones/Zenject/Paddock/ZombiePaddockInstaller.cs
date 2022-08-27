using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZombiePaddockInstaller : MonoInstaller
{
    [SerializeField] private List<GameObject> _zombiesView;
    [SerializeField] private ZombiePaddockActivatingByTimer _activator;

    public override void InstallBindings()
    {
        Container.Bind<List<GameObject>>().FromInstance(_zombiesView);
        Container.Bind<ZombiePaddock>().FromComponentInHierarchy(gameObject).AsSingle();
        Container.Bind<ZombiePaddockActivatingByTimer>().FromInstance(_activator);
    }
}