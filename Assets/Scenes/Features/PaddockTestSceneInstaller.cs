using UnityEngine;
using Zenject;

public class PaddockTestSceneInstaller : MonoInstaller
{
    [SerializeField] private ZombiePaddock _paddock;
    [SerializeField] private GameObject _paddockTemplate;
    [SerializeField] private ZombiePaddockActivatingByTimer _activator;

    public override void InstallBindings()
    {
        Container.BindFactory<ZombiePaddock, ZombiePaddock.Factory>()
            .FromComponentInNewPrefab(_paddockTemplate);

        Container.Bind<ZombiePaddock>().FromComponentOn(_paddock.gameObject).AsSingle();

        Container.Bind<ZombiePaddockActivatingByTimer>().FromInstance(_activator);
    }
}