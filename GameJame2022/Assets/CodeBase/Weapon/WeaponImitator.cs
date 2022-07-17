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
		private SpriteRenderer _spriteRenderer;

		private Vector3 KnifePosition
		{
			get
			{
				Vector3 temp = GunPosition;
				temp.x -= 0.3f;
				return temp;
			}
		}
		
		private Vector3 GunPosition => _spriteRenderer.transform.position ;

		public void ConstructRandomWeapon()
		{
			RemoveAnotherWeapon();

			int randomNumber = Random.Range(1, 3);
			
			if (randomNumber == 1)
			{
				ImitateKnife();
			}
			else
			{
				ImitateDebugWeapon();
			}
		}

		public override void Shoot(Vector3 target)
		{
			_weapon.Shoot(target);
		}

		private void Start()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			
			ImitateDebugWeapon();
		}

		private void ImitateDebugWeapon()
		{
			_weapon = gameObject.AddComponent<DebugWeapon>();

			((DebugWeapon)_weapon).Construct(_firePoint, _bulletPrefab);
			
			_spriteRenderer.sprite = Resources.Load<Sprite>(Constants.AssetPaths.GunSprite);
			_spriteRenderer.transform.position = GunPosition;
		}

		private void ImitateKnife()
		{
			_weapon = gameObject.AddComponent<Knife>();
			
			((Knife)_weapon).Construct(_knifeRange, _knifeAttackDuration);

			_spriteRenderer.sprite = Resources.Load<Sprite>(Constants.AssetPaths.KnifeSprite);
			_spriteRenderer.transform.position = KnifePosition;
		}

		private void RemoveAnotherWeapon()
		{
			var debugWeapon = GetComponent<DebugWeapon>();
			if (debugWeapon != null)
			{
				Destroy(debugWeapon);
			}

			var knife = GetComponent<Knife>();
			if (knife != null)
			{
				Destroy(knife);
			}
		}
	}
}