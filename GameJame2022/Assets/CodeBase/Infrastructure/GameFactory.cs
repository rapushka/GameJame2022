using UnityEngine;

namespace CodeBase.Infrastructure
{
	public class GameFactory
	{
		private readonly AssetsProvider _assets;

		public GameFactory(AssetsProvider assets)
		{
			_assets = assets;
		}

		public GameObject CreatePlayer(Vector3 initialPoint)
		{
			const string path = Constants.AssetPaths.PlayerPrefub;
			return _assets.Instantiate(path, initialPoint);
		}
	}
}