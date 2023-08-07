using DG.Tweening;

using Game.Runtime;

using UnityEngine;

namespace Components
{
	public class VerticalLoopedMovementComponent : MonoBehaviour
	{
		[SerializeField] private float _loopDuration;

		private Tween _currentTween;
		
		private void OnEnable()
		{
			var targetPosition = Mathf.Clamp(transform.localPosition.y * -1, GameConstants.GameFieldBottomBound, GameConstants.GameFieldTopBound);
			
			_currentTween = transform.DOLocalMoveY(targetPosition, _loopDuration).SetLoops(-1, LoopType.Yoyo);
		}

		private void OnDisable()
		{
			if (_currentTween.IsActive())
			{
				_currentTween.Kill();
			}
		}
	}
}
