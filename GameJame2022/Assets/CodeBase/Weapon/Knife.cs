using CodeBase.Enemies;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Weapon
{
	public class Knife : BaseWeapon
	{
		private const int Damage = 100;
		
		private GameObject _range;
		private float _attackDuration;
		
		public void Construct(GameObject range, float attackDuration)
		{
			_range = range;
			_attackDuration = attackDuration;

			var triggerObserver = _range.GetComponent<TriggerObserver>();
			triggerObserver.TriggerEnter += TriggerObserverOnTriggerEnter;
		}

		public override void Shoot(Vector3 target)
		{
			StartAttack();
			
			Invoke(nameof(EndAttack), _attackDuration);
		}

		private void TriggerObserverOnTriggerEnter(Collider2D target)
		{
			if (target.TryGetComponent(out BaseEnemy enemy))
			{
				enemy.TakeDamage(Damage);
			}
		}

		private void StartAttack()
		{
			_range.SetActive(true);
		}

		private void EndAttack()
		{
			_range.SetActive(false);
		}
	}
}