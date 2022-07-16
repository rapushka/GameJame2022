using UnityEngine;

namespace CodeBase.Weapon
{
	public abstract class BaseWeapon : MonoBehaviour
	{
		public abstract void Shoot(Vector3 target);
	}
}