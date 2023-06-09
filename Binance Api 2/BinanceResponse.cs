namespace Binance_Api_2
{
    abstract class CryptoAPIInfo
    {
        public double weightedAvgPrice { get; set; }
        public double lowPrice { get; set; }
        public double highPrice { get; set; }
        public string Response { get; set; }
        public double volume { get; set; }
    }
    class BinanceResponse : CryptoAPIInfo
    {
        public double price { get; set; }
        public string symbol { get; set; }
        public double priceChangePercent { get; set; }
    }
}
