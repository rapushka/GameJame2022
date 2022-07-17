using System;
using UnityEngine;

namespace CodeBase.Enemies
{
	public class BaseEnemy : MonoBehaviour
	{
		[SerializeField] private int _health = 100;
		// [SerializeField] private GameObject _deathEffect;

		public void TakeDamage(int damage)
		{
			if (damage < 0)
			{
				throw new InvalidOperationException();
			}
			
			_health -= damage;

			if (_health <= 0)
			{
				Die();
			}
		}

		private void Die()
		{
			// Instantiate(_deathEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}