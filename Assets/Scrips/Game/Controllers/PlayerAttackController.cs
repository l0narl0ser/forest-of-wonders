using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private const string ENEMY_TAG = "Enemy";
    [SerializeField] private PlayerController _playerController;
    private float _damage = 25f;

    private void OnTriggerEnter(Collider other)
    {
        if (!_playerController.CanAttack()) return;
        if (other.CompareTag(ENEMY_TAG)) other.GetComponentInParent<EnemyController>().TakeDamage(_damage);
    }
}