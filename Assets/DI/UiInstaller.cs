using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private UIManager _uIManager;

    public override void InstallBindings()
    {
        Container.Bind<UIManager>().FromInstance(_uIManager).AsSingle().NonLazy();
        Container.QueueForInject(_uIManager);
    }
}