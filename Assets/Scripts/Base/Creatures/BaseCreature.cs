using Shooter.Health;

using UnityEngine;

public abstract class BaseCreature : MonoBehaviour, IHaveHealth {
    public abstract Health Health { get; }
    public abstract bool IsDead { get; }
    public abstract void ChangeHealth(float amount);
}
