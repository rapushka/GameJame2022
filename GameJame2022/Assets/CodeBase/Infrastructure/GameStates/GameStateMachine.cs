using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.GameStates
{
	public class GameStateMachine
	{
		private readonly Dictionary<Type, IState> _states;

		public GameStateMachine(SceneLoader sceneLoader)
		{
			GameFactory gameFactory = new(new AssetsProvider());

			_states = new Dictionary<Type, IState>
			{
				[typeof(BootstrapState)] = new BootstrapState
				(
					this,
					sceneLoader
				),
				
				[typeof(LoadLevelState)] = new LoadLevelState
				(
					this,
					sceneLoader,
					gameFactory
				),
				
				[typeof(GameLoopState)] = new GameLoopState(),
			};
		}

		public void Enter<TState>()
			where TState : class, IState
		{
			ChangeState<TState>().Enter();
		}

		private IState ChangeState<TState>()
			where TState : class, IState
		{
			return GetState<TState>();
		}

		private TState GetState<TState>()
			where TState : class, IState
		{
			return (TState)_states[typeof(TState)];
		}
	}
}