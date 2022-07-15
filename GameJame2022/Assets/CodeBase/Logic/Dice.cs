using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic
{
	public class Dice : MonoBehaviour
	{
		[SerializeField] private List<TriggerObserver> _sides;

		private void Start()
		{
			for (int i = 0; i < _sides.Count; i++)
			{
				int index = i;
				_sides[i].TriggerEnter += (c) => OnSideActivate(index, c);
				_sides[i].TriggerExit += (c) => OnSideDeactivate(index, c);
			}
		}

		private void OnSideActivate(int index, Collider2D other)
		{
			Debug.Log($"Side number {index} is activated");
		}

		private void OnSideDeactivate(int index, Collider2D other)
		{
		}
	}
}