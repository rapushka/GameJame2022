using UnityEngine;

namespace CodeBase.Player.States
{
	public class StandingState : MovementBaseState
	{
		public StandingState(PlayerStateMachine stateMachine)
			: base(stateMachine)
		{
		}

		public override Vector2 GetJumpDirection(float jumpForce)
		{
			StateMachine.Enter<InAirState>();
			return NormalJump(jumpForce);
		}
	}
}