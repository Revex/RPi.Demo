﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Nancy.Hosting.Self;
using Common.Logging;
using Owin;
using Nancy;

namespace RPi.NancyHost
{
    class Program
    {
        ILog Log;
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            Log = LogManager.GetCurrentClassLogger();
            
            var options = new StartOptions
            {
                ServerFactory = "Nowin",
                Port = 8080
            };

            Log.InfoFormat("rpi.nancy starting on port={0}", options.Port);

            //using (var webHost = new Nancy.Hosting.Self.NancyHost(new Uri(webUrl)))
            //{
            using (WebApp.Start<Startup>(options))
                {
                    //webHost.Start();
                    Console.Write("Press any key");
                    Console.ReadKey();
                    //webHost.Stop();
                }
            //}
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            app.UseNancy();
        }
    }

}