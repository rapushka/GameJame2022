using UnityEngine;

namespace CodeBase.Logic
{
	public class CameraFollower : MonoBehaviour
	{
		[SerializeField] private float _smoothSpeed;
		[SerializeField] private Vector3 _offset;

		private Transform _target;
		
		private void LateUpdate(){

			Vector3 desiredPosition = _target.position + _offset;
			Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
			transform.position = smoothedPos;
		}

		public void Follow(GameObject target)
		{
			_target = target.transform;
		}
	}
}