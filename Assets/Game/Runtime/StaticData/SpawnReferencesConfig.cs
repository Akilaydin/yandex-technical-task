using UnityEngine;

using Views;

namespace StaticData
{
	[CreateAssetMenu(fileName = nameof(SpawnReferencesConfig),menuName = "Game/" + nameof(SpawnReferencesConfig), order = 0)]
	public class SpawnReferencesConfig : ScriptableObject
	{
		[field: SerializeField] public CoinView CoinView { get; private set; }
		[field: SerializeField] public ObstacleView ObstacleView { get; private set; }
	}
}
