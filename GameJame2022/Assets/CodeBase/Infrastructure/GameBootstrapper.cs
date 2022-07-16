using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
	public class GameBootstrapper : MonoBehaviour
	{
		private void Awake()
		{
			DontDestroyOnLoad(this);
			
			if (IsInitialScene() == false)
			{
				SceneManager.LoadScene(Constants.ScenesNames.Init);
			}
			
			StartGame();
		}

		private static void StartGame()
		{
			SceneManager.LoadScene(Constants.ScenesNames.Main);
		}

		private static bool IsInitialScene() 
			=> SceneManager.GetActiveScene().name == Constants.ScenesNames.Init;
	}
}