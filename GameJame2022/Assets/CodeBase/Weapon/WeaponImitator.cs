using UnityEngine;

namespace CodeBase.Weapon
{
	public class WeaponImitator : BaseWeapon
	{
		[SerializeField] private Transform _firePoint;
		[SerializeField] private GameObject _bulletPrefab;
		
		private DebugWeapon _weapon;

		private void Start()
		{
			_weapon = gameObject.AddComponent<DebugWeapon>();

			_weapon.Construct(_firePoint, _bulletPrefab);
		}
		
		public override void Shoot(Vector3 target)
		{
			_weapon.Shoot(target);
		}
	}
}