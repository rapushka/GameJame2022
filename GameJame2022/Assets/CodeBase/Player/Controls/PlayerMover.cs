using UnityEngine;

namespace CodeBase.Player.Controls
{
	public class PlayerMover : MonoBehaviour
	{
		[SerializeField] private float _moveSpeed;
		
		private float _direction;
		
		private float ScaledSpeed => _moveSpeed * Time.fixedDeltaTime;

		public void Move(float direction)
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