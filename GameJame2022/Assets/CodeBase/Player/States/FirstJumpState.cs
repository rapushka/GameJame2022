using UnityEngine;

namespace CodeBase.Player.States
{
	public class FirstJumpState : MovementBaseState
	{
		public FirstJumpState(PlayerStateMachine stateMachine)
			: base(stateMachine)
		{
		}

		public override Vector2 GetJumpDirection(float jumpForce, Vector2 velocity)
		{
			StateMachine.Enter<SecondJumpState>();
			return NormalJump(jumpForce);
		}
	}
}