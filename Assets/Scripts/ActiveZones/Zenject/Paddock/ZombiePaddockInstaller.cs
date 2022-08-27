using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZombiePaddockInstaller : MonoInstaller
{
    [SerializeField] private List<GameObject> _zombiesView;

    public override void InstallBindings()
    {
        Container.Bind<ZombiePaddock>().AsSingle();
        Container.Bind<List<GameObject>>().FromInstance(_zombiesView);
    }
}