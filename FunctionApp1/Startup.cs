using System;
using Adapter;
using BusinessLayer;
using HGV;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace HGV
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
          {
            builder.Services.AddTransient<IQuery , Query>();
            builder.Services.AddTransient<IService, Service>();
           builder.Services.AddSingleton<IDocumentClient>(new DocumentClient(new Uri("https://hgv.documents.azure.com:443/"), "RouLXrjhON6SpUwn9ML2lm67CTULIpi0axOYcd6aP7ga3s69LGJtlQaQxVOcaY9Y6QOijF9jlQHSuPc7g56Wgw=="));
        }
    }
}