using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.LevelGenerator
{
	[SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
	public class LevelGeneration : MonoBehaviour
	{
		[SerializeField] private float _moveAmount = 10f;

		[Space] [SerializeField] private LayerMask _layer;
		
		[Space] [SerializeField] private float _minX;
		
		[SerializeField] private float _maxX;
		[SerializeField] private float _minY;
		
		[Space] [SerializeField] private List<Transform> _startingPosition;
		[SerializeField] private List<GameObject> _rooms;
		// 0 == LR
		// 1 == LRB
		// 2 == LRT
		// 3 == LRTB


		private int _direction;
		private bool _stopGeneration;

		private void Start()
		{
			_stopGeneration = false;
			
			Transform startingPosition = _startingPosition.GetRandomElement();
			transform.position = startingPosition.position;

			Instantiate(GetRoom(), transform.position);

			_direction = Random.Range(1, 6);
		}

		private void Update()
		{
			if (_stopGeneration == false)
			{
				Move();
			}
		}

		private void Move()
		{
			Vector3 position = transform.position;
			if (_direction is 1 or 2) // Move Right
			{
				if (position.x < _maxX)
				{
					transform.position = new Vector2(position.x + _moveAmount, position.y);

					int index = Random.Range(0, _rooms.Count);
					Instantiate(_rooms[index], transform.position);

					_direction = Random.Range(1, 6);
					if (_direction == 3)
					{
						_direction = 2;
					}
					else if (_direction == 4)
					{
						_direction = 5;
					}
				}
				else
				{
					_direction = 5;
				}
			}
			else if (_direction is 3 or 4) // Move Left
			{
				if (position.x > _minX)
				{
					transform.position = new Vector2(position.x - _moveAmount, position.y);

					int index = Random.Range(0, _rooms.Count);
					Instantiate(_rooms[index], position);

					_direction = Random.Range(3, 6);
				}
				else
				{
					_direction = 5;
				}
			}
			else if (_direction == 5) // Move Down
			{
				if (position.y > _minY)
				{
					Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, _layer);
					var roomType = roomDetection.GetComponent<RoomType>();
					
					if (roomType.Type != 1
					    && roomType.Type != 3)
					{
						roomType.RoomDestruction();

						int bottomRoom = Random.Range(1, 4);
						if (bottomRoom == 2)
						{
							bottomRoom = 1;
						}

						Instantiate(_rooms[bottomRoom], position);
					}

					transform.position = new Vector2(position.x, position.y - _moveAmount);

					int index = Random.Range(2, 4);
					Instantiate(_rooms[index], transform.position);

					_direction = Random.Range(1, 6);
				}
				else
				{
					_stopGeneration = true;
				}
			}
		}

		private static T Instantiate<T>(T original, Vector3 position)
			where T : Object
		{
			return Instantiate(original, position, Quaternion.identity);
		}

		private GameObject GetRoom()
		{
			return _rooms[0];
		}
	}
}