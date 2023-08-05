using Cysharp.Threading.Tasks;

namespace Models
{
	public class ScoreModel
	{
		public IReadOnlyAsyncReactiveProperty<int> CurrentScore => _currentScore;
		
		private AsyncReactiveProperty<int> _currentScore = new(0);
	}
}
