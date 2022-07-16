using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Player.Controls
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerCursorLooker : MonoBehaviour
	{
		[SerializeField] private PlayerMirror _mirror;

		private Vector2 _cursorPosition;
		private Camera _camera;
		private Rigidbody2D _rigidbody;
		private bool _activated;

		public Vector3 Position => _cursorPosition - _rigidbody.position;

		public bool Activate
		{
			set
			{
				_activated = value;
				
				_mirror.ResetAllMirroring();
				_rigidbody.rotation = 0;
			}
		}

		private void Start()
		{
			_camera = Camera.main;
			_rigidbody = GetComponent<Rigidbody2D>();

			_activated = true;
		}

		public void LookAt(InputAction.CallbackContext context)
		{
			_cursorPosition = _camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
		}

		private void FixedUpdate()
		{
			float angle = CalculateAngle();
			Mirroring(angle);

			if (_activated)
			{
				_rigidbody.MoveRotation(angle);
			}
		}

		private float CalculateAngle()
		{
			return Mathf.Atan2(Position.y, Position.x) * Mathf.Rad2Deg;
		}

		private void Mirroring(float angle)
		{
			bool isNeedMirror = angle is > 90 or < -90;
			_mirror.Flips(isNeedMirror, _activated);
		}
	}
}