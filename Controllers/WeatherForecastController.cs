﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogBack.DB;

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
        public IEnumerable<string> Get()
        {
            return _db.Tests.Select(x => x.testing);
        }
    }
}