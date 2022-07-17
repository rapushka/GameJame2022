using System;
using UnityEngine;

namespace CodeBase.Weapon
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField] private float _speed = 20f;
		[SerializeField] private Rigidbody2D _rigidbody;
		
		private void Start()
		{
			_rigidbody.velocity = transform.right * _speed;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			Debug.Log("other.name = " + other.name);
			
			Destroy(gameObject);
		}
	}
}