namespace CollectableCoin
{
    public interface ICoinModel
    {
        Observable<int> Coins { get; }
    }

    public class CoinModel : ICoinModel
    {
        public Observable<int> Coins { get; }
    }
}