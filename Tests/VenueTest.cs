using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
    public class VenueTest : IDisposable
    {
        public VenueTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_VenueEmptyAtFirst()
        {
            //Arrange, Act
            int result = Venue.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_Equal_ReturnsTrueForSameName()
        {
            //Arrange, Act
            Venue firstVenue = new Venue("Meany Hall");
            Venue secondVenue = new Venue("Meany Hall");

            //Assert
            Assert.Equal(firstVenue, secondVenue);
        }

        [Fact]
        public void Test_Save_SavesVenueToDatabase()
        {
            //Arrange
            Venue testVenue = new Venue("Meany Hall");
            testVenue.Save();

            //Act
            List<Venue> result = Venue.GetAll();
            List<Venue> testList = new List<Venue>{testVenue};

            //Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_Save_AssignsIdToVenueObject()
        {
          //Arrange
          Venue testVenue = new Venue("Meany Hall");
          testVenue.Save();

          //Act
          Venue savedVenue = Venue.GetAll()[0];

          int result = savedVenue.GetId();
          int testId = testVenue.GetId();

          //Assert
          Assert.Equal(testId, result);
        }

        [Fact]
        public void Test_Find_FindBandInDatabase()
        {
            //Arrange
            Band testBand = new Band("Pentatonix", "Pop", "Problem");
            testBand.Save();

            //Act
            Band foundBand = Band.Find(testBand.GetId());

            //Assert
            Assert.Equal(testBand, foundBand);
        }

        [Fact]
        public void Test_AddBand_AddsBandToVenue()
        {
            //Arrange
            Band testBand = new Band("Pentatonix", "Pop", "Problem");
            testBand.Save();

            Venue testVenue = new Venue("Meany Hall");
            testVenue.Save();

            //Act
            testVenue.AddBand(testBand);

            List<Band> result = testVenue.GetBands();
            List<Band> testList = new List<Band>{testBand};

            //Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_GetBands_ReturnsAllVenueBands()
        {
          //Arrange
          Venue testVenue = new Venue("Meany Hall");
          testVenue.Save();

          Band testBand1 = new Band("Pentatonix", "Pop", "Problem");
          testBand1.Save();

          Band testBand2 = new Band("Evanescence", "Rock", "Bring Me To Life");
          testBand2.Save();

          //Act
          testVenue.AddBand(testBand1);
          List<Band> result = testVenue.GetBands();
          List<Band> testList = new List<Band> {testBand1};

          //Assert
          Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_Delete_DeletesVenueAssociationsFromDatabase()
        {
          //Arrange
          Band testBand = new Band("Pentatonix", "Pop", "Problem");
          testBand.Save();

          Venue testVenue = new Venue("Meany Hall");
          testVenue.Save();

          //Act
          testVenue.AddBand(testBand);
          testVenue.Delete();

          List<Venue> resultBandsVenues = testBand.GetVenues();
          List<Venue> testBandsVenues = new List<Venue> {};

          //Assert
          Assert.Equal(testBandsVenues, resultBandsVenues);
        }

        public void Dispose()
        {
            Band.DeleteAll();
            Venue.DeleteAll();
        }
    }
}
