namespace CollectableCoin
{
    public interface ICoinController
    {
        void Collect(int coins);
        void UpdateView(int coins);

        void Save();
        ICoinModel Load();
    }

    public class CoinController : ICoinController
    {
        private readonly ICoinModel _model;
        private readonly ICoinView _view;
        private readonly ICoinService _service;

        CoinController(ICoinView view, ICoinService service)
        {
            _view = view;
            _service = service;

            _model = Load();
            _model.Coins.AddListener(UpdateView);
            _model.Coins.Invoke();
        }

        public void Collect(int coins) => _model.Coins.Set(_model.Coins.Value + coins);

        public void UpdateView(int coins) => _view.UpdateCoinsDisplay(coins);

        public void Save() => _service.Save(_model);

        public ICoinModel Load() => _service.Load();
    }
}