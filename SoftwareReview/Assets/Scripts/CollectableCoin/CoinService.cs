namespace CollectableCoin
{
    public interface ICoinService
    {
        ICoinModel Load();
        void Save(ICoinModel model);
    }
    
    public class CoinService : ICoinService
    {
        public ICoinModel Load()
        {
            return new CoinModel();
        }

        public void Save(ICoinModel model)
        {
        }
    }
}