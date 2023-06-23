using UnityEngine;
using Zenject;

public class LoaderInstaller : MonoInstaller
{
    [SerializeField] private LeveLoader _leveLoader;
    [SerializeField] private UIManager _uIManager;

    public override void InstallBindings()
    {
        BindLevelLoader();
        BindUiManager();
    }

    private void BindUiManager()
    {
        Container.Bind<UIManager>().FromInstance(_uIManager).AsSingle();
    }

    private void BindLevelLoader()
    {
        Container.Bind<LeveLoader>().FromInstance(_leveLoader).AsSingle();
    }
}