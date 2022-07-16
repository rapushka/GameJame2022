using UnityEngine;

namespace CodeBase.Player.States
{
	public abstract class MovementBaseState
	{
		protected readonly PlayerStateMachine StateMachine;

		protected MovementBaseState(PlayerStateMachine stateMachine)
		{
			StateMachine = stateMachine;
		}

		public abstract Vector2 GetJumpDirection(float jumpForce);
	}
}