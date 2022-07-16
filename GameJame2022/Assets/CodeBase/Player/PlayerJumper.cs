﻿using CodeBase.Player.States;
using UnityEngine;

namespace CodeBase.Player
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

		private Vector2 JumpDirection 
			=> _stateMachine.CurrentState.GetJumpDirection(_jumpForce);

		public void Jump()
		{
			_rigidbody.velocity += JumpDirection;
		}

		private void OnCollisionEnter2D(Collision2D col)
		{
			const int groundLayerIndex = 12;
			if (col.gameObject.layer == groundLayerIndex)
			{
				_stateMachine.Enter<StandingState>();
			}
		}
	}
}