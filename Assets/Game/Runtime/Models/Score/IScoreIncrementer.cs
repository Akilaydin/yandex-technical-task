namespace Models.Score
{
	public interface IScoreIncrementer
	{
		public void IncrementScore(int amount = 1);
	}
}
