using UnityEngine;

using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller> {

    public PlayerSettings PlayerSettings;
    public CameraSettings CameraSettings;
    public LevelSettings LevelSettings;
    public override void InstallBindings() {
        Container.BindInstance(PlayerSettings).AsSingle();
        Container.BindInstance(CameraSettings).AsSingle();
        Container.BindInstance(LevelSettings).AsSingle();
    }
}