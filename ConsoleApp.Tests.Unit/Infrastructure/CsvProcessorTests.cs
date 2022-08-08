using ConsoleApp.Library.Infrastructure.FileProcessors;
using ConsoleApp.Library.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Infrastructure.Tests.Unit
{
    [TestClass]
    public class CsvProcessorTests
    {
        private readonly CsvProcessor _sut;

        public CsvProcessorTests()
        {
            _sut = new CsvProcessor();
        }

        [TestMethod]
        public void GetItems_Shold_Return_ExpectedCountItems()
        {
            //arrange
            var expected = 1424;

            //act
            var actuals = _sut.GetItems("Assets\\data.csv");

            //assert
            Assert.AreEqual(expected, actuals.Count);
        }

        [TestMethod]
        public void GetItems_Shold_Be_ExpectedImportedObject()
        {
            //arrange
            var expectedObj = new ImportedObject()
            {
                Type = "TABLE",
                Name = "PersonCreditCard",
                Schema = "Sales",
                ParentName = "AdventureWorks2016_EXT",
                ParentType = "DATABASE",
                DataType = null,
                IsNullable = null
            };
            var expected = JsonConvert.SerializeObject(expectedObj);

            //act
            var actuals = _sut.GetItems("Assets\\data.csv");
            var actual = JsonConvert.SerializeObject(actuals[1]);

            //assert
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GetItems_Shold_Return_ExpectedFieldDataType()
        {
            //arrange
            var expected = "nvarchar";

            //act
            var actuals = _sut.GetItems("Assets\\data.csv");

            //assert
            actuals[268].DataType.Should().Be(expected);
        }
    }
}
