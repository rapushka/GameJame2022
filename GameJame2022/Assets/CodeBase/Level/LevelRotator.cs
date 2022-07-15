using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace CodeBase.Level
{
	public class LevelRotator : MonoBehaviour
	{
		private Camera _camera;
		private Vector3 _screenPosition;
		private float _angleOffset;

		private void Start()
		{
			_camera = Camera.main;
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				_screenPosition = _camera.WorldToScreenPoint(transform.position);
				Vector3 newPosition = Input.mousePosition - _screenPosition;
				Vector3 right = transform.right;
				_angleOffset = (Mathf.Atan2(right.y, right.x)
				                - Mathf.Atan2(newPosition.y, newPosition.x))
				               * Mathf.Rad2Deg;
			}

			if (Input.GetMouseButton(0) == false)
			{
				return;
			}

			Vector3 rotate = Input.mousePosition - _screenPosition;
			float angle = Mathf.Atan2(rotate.y, rotate.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0, 0, angle + _angleOffset);
		}
	}
}