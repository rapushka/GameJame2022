using Unity.Mathematics;
using UnityEngine;

namespace CodeBase.Weapon
{
	public class DebugWeapon : BaseWeapon
	{
		[SerializeField] private Transform _firePoint;
		[SerializeField] private GameObject _bulletPrefab;
		
		private Vector3 _target;

		public override void Shoot(Vector3 target)
		{
			_target = target;
			Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
		}

		private void OnDrawGizmos()
		{	
			Debug.DrawRay(transform.position, _target, Color.red);
		}
	}
}