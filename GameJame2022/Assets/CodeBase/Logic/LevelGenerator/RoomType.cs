using UnityEngine;

namespace CodeBase.Logic.LevelGenerator
{
	public class RoomType : MonoBehaviour
	{
		[SerializeField] private int _type;

		public void RoomDestruction()
		{
			Destroy(gameObject);
		}

		public int Type => _type;
	}
}