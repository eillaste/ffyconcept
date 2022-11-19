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
    public class TestControllerUnitTests
    {
        private readonly TestController _testController;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly AppDbContext _ctx;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;
        
        // ARRANGE - common
        public TestControllerUnitTests(ITestOutputHelper testOutputHelper)
        {
            
            _testOutputHelper = testOutputHelper;

            
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StandardUnit, DAL.App.DTO.StandardUnit>();
            });
            IMapper iMapper = config.CreateMapper();
            _mapper = iMapper;

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
            _bll = new AppBLL(_uow, _mapper);
            
        }

        [Fact]
        public async Task Action_Test__Returns_nothing()
        {
            // ACT
            var result = await _bll.StandardUnits.GetAllAsync();
            _testOutputHelper.WriteLine(result.Count().ToString());
            
            //ASSERT
            Assert.NotNull(result);
            //Assert.IsType<BLL.App.DTO.StandardUnit>(result.First());
            /*Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            var vm = viewResult!.Model;
            Assert.IsType<TestViewModel>(vm);
            var testVm = vm as TestViewModel;
            Assert.NotNull(testVm!.StandardUnits);
            // for debugging
            // _testOutputHelper.WriteLine($"Count of elements: {testVm.StandardUnits.Count}");
            Assert.Equal(0, testVm.StandardUnits.Count);*/
        }
        
       
        [Fact]
        public async Task Action_Test__Returns_ViewModel()
        {
            // ACT
            var result = await _testController.Test();
            
            
            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            var vm = viewResult!.Model;
            Assert.IsType<TestViewModel>(vm);
            var testVm = vm as TestViewModel;
            Assert.NotNull(testVm!.StandardUnits);
            // for debugging
            // _testOutputHelper.WriteLine($"Count of elements: {testVm.StandardUnits.Count}");
            Assert.Equal(0, testVm.StandardUnits.Count);
        }

        [Fact]
        public async Task Action_Test__Returns_ViewModel_WithData()
        {
            // ARRANGE
            await SeedData();
            
            // ACT
            var result = await _testController.Test();
            
            //ASSERT
            var testVm = (result as ViewResult)?.Model as TestViewModel;
            // the above cast removes the need for the lines below.
            /*Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult);
            var vm = viewResult!.Model;
            Assert.IsType<TestViewModel>(vm);
            var testVm = vm as TestViewModel;*/
            Assert.NotNull(testVm);
            // Assert.NotNull(testVm!.StandardUnits);
            // _testOutputHelper.WriteLine($"Count of elements: {testVm.StandardUnits.Count}");
            Assert.Equal(1, testVm!.StandardUnits.Count);
            Assert.Equal("title 0", testVm.StandardUnits.First()!.Title);
            Assert.Equal("symbol 0", testVm.StandardUnits.First()!.Symbol);
        }
        
        [Fact]
        public async Task Action_Test__Returns_ViewModel_WithNoData__Fails_With_Exception()
        {
            // ARRANGE
            // await SeedData();
            
            // ACT
            var result = await _testController.Test();
            
            //ASSERT
            var testVm = (result as ViewResult)?.Model as TestViewModel;
 
            Assert.NotNull(testVm);

            Assert.ThrowsAny<Exception>(() => testVm!.StandardUnits.First());

        }
        
        [Theory]
        //[InlineData(1)]
        //[InlineData(5)]
        //[InlineData(10)]
        //[InlineData(100)]
        [ClassData(typeof(CountGenerator))]
        public async Task Action_Test__Returns_ViewModel_WithData_Fluent(int count)
        {
            // ARRANGE
            await SeedData(count);
            
            // ACT
            var result = await _testController.Test();
            
            //ASSERT
            var testVm = (result as ViewResult)?.Model as TestViewModel;
            testVm.Should().NotBeNull();
            testVm!.StandardUnits
                .Should().NotBeNull()
                .And.HaveCount(count)
                .And.Contain(ct => ct.Title! == $"title {count -1 }")
                .And.Contain(ct => ct.Title! == "title 0");
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