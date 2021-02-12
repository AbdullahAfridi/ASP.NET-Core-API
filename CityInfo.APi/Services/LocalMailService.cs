using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi.Services
{
    public class LocalMailService : IMailService
    { 
        private readonly IConfiguration configuration;
        public LocalMailService(IConfiguration configuration) {
            this.configuration = configuration;
        }
       

        public void Send(string subject, string message)
        {

            Debug.WriteLine($"Mail from {configuration["mailSettings:mailFromAddress"]} to {configuration["mailSettings:mailToAddress"]}, with LocalMailService");
            Debug.WriteLine($"Subject:  {subject}");
            Debug.WriteLine($"Message:  {message}");

        }
    }
}
