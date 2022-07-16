using UnityEngine;

namespace CodeBase.Logic
{
	public class CameraFollower : MonoBehaviour
	{
		[SerializeField] private float _rotationAngleX;
		[SerializeField] private float _distance;
		[SerializeField] private float _offsetY;
		
		private Transform _followingTarget;
		
		public void Follow(GameObject target)
		{
			_followingTarget = target.transform;
		}

		private void LateUpdate()
		{
			if (_followingTarget is null)
			{
				return;
			}
			
			Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
			Vector3 position = rotation * new Vector3(0, 0, -_distance)
			                   + FollowingPoint(_followingTarget.position);

			transform.rotation = rotation;
			// ReSharper disable once Unity.InefficientPropertyAccess
			transform.position = position;
		}

		private Vector3 FollowingPoint(Vector3 point)
		{
			Vector3 followingPosition = point;
			followingPosition.y += _offsetY;
			return followingPosition;
		}
	}
}