using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Player
{
	public class PlayerMirror : MonoBehaviour
	{
		[SerializeField] private List<SpriteRenderer> _xFlippers;
		[SerializeField] private List<SpriteRenderer> _yFlippers;

		public bool Flip
		{
			set
			{
				foreach (SpriteRenderer sprite in _xFlippers)
				{
					sprite.flipX = value;
				}

				foreach (SpriteRenderer sprite in _yFlippers)
				{
					sprite.flipY = value;
				}
			}
		}
	}
}