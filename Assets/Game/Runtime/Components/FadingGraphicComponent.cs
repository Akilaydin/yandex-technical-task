using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

namespace Components
{
	public class FadingGraphicComponent : MonoBehaviour
	{
		[SerializeField] private Graphic _graphic;
		[SerializeField] private float _duration = 0.25f;

		private void Start()
		{
			_graphic.DOFade(0, _duration);
		}
	}
}
