using CodeBase.Player.States;
using UnityEngine;

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

		public void Jump()
		{
			_rigidbody.velocity = GetJumpDirection(_rigidbody.velocity);
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			EnterStateIfGround<StandingState>(collision);
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			EnterStateIfGround<FirstJumpState>(collision);
		}

		private Vector2 GetJumpDirection(Vector2 velocity) 
			=> _stateMachine.CurrentState.GetJumpDirection(_jumpForce, velocity);

		private void EnterStateIfGround<T>(Collision2D collision)
			where T : MovementBaseState
		{
			const int defaultLayer = 0;
			const int groundLayer = 12;
			if (collision.gameObject.layer is groundLayer or defaultLayer)
			{
				_stateMachine.Enter<T>();
			}
		}
	}
}