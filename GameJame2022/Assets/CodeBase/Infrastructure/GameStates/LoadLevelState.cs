using System;
using CodeBase.Logic;
using CodeBase.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.GameStates
{
	public class LoadLevelState : IState
	{
		private readonly GameStateMachine _stateMachine;
		private readonly SceneLoader _sceneLoader;
		private readonly GameFactory _gameFactory;

		public LoadLevelState
		(
			GameStateMachine stateMachine,
			SceneLoader sceneLoader,
			GameFactory gameFactory
		)
		{
			_stateMachine = stateMachine;
			_sceneLoader = sceneLoader;
			_gameFactory = gameFactory;
		}

		public void Enter()
		{
			string sceneName = Constants.SceneNames.Main;
			_sceneLoader.Load(sceneName, OnLoaded);
		}

		private void OnLoaded()
		{
			InitializeGameWorld();
			
			_stateMachine.Enter<GameLoopState>();
		}

		private void InitializeGameWorld()
		{
			Vector3 initialPoint = Object
			                       .FindObjectOfType<InitialPoint>()
			                       .gameObject.transform.position;

			GameObject player = _gameFactory.CreatePlayer(initialPoint);
			SetCameraFollowingTarget(player);
		}

		private void SetCameraFollowingTarget(GameObject target)
		{
			if (Camera.main is null)
			{
				throw new Exception("Unreachable exception");
			}

			Camera.main
			      .GetComponent<CameraFollower>()
			      .Follow(target);
		}
	}
}