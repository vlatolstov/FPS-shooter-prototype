namespace Shooter.Weapons {
    public interface IAmmoUser {
        int CurrentAmmo { get; }
        int MaxAmmo { get; }
        bool HasAmmo { get; }
        void ConsumeAmmo(int amount);
    }
}