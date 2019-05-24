using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiTodoList.Application;
using MultiTodoList.Application.Infrastructure;

namespace MultiTodoList.Tests.Integration
{
    public abstract class BaseTest: IDisposable
    {
        private readonly HttpClient _client;
        private readonly string _root;
        private readonly TestServer _server;
        
        protected BaseTest()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .ConfigureServices(s => s.AddDbContext<MultiTodoListDbContext>(opt => opt.UseInMemoryDatabase("TestDb"))));

            var client = server.CreateClient();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            _client = client;

            _server = server;

            _root = "api/v1/todo/";
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client.Dispose();
                _server.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}