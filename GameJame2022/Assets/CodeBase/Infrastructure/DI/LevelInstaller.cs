using System.Linq;
using CodeBase.Player;
using CodeBase.Player.Controls;
using CodeBase.Weapon;
using UnityEngine;
using Zenject;
using Vector3 = System.Numerics.Vector3;

namespace CodeBase.Infrastructure.DI
{
	public class LevelInstaller : MonoInstaller
	{
		[SerializeField] private Transform _initialPoint;
		[SerializeField] private GameObject _playerPrefub;
		[SerializeField] private GameObject _weaponPrefub;

		public override void InstallBindings()
		{
			Container
				.Bind<BaseWeapon>()
				.FromComponentInNewPrefab(_weaponPrefub)
				.AsSingle();

			Container
				.Bind<PlayerInputLocator>()
				.FromComponentInNewPrefab(_playerPrefub)
				.AsSingle();
			
			Container
				.InstantiatePrefab
				(
					_playerPrefub,
					_initialPoint.position,
					Quaternion.identity,
					null
				);
		}

		private void ResolvePlayerMirror(GameObject player)
		{
			var playerBody = player.GetComponent<SpriteRenderer>();
			var playerLegs = player.GetComponentsInChildren<SpriteRenderer>()
			                       .Single((c) => c.GetComponent<PlayerMirror>() is null);

			Container
				.Bind<SpriteRenderer>()
				.WithId("PlayerBody")
				.FromInstance(playerBody)
				.AsSingle();

			Container
				.Bind<SpriteRenderer>()
				.WithId("PlayerLegs")
				.FromInstance(playerLegs)
				.AsSingle();

			Container
				.Bind<PlayerMirror>()
				.FromComponentInNewPrefab(_weaponPrefub)
				.AsSingle();
		}
	}
}