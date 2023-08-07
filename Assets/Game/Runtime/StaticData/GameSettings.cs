using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = nameof(GameSettings),menuName = "Game/" + nameof(GameSettings), order = 0)]
	public class GameSettings : ScriptableObject
	{
		[field: SerializeField] public float ObjectsSpawnInterval { get; private set; } = 2f;
		[field: SerializeField] public int ObstaclesPerSpawnIteration { get; private set; } = 2;
		
		[field: SerializeField] public float MinSpawnXAddition { get; private set; } = 5f;
		[field: SerializeField] public float MaxSpawnXAddition { get; private set; } = 15f;
		
		[field: SerializeField] public LayerMask ObstaclesLayer { get; private set; }
		[field: SerializeField] public LayerMask CoinsLayer { get; private set; }
	}
}
