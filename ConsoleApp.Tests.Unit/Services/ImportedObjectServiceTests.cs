using ConsoleApp.Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Services.Tests.Unit 
{
    [TestClass]
    public class ImportedObjectServiceTests
    {
        private readonly ImportedObjectService _sut;

        public ImportedObjectServiceTests()
        {
            _sut = new ImportedObjectService();
        }

        [TestMethod]
        public void GetSortedImportedObjects_Shold_Return_ThreeDatabases()
        {
            //arrange
            List<ImportedObject> importeds = GetImported();

            //act
            var actual = _sut.GetSortedImportedObjects(importeds);

            //assert
            Assert.AreEqual(3, actual.Count);
        }

        [TestMethod]
        public void GetSortedImportedObjects_Shold_Return_TwoTablesInDBOne()
        {
            //arrange
            List<ImportedObject> importeds = GetImported();

            //act
            var actual = _sut.GetSortedImportedObjects(importeds);

            //assert
            Assert.AreEqual(2, actual["db1"].Count);
        }

        [TestMethod]
        public void GetSortedImportedObjects_Shold_Return_TwoTablesInDBTwo()
        {
            //arrange
            List<ImportedObject> importeds = GetImported();

            //act
            var actual = _sut.GetSortedImportedObjects(importeds);

            //assert
            Assert.AreEqual(2, actual["db2"].Count);
        }

        [TestMethod]
        public void GetSortedImportedObjects_Shold_Return_TwoTablesInDbTthree()
        {
            //arrange
            List<ImportedObject> importeds = GetImported();

            //act
            var actual = _sut.GetSortedImportedObjects(importeds);

            //assert
            Assert.AreEqual(1, actual["db3"].Count);
        }

        [TestMethod]
        public void GetSortedImportedObjects_Shold_Return_ThreeColumnInTableInDBOne()
        {
            //arrange
            List<ImportedObject> importeds = GetImported();

            //act
            var actual = _sut.GetSortedImportedObjects(importeds);

            //assert
            Assert.AreEqual(2, actual["db1"]["tabd11"].Count);
        }

        private List<ImportedObject> GetImported()
        {
            return new List<ImportedObject>()
            {
                new ImportedObject() { Type = "TABLE", Name = "tabd11", Schema = "a", ParentName = "db1", ParentType = "DATABASE", DataType = null, IsNullable = null },
                new ImportedObject() { Type = "TABLE", Name = "tabd12", Schema = "a", ParentName = "db1", ParentType = "DATABASE", DataType = null, IsNullable = null },
                new ImportedObject() { Type = "TABLE", Name = "tabd21", Schema = "b", ParentName = "db2", ParentType = "DATABASE", DataType = null, IsNullable = null },
                new ImportedObject() { Type = "TABLE", Name = "tabd22", Schema = "b", ParentName = "db2", ParentType = "DATABASE", DataType = null, IsNullable = null },
                new ImportedObject() { Type = "TABLE", Name = "tabd31", Schema = "b", ParentName = "db3", ParentType = "DATABASE", DataType = null, IsNullable = null },
                new ImportedObject() { Type = "COLUMN", Name = "col1", Schema = "a", ParentName = "tabd11", ParentType = "TABLE", DataType = "int", IsNullable = false },
                new ImportedObject() { Type = "COLUMN", Name = "col11", Schema = "a", ParentName = "tabd11", ParentType = "TABLE", DataType = "int", IsNullable = false },
                new ImportedObject() { Type = "COLUMN", Name = "col2", Schema = "a", ParentName = "tabd12", ParentType = "TABLE", DataType = "string", IsNullable = true },
                new ImportedObject() { Type = "COLUMN", Name = "col3", Schema = "b", ParentName = "tabd21", ParentType = "TABLE", DataType = "int", IsNullable = true },
                new ImportedObject() { Type = "COLUMN", Name = "col4", Schema = "b", ParentName = "tabd22", ParentType = "TABLE", DataType = "int", IsNullable = true },
                new ImportedObject() { Type = "COLUMN", Name = "col5", Schema = "b", ParentName = "tabd31", ParentType = "TABLE", DataType = "int", IsNullable = true }
            };
        }
    }
}
