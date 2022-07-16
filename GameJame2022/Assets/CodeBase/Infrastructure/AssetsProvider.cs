using UnityEngine;

namespace CodeBase.Infrastructure
{
	public class AssetsProvider
	{
		public GameObject Instantiate(string path, Vector3 position)
		{
			var prefub = Resources.Load<GameObject>(path);
			return Object.Instantiate(prefub, position, Quaternion.identity);
		}

		public GameObject Instantiate(string path)
		{
			return Instantiate(path, Vector3.zero);
		}
	}
}