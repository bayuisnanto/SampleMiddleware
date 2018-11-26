using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMiddleware
{
    public class Greeter : IGreeter
    {
        private IConfiguration _config;

        public Greeter(IConfiguration config)
        {
            _config = config;
        }

        public string GetMessageOfTheDay()
        {
            return _config["Greetings"];
        }
    }
}
