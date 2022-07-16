namespace CodeBase.Infrastructure.GameStates
{
	public class BootstrapState : IState
	{
		private readonly GameStateMachine _stateMachine;
		private readonly SceneLoader _sceneLoader;

		public BootstrapState
		(
			GameStateMachine stateMachine,
			SceneLoader sceneLoader
		)
		{
			_stateMachine = stateMachine;
			_sceneLoader = sceneLoader;
		}

		public void Enter()
		{
			_sceneLoader.Load(Constants.SceneNames.Initial, onLoaded: EnterLoadLevel);
		}

		private void EnterLoadLevel()
		{
			_stateMachine.Enter<LoadLevelState>();
		}
	}
}