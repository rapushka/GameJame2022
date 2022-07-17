using System.Collections.Generic;
using System.Linq;
using CodeBase.Weapon;
using UnityEngine;

namespace CodeBase.Player.Controls
{
	public class Reroller : MonoBehaviour
	{
		[SerializeField] private List<Sprite> _playerSprites;
		[SerializeField] private SpriteRenderer _playerSpriteRenderer;
		
		[SerializeField] private WeaponImitator _weaponHolder;
		
		public void Reroll()
		{
			_playerSpriteRenderer.sprite = GetRandomElement(_playerSprites);
			_weaponHolder.ConstructRandomWeapon();
		}

		private T GetRandomElement<T>(IEnumerable<T> enumerable)
		{
			return enumerable.OrderBy((_) => Random.value).First();
		}
	}
}