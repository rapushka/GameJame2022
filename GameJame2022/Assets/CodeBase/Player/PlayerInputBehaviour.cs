using System;
using UnityEngine;

namespace CodeBase.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerInputBehaviour : MonoBehaviour
	{
		[SerializeField] private float _moveSpeed = 1f;
		
		private PlayerController _input;
		private float _direction;

		private float ScaledSpeed => _moveSpeed * Time.fixedDeltaTime;

		private void Awake()
		{
			_input = new PlayerController();
			_input.Enable();
		}

		private void Update()
		{
			_direction = _input.Player.Move.ReadValue<float>();

			Move(_direction);
		}

		private void Move(float direction)
		{
			if (Mathf.Abs(direction) < Constants.Epsilon)
			{
				return;
			}

			Vector3 movedPosition = transform.position;
			movedPosition.x += direction * ScaledSpeed;
			// ReSharper disable once Unity.InefficientPropertyAccess
			transform.position = movedPosition;
		}
	}
}