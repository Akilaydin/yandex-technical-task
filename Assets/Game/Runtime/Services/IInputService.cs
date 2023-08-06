using Cysharp.Threading.Tasks;

namespace Services
{
	public interface IInputService
	{
		public IReadOnlyAsyncReactiveProperty<bool> HasAnyInput { get; }
	}
}
