using CodeBase.Infrastructure.GameStates;

namespace CodeBase.Infrastructure
{
	public class Game
	{
		public GameStateMachine StateMachine;

		public Game(ICoroutineRunner coroutineRunner)
		{
			StateMachine = new GameStateMachine
			(
				new SceneLoader(coroutineRunner)
			);
		}
	}
}