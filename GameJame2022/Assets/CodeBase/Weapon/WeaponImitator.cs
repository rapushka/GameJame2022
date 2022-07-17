using CodeBase.Logic;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Weapon
{
	public class WeaponImitator : BaseWeapon
	{
		[SerializeField] private Transform _firePoint;
		[SerializeField] private GameObject _bulletPrefab;
		
		[Space] [SerializeField] private GameObject _knifeRange;
		[SerializeField] private float _knifeAttackDuration;
		
		private BaseWeapon _weapon;

		private void Start()
		{
			ImitateKnife();
		}

		private void ImitateDebugWeapon()
		{
			_weapon = gameObject.AddComponent<DebugWeapon>();

			((DebugWeapon)_weapon).Construct(_firePoint, _bulletPrefab);
		}

		private void ImitateKnife()
		{
			_weapon = gameObject.AddComponent<Knife>();
			
			((Knife)_weapon).Construct(_knifeRange, _knifeAttackDuration);
			
			SetUpGameObject();
		}

		private void SetUpGameObject()
		{
			var spriteRenderer = GetComponent<SpriteRenderer>();

			spriteRenderer.sprite = Resources.Load<Sprite>(Constants.AssetPaths.KnifeSprite);
			OffsetSpriteRenderer(spriteRenderer, 0.3f);
			//spriteRenderer.transform.localScale *= 7;
		}

		private static void OffsetSpriteRenderer(Component spriteRenderer, float offset)
		{
			Vector3 position = spriteRenderer.transform.position;
			position.x += offset;
			spriteRenderer.transform.position = position;
		}

		public override void Shoot(Vector3 target)
		{
			_weapon.Shoot(target);
		}
	}
}