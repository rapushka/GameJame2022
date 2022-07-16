using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerCursorLooker : MonoBehaviour
	{
		private Vector2 _cursorPosition;
		private Camera _camera;
		private Rigidbody2D _rigidbody;

		private void Start()
		{
			_camera = Camera.main;
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		public void LookAt(InputAction.CallbackContext context)
		{
			_cursorPosition = _camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
		}

		private void FixedUpdate()
		{
			Vector2 facingDirection = _cursorPosition - _rigidbody.position;
			float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
			_rigidbody.MoveRotation(angle);
		}
	}
}