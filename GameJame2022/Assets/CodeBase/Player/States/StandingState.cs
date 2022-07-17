using UnityEngine;

namespace CodeBase.Player.States
{
	public class StandingState : MovementBaseState
	{
		public StandingState(PlayerStateMachine stateMachine)
			: base(stateMachine)
		{
		}

		public override Vector2 GetJumpDirection(float jumpForce, Vector2 velocity)
		{
			StateMachine.Enter<FirstJumpState>();
			return NormalJump(jumpForce);
		}
	}
}