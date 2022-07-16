using UnityEngine;

namespace CodeBase.Player.States
{
	public class InAirState : MovementBaseState
	{
		public InAirState(PlayerStateMachine stateMachine)
			: base(stateMachine)
		{
		}

		public override Vector2 GetJumpDirection(float jumpForce)
		{
			return Vector2.zero;
		}
	}
}