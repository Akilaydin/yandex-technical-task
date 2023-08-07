using Cysharp.Threading.Tasks;

namespace Models.Score
{
	public interface IScoreProvider
	{
		public IReadOnlyAsyncReactiveProperty<int> CurrentScore { get; }
	}
}
