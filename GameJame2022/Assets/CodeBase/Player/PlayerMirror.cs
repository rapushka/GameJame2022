using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Player
{
	public class PlayerMirror : MonoBehaviour
	{
		[SerializeField] private List<SpriteRenderer> _xFlippers;
		[SerializeField] private List<SpriteRenderer> _yFlippers;

		public bool Flips
		{
			set
			{
				_xFlippers.ForEach((s) => s.flipX = value);
				_yFlippers.ForEach((s) => s.flipY = value);
			}
		}
	}
}