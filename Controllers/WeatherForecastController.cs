using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogBack.DB;
using blogBack.Repositories;
using LinqToDB;

namespace blogBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly Database _db;

        public WeatherForecastController(Database db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<dynamic> Get()
        {
            var r = new Repository<Blog>(new Database());
            return await  r.Get(new {id = 1});
        }
    }
}
