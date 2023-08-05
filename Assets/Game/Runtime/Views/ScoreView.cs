﻿using System;

using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;

using Models;

using TMPro;

using UnityEngine;

using VContainer;

namespace Views
{
	public class ScoreView : MonoBehaviour
	{
		private const string ScorePrefix = "Score: ";
		
		[SerializeField] private TMP_Text _scoreText;
		
		private IDisposable _subscription;
		
		[Inject]
		private void Construct(ScoreModel model)
		{
			model.CurrentScore.Subscribe(UpdateScore);
		}

		private void UpdateScore(int score)
		{
			_scoreText.text = ScorePrefix + score;
		}

		private void OnDestroy()
		{
			_subscription?.Dispose();
		}
	}
}
