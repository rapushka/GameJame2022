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

		protected static Vector2 NormalJump(float jumpForce) 
			=> Vector2.up * jumpForce;

		protected static Vector2 CantJump() 
			=> Vector2.zero;
	}
}