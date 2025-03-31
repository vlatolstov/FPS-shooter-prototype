using Shooter.Health;

using UnityEngine;

public class SimpleEnemy : BaseCharacter {
    private Health _health;
    public override Health Health => _health;

    public override bool IsDead => !_health.IsAlive;

    public override void ChangeHealth(float amount) {
        if (IsDead) {
            Debug.Log($"{gameObject.name} is dead!");
            return;
        }
        Debug.Log($"Hit {gameObject.name}! Health was {_health.CurrentHealth}.");
        _health.ChangeHealth(amount);
        Debug.Log($"Became {_health.CurrentHealth}.");
    }

    private void Start() {
        _health = new(100, 100);
    }
}
