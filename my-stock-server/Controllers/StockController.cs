using Microsoft.AspNetCore.Mvc;
using my_stock_server.Models;
using my_stock_server.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_stock_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private IStockModel stockModel;
        public StockController(IStockModel _stockModel)
        {
            stockModel = _stockModel;
        }

        [HttpGet]
        public async Task<ActionResult> GetStockData(string date)
        {
            return Ok(await stockModel.GetData(date));
        }
    }
}
