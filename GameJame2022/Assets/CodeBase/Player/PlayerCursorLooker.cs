using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Player
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerCursorLooker : MonoBehaviour
	{
		[SerializeField] private PlayerMirror _mirror;
		
		private Vector2 _cursorPosition;
		private Camera _camera;
		private Rigidbody2D _rigidbody;

		public Vector3 Position => _cursorPosition - _rigidbody.position;

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
			float angle = Mathf.Atan2(Position.y, Position.x) * Mathf.Rad2Deg;
			
			_mirror.Flips = angle is > 90 or < -90;
			_rigidbody.MoveRotation(angle);
		}
	}
}