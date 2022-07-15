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
			HandleMouseDown();
			HandleMouseHold();
		}

		private void HandleMouseHold()
		{
			if (Input.GetMouseButton(0) == false)
			{
				return;
			}

			Vector3 rotate = Input.mousePosition - _screenPosition;
			float angle = Mathf.Atan2(rotate.y, rotate.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0, 0, angle + _angleOffset);
		}

		private void HandleMouseDown()
		{
			if (Input.GetMouseButtonDown(0) == false)
			{
				return;
			}

			_screenPosition = _camera.WorldToScreenPoint(transform.position);
			Vector3 relativePosition = Input.mousePosition - _screenPosition;
			Vector3 right = transform.right;
			_angleOffset = CalculateOffset(right, relativePosition);
		}

		private static float CalculateOffset(Vector3 right, Vector3 relativePosition)
		{
			return (Mathf.Atan2(right.y, right.x)
			        - Mathf.Atan2(relativePosition.y, relativePosition.x))
			       * Mathf.Rad2Deg;
		}
	}
}