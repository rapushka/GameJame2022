using CodeBase.Player.Controls;
using UnityEngine;

namespace CodeBase.Player
{
	public class PlayerAnimator : MonoBehaviour
	{
		private static readonly int IsMoving = Animator.StringToHash("IsMoving");
		private static readonly int IsJumping = Animator.StringToHash("IsJumping");
		
		[SerializeField] private Animator _animator;
		[SerializeField] private PlayerMover _mover;

		private void Update()
		{
			_animator.SetBool(IsMoving, _mover.IsMoving);
		}
	}
}