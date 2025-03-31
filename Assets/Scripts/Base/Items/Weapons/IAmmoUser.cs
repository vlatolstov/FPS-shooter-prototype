namespace Shooter.Items.Weapons {
    public interface IAmmoUser {
        void ConsumeAmmo(int amount);
    }

    public interface IReloadable {
        void Reload();
    }

    public interface IAimable {
        void Aim();
    }
}