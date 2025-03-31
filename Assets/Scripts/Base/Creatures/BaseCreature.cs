using Shooter.Health;

public abstract class BaseCreature : IHaveHealth {
    public abstract Health Health { get; }
    public abstract bool IsDead { get; }
    public abstract void ChangeHealth();
}
