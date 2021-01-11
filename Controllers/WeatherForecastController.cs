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
            var b = new BlogRepository<Blog>();
            var l = new List<Blog>()
            {
                new Blog(){BlogName = "test", BlogId = 1},
                new Blog(){ BlogName = "test 5", BlogId = 4}
            };
            var blog = new Blog();
            blog.BlogId = 8;
            blog.BlogName = "test 8 async";
            // var i = await b.Remove(x=>x.BlogId == 1);
            var ii = await b.Update(blog);
            var task = await b.GetMany();
            return task;
        }
    }
}
