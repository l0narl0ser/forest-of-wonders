using System;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private float _damage = 25f;

    private void OnTriggerEnter(Collider other)
    {
        if (!_playerController.CanAttack()) return;
        if (other.CompareTag("Enemy"))
        {
            other.GetComponentInParent<EnemyController>().TakeDamage(_damage);
        }
    }
}