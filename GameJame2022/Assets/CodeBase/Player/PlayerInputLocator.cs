using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Player
{
	public class PlayerInputLocator : MonoBehaviour
	{
		[SerializeField] private PlayerMover _mover;
		[SerializeField] private PlayerJumper _jumper;
		
		private PlayerController _input;
		
		private void Awake()
		{
			_input = new PlayerController();

			_input.Player.Jump
			      .performed += OnJump;
		}

		private void OnEnable()
		{
			_input.Enable();
		}

		private void OnDisable()
		{
			_input.Disable();
		}

		private void Update()
		{
			var direction = _input.Player.Move.ReadValue<float>();

			_mover.Move(direction);
		}

		private void OnJump(InputAction.CallbackContext context)
		{
			_jumper.Jump();
		}
	}
}