using System.Collections.Generic;
using CodeBase.Player.States;
using System;

namespace CodeBase.Player
{
	public class PlayerStateMachine
	{
		private readonly Dictionary<Type, MovementBaseState> _states;
		
		public PlayerStateMachine()
		{
			_states = new Dictionary<Type, MovementBaseState>
			{
				[typeof(StandingState)] = new StandingState(this),
				[typeof(SecondJumpState)] = new SecondJumpState(this),
				[typeof(FirstJumpState)] = new FirstJumpState(this),
			};

			Enter<StandingState>();
		}

		public MovementBaseState CurrentState { get; private set; }

		public void Enter<TState>()
			where TState : MovementBaseState
		{
			CurrentState = _states[typeof(TState)];
		}
	}
}