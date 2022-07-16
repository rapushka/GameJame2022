using UnityEngine;

namespace CodeBase.Infrastructure
{
	public class GameRunner : MonoBehaviour
	{
		[SerializeField] private GameBootstrapper _gameBootstrapperPrefub;
		
		private void Awake()
		{
			var bootstrapper = FindObjectOfType<GameBootstrapper>();

			if (bootstrapper == null)
			{
				Instantiate(_gameBootstrapperPrefub);
			}
		}
	}
}