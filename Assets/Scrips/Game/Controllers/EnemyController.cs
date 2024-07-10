using UnityEngine;
using UnityEngine.UI;

public class EnemyController: MonoBehaviour
{
   
    [SerializeField] private float _health = 100f;
    [SerializeField] private Slider _healthbar;
    private bool _alive = true;
    
    private void Start()
    {
        _healthbar.value = _health;
    }
    
    public void TakeDamage(float damage)
    {
        if (!_alive) return;
        
        _healthbar.value -= damage;
        if (_healthbar.value <= 0)
        {
            _alive = false;
           DestroyEnemy();
        }
    }
    private void DestroyEnemy()
    {
        EnemyEvent.OnEnemyDead?.Invoke();
        Destroy(gameObject);
    }
}

