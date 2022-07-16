using System;
using UnityEngine;

namespace CodeBase.Infrastructure
{
	public class GameRunner : MonoBehaviour
	{
		[SerializeField] private GameBootstrapper _bootstrapperTemplate;
		
		private void Awake()
		{
			var bootstrapper = FindObjectOfType<GameBootstrapper>();
				
			if (bootstrapper is null)
			{
				Instantiate(_bootstrapperTemplate);
			}
		}
	}
}