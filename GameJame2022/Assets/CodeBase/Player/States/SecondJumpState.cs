using UnityEngine;

namespace CodeBase.Player.States
{
	public class SecondJumpState : MovementBaseState
	{
		public SecondJumpState(PlayerStateMachine stateMachine)
			: base(stateMachine)
		{
		}

		public override Vector2 GetJumpDirection(float jumpForce, Vector2 velocity)
		{
			return CantJump() + velocity;
		}
	}
}