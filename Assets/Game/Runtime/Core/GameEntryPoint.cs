using Controllers;

using Views;

using Models;

using StaticData;

using UnityEngine;

using VContainer;
using VContainer.Unity;

namespace Core
{
	public class GameEntryPoint : LifetimeScope
	{
		[SerializeField] private SpawnReferencesConfig _spawnReferencesConfig;
		[SerializeField] private ScoreView _scoreView;
		
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<ScoreModel>(Lifetime.Scoped).AsSelf();
			
			builder.RegisterInstance(_spawnReferencesConfig);
			
			builder.Register<PlayerController>(Lifetime.Scoped).AsImplementedInterfaces();
		}
	}
}
