using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Logic.LevelGenerator
{
	public static class EnumerableExtensions
	{
		public static T GetRandomElement<T>(this IEnumerable<T> enumerable)
			=> enumerable.OrderBy((_) => Random.value).First();
	}
}