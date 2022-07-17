using Unity.Mathematics;
using UnityEngine;

namespace CodeBase.Logic.LevelGenerator
{
	public class SpawnRoom : MonoBehaviour
	{
		[SerializeField] private LayerMask _layer;
		[SerializeField] private LevelGeneration _levelGeneration;
		[SerializeField] private Vector2 _spawnPoint;
		
		private void Update()
		{
			if (_levelGeneration.StopGeneration == false)
			{
				return;
			}

			Collider2D roomDetection = Physics2D.OverlapCircle((Vector3)_spawnPoint, 1, _layer);
			
			if (roomDetection is not null)
			{
				return;
			}

			GameObject room = _levelGeneration.Rooms.GetRandomElement();
			Instantiate(room, _spawnPoint, quaternion.identity, _levelGeneration.transform);
			
			Destroy(gameObject);
		}
	}
}