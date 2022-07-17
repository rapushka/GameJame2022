using UnityEngine;

namespace CodeBase.Weapon
{
	public class DebugWeapon : BaseWeapon
	{
		private Transform _firePoint;
		private GameObject _bulletPrefab;

		public void Construct(Transform firePoint, GameObject bulletPrefab)
		{
			_firePoint = firePoint;
			_bulletPrefab = bulletPrefab;
		}

		public override void Shoot(Vector3 target)
		{
			Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
		}
	}
}