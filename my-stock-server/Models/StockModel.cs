using my_stock_server.Helper;
using my_stock_server.Models.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace my_stock_server.Models
{
    public interface IStockModel
    {
        public Task<string> GetData(string date);
    }
    public class StockModel : IStockModel
    {

        private readonly IHttpClientFactory _clientFactory;

        public int aa = 1;

        public StockModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetData(string date)
        {
            //string queryDate = DateTime.Now.ToString("yyyyMMdd");
            //string queryDate = new DateTime(2021,4,29).ToString("yyyyMMdd");
            string request = $"https://www.twse.com.tw/exchangeReport/MI_INDEX?response=json&date={date}&type=ALLBUT0999&_=1586529875476";
            var client = _clientFactory.CreateClient();
            string response = await HttpRequestHelper.HttpGetStringRequestAsync(client, request);
            StockData data = JsonSerializer.Deserialize<StockData>(response);
            return JsonSerializer.Serialize(data);
        }


    }
}
