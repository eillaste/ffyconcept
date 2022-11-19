using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.App;
using Contracts.BLL.App;
using Contracts.DAL.App;
using DAL.App.EF;
using Domain.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Controllers;
using WebApp.ViewModels.Test;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;

namespace TestProject.UnitTests
{
    public class ServiceUnitTests
    {
        private readonly TestController _testController;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly AppDbContext _ctx;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;
        private readonly IMapper _mapper2;

        // ARRANGE - common
        public ServiceUnitTests(ITestOutputHelper testOutputHelper)
        {
            
            _testOutputHelper = testOutputHelper;

            
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DAL.App.DTO.StandardUnit, Domain.App.StandardUnit>().ReverseMap();
            });
            IMapper iMapper = config.CreateMapper();
            _mapper = iMapper;
            
            var config2 = new MapperConfiguration(cfg => {
                cfg.CreateMap<BLL.App.DTO.StandardUnit, DAL.App.DTO.StandardUnit>().ReverseMap();
            });
            IMapper iMapper2 = config2.CreateMapper();
            _mapper2 = iMapper2;

            // set up db context fro testing - using in memory db engine
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // provide new random database name here
            // or parallel test methods will conflict with each toher
            optionBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _ctx = new AppDbContext(optionBuilder.Options);
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<TestController>();
            
            // SUT system under test
            _testController = new TestController(logger, _ctx);
            _uow = new AppUnitOfWork(_ctx, _mapper);
            _bll = new AppBLL(_uow, _mapper2);
        }

       
        [Fact]
        public async Task Test__GetAll_StandardUnits()
        {
            // ARRANGE
            _ctx.StandardUnits.Add(new StandardUnit{Id= new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"), Title = "st0", Symbol = "s0"});
            _ctx.StandardUnits.Add(new StandardUnit{Id= new Guid("a9606175-a92e-46bc-b15c-e000d829c7f8"), Title = "st1", Symbol = "s1"});
            await _ctx.SaveChangesAsync();
            _ctx.ChangeTracker.Clear();
            
            // ACT
            var standardUnits = _bll.StandardUnits.GetAllAsync();
            _testOutputHelper.WriteLine(standardUnits.Result.Count().ToString());
           
            //ASSERT
            Assert.Equal(2, standardUnits.Result.Count());
            Assert.IsType<BLL.App.DTO.StandardUnit>(standardUnits.Result.First());
            Assert.Equal("st0", standardUnits.Result.First().Title);
            Assert.Equal("s0", standardUnits.Result.First().Symbol);
            // the magicline _ctx.ChangeTracker.Clear(); 
        }
        
        [Fact]
        public async Task Test__GetOne_StandardUnit()
        {
            // ARRANGE
            _ctx.StandardUnits.Add(new StandardUnit{Id= new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"), Title = "st1", Symbol = "s1"});
            await _ctx.SaveChangesAsync();
            _ctx.ChangeTracker.Clear();
            
            // ACT
            var standardUnit = await _bll.StandardUnits.FirstOrDefaultAsync(new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"));
            _testOutputHelper.WriteLine(standardUnit!.Id.ToString());
           
            // ASSERT
            Assert.NotNull(standardUnit);
            Assert.IsType<BLL.App.DTO.StandardUnit>(standardUnit);
            Assert.Equal("st1", standardUnit!.Title);
            Assert.Equal("s1", standardUnit!.Symbol);
        }
        
        [Fact]
        public async Task Test__Creates_StandardUnit()
        {
            // ARRANGE
            BLL.App.DTO.StandardUnit standardUnit = new BLL.App.DTO.StandardUnit{Id= new Guid("a9606175-a92e-46bc-b15c-e000d829c7f8"), Title = "st1", Symbol = "s1"};
            var addedStandardUnit = _bll.StandardUnits.Add(standardUnit);
            await _bll.SaveChangesAsync();
            _ctx.ChangeTracker.Clear();
            
            // ACT
            var res = await _bll.StandardUnits.FirstOrDefaultAsync(new Guid("a9606175-a92e-46bc-b15c-e000d829c7f8"));
            
            //ASSERT
            addedStandardUnit.Should().NotBeNull();
            res.Should().NotBeNull();
            Assert.IsType<BLL.App.DTO.StandardUnit>(addedStandardUnit);
            Assert.Equal("st1", addedStandardUnit.Title);
            Assert.Equal("s1", addedStandardUnit.Symbol);
            Assert.Equal(addedStandardUnit.Id, res!.Id);
            Assert.Equal(addedStandardUnit.Title, res!.Title);
            Assert.Equal(addedStandardUnit.Symbol, res!.Symbol);
        }
        
        [Fact]
        public async Task Test__Update_StandardUnit()
        {
            // ARRANGE
            _ctx.StandardUnits.Add(new StandardUnit{Id= new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"), Title = "st1", Symbol = "s1"});
            await _ctx.SaveChangesAsync();
            _ctx.ChangeTracker.Clear();
            
            // ACT
            var standardUnit = await _bll.StandardUnits.FirstOrDefaultAsync(new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"));
            _testOutputHelper.WriteLine(standardUnit!.Id.ToString());
            _ctx.ChangeTracker.Clear();
            standardUnit.Title = "st2";
            standardUnit.Symbol = "s2";
            _bll.StandardUnits.Update(standardUnit);
            await _bll.SaveChangesAsync();
            _ctx.ChangeTracker.Clear();
            standardUnit = await _bll.StandardUnits.FirstOrDefaultAsync(new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"));
            
            //ASSERT
            Assert.NotNull(standardUnit);
            Assert.IsType<BLL.App.DTO.StandardUnit>(standardUnit);
            Assert.Equal("st2", standardUnit!.Title);
            Assert.Equal("s2", standardUnit!.Symbol);
        }
        
        [Fact]
        public async Task Test__Exists_StandardUnit()
        {
            // ARRANGE
            _ctx.StandardUnits.Add(new StandardUnit{Id= new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"), Title = "st1", Symbol = "s1"});
            await _ctx.SaveChangesAsync();
            _ctx.ChangeTracker.Clear();
            
            // ACT
            var standardUnit = await _bll.StandardUnits.ExistsAsync(new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"));
            _testOutputHelper.WriteLine(standardUnit.ToString());
            
            //ASSERT
            Assert.True(standardUnit);
        }
        
        [Fact]
        public async Task Test__RemoveAsync_StandardUnit()
        { 
            // ARRANGE
            _ctx.StandardUnits.Add(new StandardUnit{Id= new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"), Title = "st1", Symbol = "s1"});
            await _ctx.SaveChangesAsync();
            _ctx.ChangeTracker.Clear();
            
            // ACT
           await _bll.StandardUnits.RemoveAsync(new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"));
           await _bll.SaveChangesAsync();
           var rex= await _bll.StandardUnits.FirstOrDefaultAsync(new Guid("a8606175-a92e-46bc-b15c-e000d829c7f8"));

           //ASSERT
           Assert.Null(rex);
        }

        
        
        private async Task SeedData(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                _ctx.StandardUnits.Add(new StandardUnit()
                {
                    Title = $"title {i}",
                    Symbol = $"symbol {i}"
                }); 
            }

            await _ctx.SaveChangesAsync();
        }
        
        public class CountGenerator : IEnumerable<object[]>
        {
            private List<object[]> _data
            {
                get
                {
                    var res = new List<Object[]>();
                    for (int i = 1; i <= 100; i++)
                    {
                        res.Add(new object[]{i});
                    }

                    return res;
                }
            }

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        }
    }
}