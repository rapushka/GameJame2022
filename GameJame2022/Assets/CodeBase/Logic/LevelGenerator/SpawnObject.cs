using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic.LevelGenerator
{
	public class SpawnObject : MonoBehaviour
	{
		[SerializeField] private List<GameObject> _objects;

		private void Start()
		{
			GameObject tile = _objects.GetRandomElement();
			Instantiate(tile, transform.position, Quaternion.identity);
		}
	}
}