using System;
using System.Runtime.CompilerServices;
using CodeBase.Logic;
using CodeBase.Player.States;
using UnityEngine;

namespace CodeBase.Player.Controls
{
	[RequireComponent(typeof(Collider2D))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerJumper : MonoBehaviour
	{
		[SerializeField] private TriggerObserver _legsTrigger;
		[SerializeField] private float _jumpForce;

		private PlayerStateMachine _stateMachine;
		private Rigidbody2D _rigidbody;

		private void Start()
		{
			_rigidbody = GetComponent<Rigidbody2D>();

			_stateMachine = new PlayerStateMachine();
		}

		private void OnEnable()
		{
			_legsTrigger.TriggerEnter += LegsTriggerOnTriggerEnter;
		}

		private void OnDisable()
		{
			_legsTrigger.TriggerEnter -= LegsTriggerOnTriggerEnter;
		}

		private Vector2 JumpDirection => _stateMachine.CurrentState.GetJumpDirection(_jumpForce);

		public void Jump()
		{
			_rigidbody.velocity += JumpDirection;
		}

		private void LegsTriggerOnTriggerEnter(Collider2D col)
		{
			const int groundLayerIndex = 12;
			if (col.gameObject.layer == groundLayerIndex)
			{
				_stateMachine.Enter<StandingState>();
			}
		}
	}
}