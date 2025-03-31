namespace Shooter.Weapons {
    public interface IReloadable {
        bool IsReloading { get; }
        void Reload();
        float ReloadTime { get; }
    }
}