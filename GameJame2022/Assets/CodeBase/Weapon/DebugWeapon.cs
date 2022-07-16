using UnityEngine;

namespace CodeBase.Weapon
{
	public class DebugWeapon : BaseWeapon
	{
		private Vector3 _target;

		public override void Shoot(Vector3 target)
		{
			_target = target;
		}

		private void OnDrawGizmos()
		{	
			Debug.DrawRay(transform.position, _target, Color.red);
		}
	}
}