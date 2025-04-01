using Zenject;

public class GameInstaller : MonoInstaller {
    public InputManager InputManager;
    public override void InstallBindings() {
        Container.Bind<InputManager>().FromInstance(InputManager).AsSingle();
    }
}