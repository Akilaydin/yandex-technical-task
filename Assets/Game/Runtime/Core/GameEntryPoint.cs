using Controllers;

using Views;

using Models;

using Services;

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
		[SerializeField] private PlayerView _playerView;
		
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<ScoreModel>(Lifetime.Scoped).AsSelf();
			
			builder.RegisterInstance(_spawnReferencesConfig);
			builder.RegisterInstance(_scoreView);
			builder.RegisterInstance(_playerView);
			
			builder.Register<PlayerController>(Lifetime.Scoped).AsImplementedInterfaces();
			
			builder.Register<DesktopInputService>(Lifetime.Scoped).AsImplementedInterfaces();
		}
	}
}
