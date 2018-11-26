using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMiddleware
{
    public class Greeter : IGreeter
    {
        public string GetMessageOfTheDay()
        {
            return "Dari Class Greeter!";
            throw new NotImplementedException();
        }
    }
}
