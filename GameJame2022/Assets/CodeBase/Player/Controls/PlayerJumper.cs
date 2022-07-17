using System;
using CodeBase.Logic;
using CodeBase.Player.States;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace CodeBase.Player.Controls
{
	[RequireComponent(typeof(Collider2D))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerJumper : MonoBehaviour
	{
		[SerializeField] private float _jumpForce;

		private PlayerStateMachine _stateMachine;
		private Rigidbody2D _rigidbody;

		private void Start()
		{
			_rigidbody = GetComponent<Rigidbody2D>();

			_stateMachine = new PlayerStateMachine();
		}

		private Vector2 JumpDirection(Vector2 velocity)
		{
			return _stateMachine.CurrentState.GetJumpDirection(_jumpForce, velocity);
		}

		public void Jump()
		{
			_rigidbody.velocity = JumpDirection(_rigidbody.velocity);
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			const int defaultLayer = 0;
			const int groundLayer = 12;
			if (collision.gameObject.layer is groundLayer or defaultLayer)
			{
				_stateMachine.Enter<StandingState>();
			}
		}
	}
}