using System;
using System.Collections.Generic;

using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;

using DG.Tweening;

using Game.Runtime;

using OriGames.Extensions.Disposable;

using StaticData;

using UnityEngine;
using UnityEngine.Pool;

using VContainer;
using VContainer.Unity;

using Views;

using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Controllers
{
	public class SpawningController : IInitializable, IStartable, IDisposable
	{
		[Inject] private readonly SpawnReferencesConfig _spawnReferencesConfig;
		[Inject] private readonly PlayerView _playerView;
		[Inject] private readonly GameSettings _gameSettings;

		private ObjectPool<GameObject> _obstaclesPool;
		private ObjectPool<GameObject> _coinsPool;

		private Queue<GameObject> _activeObjects = new();

		private CompositeDisposable _disposables = new();

		void IInitializable.Initialize()
		{
			_obstaclesPool = new ObjectPool<GameObject>(CreateObstacle, OnGet, OnRelease, OnDestroy);
			_coinsPool = new ObjectPool<GameObject>(CreateCoin, OnGet, OnRelease, OnDestroy);
			
			_disposables.Add(_coinsPool);
			_disposables.Add(_obstaclesPool);
		}

		void IStartable.Start()
		{
            _disposables.Add(UniTaskAsyncEnumerable.Interval(TimeSpan.FromSeconds(_gameSettings.ObjectsSpawnInterval)).Subscribe(SpawnObjects));

			UniTask.Delay(TimeSpan.FromSeconds(_gameSettings.ObjectsSpawnInterval)).ContinueWith(() =>
			{
				_disposables
					.Add(UniTaskAsyncEnumerable.Interval(TimeSpan.FromSeconds(_gameSettings.ObjectsSpawnInterval + GameConstants.ReleaseObjectsInterval))
					.Subscribe(ReleaseObjects));
			}).Forget();
		}
		
		void IDisposable.Dispose()
		{
			_disposables.Dispose();
		}
		
		private void SpawnObjects(AsyncUnit _)
		{
			for (int i = 0; i < _gameSettings.ObstaclesPerSpawnIteration; i++)
			{
				_obstaclesPool.Get();
			}
            
			_coinsPool.Get();
		}

		private void ReleaseObjects(AsyncUnit _)
		{
			for (int i = 0; i < _gameSettings.ObstaclesPerSpawnIteration; i++)
			{
				_obstaclesPool.Release(_activeObjects.Dequeue());
			}
            
			_coinsPool.Release(_activeObjects.Dequeue());
		}

		private GameObject CreateCoin()
		{
			return Object.Instantiate(_spawnReferencesConfig.CoinView).gameObject;
		}
		
		private GameObject CreateObstacle()
		{
			return Object.Instantiate(_spawnReferencesConfig.ObstacleView).gameObject;
		}

		private void OnGet(GameObject go)
		{
			go.SetActive(true);

			var randomX = _playerView.transform.position.x + Random.Range(_gameSettings.MinSpawnXAddition, _gameSettings.MaxSpawnXAddition);
			var randomY = Random.Range(GameConstants.GameFieldBottomBound, GameConstants.GameFieldTopBound);
			
			var targetPosition = new Vector2(randomX, randomY);
			
			go.transform.position = targetPosition;
			
			_activeObjects.Enqueue(go);
        }

		private void OnRelease(GameObject go)
		{
			go.transform.SetParent(null);
			go.SetActive(false);
		}

		private void OnDestroy(GameObject go) { }
	}
}
