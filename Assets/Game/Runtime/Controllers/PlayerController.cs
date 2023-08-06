using System;

using Cysharp.Threading.Tasks.Linq;

using OriGames.Extensions.Disposable;

using Services;

using UnityEngine;

using Views;

using VContainer;
using VContainer.Unity;

namespace Controllers
{
	public class PlayerController : IInitializable, IDisposable
	{
		[Inject] private readonly IInputService _inputService;
		[Inject] private readonly PlayerView _playerView;

		private CompositeDisposable _disposables = new();

		void IInitializable.Initialize()
		{
			Time.timeScale = 0;
			
			_disposables.Add(_inputService.HasAnyInput.WithoutCurrent().Subscribe(HandleInputStateChanged));
        }

		void IDisposable.Dispose()
		{
			_disposables.Dispose();
		}

		private void HandleInputStateChanged(bool _)
		{
			if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}
			
			_playerView.Rigidbody2D.gravityScale *= -1;
		}
	}
}
