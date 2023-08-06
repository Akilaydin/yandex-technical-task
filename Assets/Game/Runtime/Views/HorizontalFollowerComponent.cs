using UnityEngine;

namespace Views
{
	public class HorizontalFollowerComponent : MonoBehaviour
	{
		[SerializeField] private Transform _targetTransform;

		private void Update()
		{
			transform.position = new Vector3(_targetTransform.transform.position.x, 0, -10);
		}
	}
}
