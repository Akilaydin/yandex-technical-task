using UnityEngine;

namespace Game.Runtime
{
	public static class GameExtensions
	{
		public static bool Includes(this LayerMask mask, int layer)
		{
			return (mask.value & 1 << layer) > 0;
		}
	}
}
