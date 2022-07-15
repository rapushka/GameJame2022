using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace CodeBase.Level
{
	[RequireComponent(typeof(Collider2D))]
	public class LevelRotator : MonoBehaviour
	{
		private Camera _camera;
		private Vector3 _screenPosition;
		private float _angleOffset;
		private Collider2D _collider;

		private void Start()
		{
			_camera = Camera.main;
			_collider = GetComponent<Collider2D>();
		}

		private void Update()
		{
			Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
			if (Input.GetMouseButtonDown(0)
			    && _collider == Physics2D.OverlapPoint(mousePosition))
			{
				_screenPosition = _camera.WorldToScreenPoint(transform.position);
				Vector3 newPosition = Input.mousePosition - _screenPosition;
				Vector3 right = transform.right;
				_angleOffset = (Mathf.Atan2(right.y, right.x)
				                - Mathf.Atan2(newPosition.y, newPosition.x))
				               * Mathf.Rad2Deg;
			}

			if (Input.GetMouseButton(0)
			    && _collider == Physics2D.OverlapPoint(mousePosition))
			{
				Vector3 newPosition = Input.mousePosition - _screenPosition;
				float angle = Mathf.Atan2(newPosition.y, newPosition.x) * Mathf.Rad2Deg;
				transform.eulerAngles = new Vector3(0, 0, angle + _angleOffset);
			}
 		}
	}
}