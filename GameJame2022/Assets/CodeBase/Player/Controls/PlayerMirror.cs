using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Player.Controls
{
	public class PlayerMirror : MonoBehaviour
	{
		public bool Rotatable;

		[SerializeField] private List<SpriteRenderer> _xFlippers;
		[SerializeField] private List<SpriteRenderer> _yFlippers;

		public bool Flips
		{
			set
			{
				_xFlippers.ForEach((s) => s.flipX = value);
				
				if (Rotatable)
				{
					_yFlippers.ForEach((s) => s.flipY = value);
				}
				else
				{
					_yFlippers.ForEach((s) => s.flipX = value);
				}
			}
		}
	}
}