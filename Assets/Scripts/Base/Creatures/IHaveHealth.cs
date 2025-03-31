namespace Shooter.Health {
    public interface IHaveHealth {
        Health Health { get; }
        bool IsDead { get; }
        void ChangeHealth(float amount);
    }
}