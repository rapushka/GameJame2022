﻿using UnityEngine;

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

			_input.Player.Jump.performed += (_) => _jumper.Jump();
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