namespace Shooter.Health {
    public class Health {
        private float _currentHealth;
        private float _maxHealth;

        public bool IsAlive => _currentHealth > 0;

        public Health(float currentHealth, float maxHealth) {
            _currentHealth = currentHealth;
            _maxHealth = maxHealth;
        }

        public void ChangeHealth(float delta) {
            _currentHealth += delta;

            if (_currentHealth > _maxHealth) {
                _currentHealth = _maxHealth;
            }
        }
    }
}