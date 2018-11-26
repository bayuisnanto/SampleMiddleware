using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMiddleware
{
    public class LoggingMiddleware
    {
        private RequestDelegate nextDelegate;

        public LoggingMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context) {
            Debug.WriteLine("Before log");
            await nextDelegate.Invoke(context);
            Debug.WriteLine("After log");
        }
    }
}
