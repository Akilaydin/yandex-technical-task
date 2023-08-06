using Cysharp.Threading.Tasks;

using UnityEngine;

using VContainer.Unity;

namespace Services
{
	public class DesktopInputService : ITickable, IInputService
	{
		IReadOnlyAsyncReactiveProperty<bool> IInputService.HasAnyInput => _hasAnyInput;

		private AsyncReactiveProperty<bool> _hasAnyInput = new(false);

		private bool _hadInputLastFrame = false;

		void ITickable.Tick()
		{
			bool hasInputInCurrentFrame = Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.GetMouseButton(1);

			if (_hadInputLastFrame == hasInputInCurrentFrame)
			{
				return;
			}

			_hadInputLastFrame = hasInputInCurrentFrame;

			_hasAnyInput.Value = hasInputInCurrentFrame;
        }
	}
}
