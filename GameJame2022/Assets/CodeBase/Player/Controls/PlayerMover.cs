using UnityEngine;

namespace CodeBase.Player.Controls
{
	public class PlayerMover : MonoBehaviour
	{
		[SerializeField] private float _moveSpeed;

		private float _direction;

		public bool IsMoving { get; private set; }
		private float ScaledSpeed => _moveSpeed * Time.fixedDeltaTime;

		public void Move(float direction)
		{
			IsMoving = Mathf.Abs(direction) > Constants.Epsilon;
			if (IsMoving == false)
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