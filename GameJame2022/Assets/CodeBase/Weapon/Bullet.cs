using System;
using CodeBase.Enemies;
using UnityEngine;

namespace CodeBase.Weapon
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField] private float _speed = 20f;
		[SerializeField] private Rigidbody2D _rigidbody;
		[SerializeField] private int _damage = 50;

		private void Start()
		{
			_rigidbody.velocity = transform.right * _speed;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			DealDamage(other);
			
			Destroy(gameObject);
		}

		private void DealDamage(Collider2D target)
		{

			if (target.TryGetComponent(out BaseEnemy enemy))
			{
				enemy.TakeDamage(_damage);
			}
		}
	}
}