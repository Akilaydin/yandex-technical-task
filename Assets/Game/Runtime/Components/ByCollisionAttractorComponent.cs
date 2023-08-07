using DG.Tweening;

using Game.Runtime;

using UnityEngine;

namespace Components
{
	public class ByCollisionAttractorComponent : MonoBehaviour
	{
		[SerializeField] private LayerMask _targetLayerMask;
		[SerializeField] private float _jumpPower = 2f;
		[SerializeField] private float _jumpDuration = 0.5f;
		[SerializeField] private Ease _easeType;
        
		private Tween _jumpTween;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (_targetLayerMask.Includes(other.gameObject.layer) == false || _jumpTween.IsActive())
			{
				return;
			}
            
			transform.SetParent(other.transform, true);
			
			_jumpTween = transform.DOLocalJump(Vector3.zero, _jumpPower, 1, _jumpDuration)
				.SetLink(gameObject)
				.SetEase(_easeType)
				.OnComplete(() => gameObject.SetActive(false));
		}
	}
}
