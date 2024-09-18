namespace CollectableCoin
{
    internal interface ICoinView
    {
        void UpdateCoinsDisplay(int coins);
    }

    public class CoinView : ICoinView
    {
        public void UpdateCoinsDisplay(int coins)
        {
        }
    }
}