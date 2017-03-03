using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
    public class BandTrackerTest : IDisposable
    {
        public BandTrackerTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_DatabaseEmptyAtFirst()
        {
            //Arrange, Act
            int result = Band.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_Equal_ReturnsTrueIfDescriptionsAreTheSame_true()
        {
            //Arrange, Act
            Band firstBand = new Band("Pentatonix", "Pop", "Problem");
            Band secondBand = new Band("Pentatonix", "Pop", "Problem");

            //Assert
            Assert.Equal(firstBand, secondBand);
        }


        [Fact]
        public void Test_Save_SavesToDatabase()
        {
            //Arrange
            Band testBand = new Band("Pentatonix", "Pop", "Problem");

            //Act
            testBand.Save();
            List<Band> result = Band.GetAll();
            List<Band> testList = new List<Band>{testBand};

            //Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_Save_AssignsIdToObject()
        {
            //Arrange
            Band testBand = new Band("Pentatonix", "Pop", "Problem");

            //Act
            testBand.Save();
            Band savedBand = Band.GetAll()[0];

            int result = savedBand.GetId();
            int testId = testBand.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        public void Dispose()
        {
            Band.DeleteAll();
        }
    }
}
