using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CodeBase.Player.Controls
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class PlayerMirror : MonoBehaviour
	{
		[SerializeField] private List<SpriteRenderer> _playerParts;
		
		private SpriteRenderer _spriteRenderer;

		// [Inject]
		// public void Construct
		// (
		// 	[Inject(Id = "PlayerBody")] SpriteRenderer playerBody,
		// 	[Inject(Id = "PlayerLegs")] SpriteRenderer playerLegs
		// )
		// {
		// 	_playerParts = new List<SpriteRenderer>()
		// 	{
		// 		playerBody,
		// 		playerLegs,
		// 	};
		// }

		private void Start()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void Flips(bool value, bool rotatable)
		{
			_playerParts.ForEach((s) => s.flipX = value);

			if (rotatable)
			{
				_spriteRenderer.flipY = value;
			}
			else
			{
				_spriteRenderer.flipX = value;
			}
		}

		public void ResetAllMirroring()
		{
			_playerParts.ForEach((s) => s.flipX = false);

			_spriteRenderer.flipY = false;
			_spriteRenderer.flipX = false;
		}
	}
}