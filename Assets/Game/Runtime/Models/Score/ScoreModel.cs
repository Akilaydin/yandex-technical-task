using Cysharp.Threading.Tasks;

namespace Models.Score
{
	public class ScoreModel : IScoreProvider, IScoreIncrementer
	{
		IReadOnlyAsyncReactiveProperty<int> IScoreProvider.CurrentScore => _currentScore;
		
		private AsyncReactiveProperty<int> _currentScore = new(0);

		void IScoreIncrementer.IncrementScore(int amount)
		{
			_currentScore.Value += amount;
		}
	}
}
