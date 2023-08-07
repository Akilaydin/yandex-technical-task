using System;

using Cysharp.Threading.Tasks.Linq;

using Game.Runtime;

using Models;
using Models.Score;

using OriGames.Extensions.Disposable;

using Services;

using StaticData;

using UnityEngine;
using UnityEngine.SceneManagement;

using Views;

using VContainer;
using VContainer.Unity;

namespace Controllers
{
	public class PlayerController : IInitializable, IDisposable
	{
		[Inject] private readonly IInputService _inputService;
		[Inject] private readonly PlayerView _playerView;
		[Inject] private readonly GameSettings _gameSettings;
		[Inject] private readonly IScoreIncrementer _scoreIncrementer;

		private CompositeDisposable _disposables = new();

		void IInitializable.Initialize()
		{
			Time.timeScale = 0;
			
			_disposables.Add(_inputService.HasAnyInput.WithoutCurrent().Subscribe(HandleInputStateChanged));

			_playerView.Collided += HandlePlayerCollided;
			_playerView.TriggerEntered += HandleTriggerEnteredPlayer;
		}
		
		void IDisposable.Dispose()
		{
			_disposables.Dispose();
			
			_playerView.Collided -= HandlePlayerCollided;
			_playerView.TriggerEntered -= HandleTriggerEnteredPlayer;
		}
		
		private void HandleInputStateChanged(bool _)
		{
			if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}
			
			_playerView.Rigidbody2D.gravityScale *= -1;
		}
		
		private void HandlePlayerCollided(Collision2D obj)
		{
			if (_gameSettings.ObstaclesLayer.Includes(obj.gameObject.layer))
			{
				SceneManager.LoadScene(0);
			}
		}

		private void HandleTriggerEnteredPlayer(Collider2D obj)
		{
			if (_gameSettings.CoinsLayer.Includes(obj.gameObject.layer))
			{
				_scoreIncrementer.IncrementScore(1);
			}
		}
	}
}
