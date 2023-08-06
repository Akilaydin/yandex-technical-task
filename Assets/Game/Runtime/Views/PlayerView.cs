using System;

using UnityEngine;

namespace Views
{
	public class PlayerView : MonoBehaviour
	{
		public event Action<Collider2D> TriggerEntered;
		public event Action<Collision2D> Collided;
		
		[field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }

		private void OnTriggerEnter2D(Collider2D other)
		{
			//TriggerEntered!.Invoke(other);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			//Collided!.Invoke(other);
		}
	}
}
