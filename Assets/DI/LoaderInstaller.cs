using UnityEngine;
using Zenject;

public class LoaderInstaller : MonoInstaller
{
    [SerializeField] private LeveLoader _leveLoader;

    public override void InstallBindings()
    {
        Container.Bind<LeveLoader>().FromInstance(_leveLoader).AsSingle().NonLazy();
        Container.QueueForInject(_leveLoader);
    }
}