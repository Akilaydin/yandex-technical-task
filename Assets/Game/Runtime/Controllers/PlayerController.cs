using Views;

using VContainer;

namespace Controllers
{
	public class PlayerController
	{
		[Inject] private readonly PlayerView _playerView;
	}
}
