﻿using UnityEngine;

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
			velocity = Vector2.zero;
			StateMachine.Enter<FirstJumpState>();
			return NormalJump(jumpForce) + velocity;
		}
	}
}