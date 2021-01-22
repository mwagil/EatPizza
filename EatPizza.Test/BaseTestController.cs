using AutoMapper;
using EatPizza.Application.Services;
using EatPizza.Controllers;
using EatPizza.Infrastructure.Context;
using EatPizzaServices.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace EatPizza.Test
{
    [TestClass]
    public class BaseTestController
    {
        public IConfigurationBuilder builder;
        public DbContextOptions<EatPizzaContext> optionsBuilder;
        public EatPizzaContext context;
        public IMapper mapper;
        public BaseTestController()
        {
            string curDir = Directory.GetCurrentDirectory();

            builder = new ConfigurationBuilder()
           .SetBasePath(curDir)
           .AddJsonFile("appsettings.json");

            optionsBuilder = new DbContextOptionsBuilder<EatPizzaContext>()
                .UseSqlServer(builder.Build().GetConnectionString("DefaultConnection")).Options;

            context = new EatPizzaContext(optionsBuilder);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapper());
            });

            mapper = mockMapper.CreateMapper();
        }
    }
}
