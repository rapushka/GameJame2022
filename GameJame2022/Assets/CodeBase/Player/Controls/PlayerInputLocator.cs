using CodeBase.Weapon;
using UnityEngine;

namespace CodeBase.Player.Controls
{
	public class PlayerInputLocator : MonoBehaviour
	{
		[SerializeField] private PlayerMover _mover;
		[SerializeField] private PlayerJumper _jumper;
		[SerializeField] private PlayerCursorLooker _looker;
		[SerializeField] private BaseWeapon _weapon;

		private PlayerController _input;
		
		private void Awake()
		{
			_input = new PlayerController();

			_input.Player.Jump.performed += (_) => _jumper.Jump();
			_input.Player.Look.performed += _looker.LookAt;
			_input.Player.Attack.performed += (_) => _weapon.Shoot(_looker.Position);
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
	}
}