using Microsoft.VisualStudio.TestTools.UnitTesting;
using CdOrganizer.Models;
using System.Collections.Generic;
using System;

namespace CdOrganizer.Tests
{
  [TestClass]
  public class ArtistTest : IDisposable
  {

    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstancesOfArtist_Artist()
    {
      Artist newArtist = new Artist("test artist");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      //Act
      string result = newArtist.GetArtistName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsArtistId_Int()
    {
      //Arrange
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      //Act
      int result = newArtist.GetId();

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllArtistObjects_ArtistList()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Artist newArtist1 = new Artist(name01);
      Artist newArtist2 = new Artist(name02);
      List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };

      //Act
      List<Artist> result = Artist.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectArtist_Artist()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Artist newArtist1 = new Artist(name01);
      Artist newArtist2 = new Artist(name02);

      //Act
      Artist result = Artist.Find(2);

      //Assert
      Assert.AreEqual(newArtist2, result);
    }

    [TestMethod]
    public void GetAlbums_ReturnsEmptyAlbumList_AlbumList()
    {
      //Arrange
      string name = "Work";
      Artist newArtist = new Artist(name);
      List<Album> newList = new List<Album> { };

      //Act
      List<Album> result = newArtist.GetAlbums();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void AddAlbum_AssociatesAlbumWithArtist_AlbumList()
    {
      //Arrange
      string title = "Walk the dog.";
      string albumArtist = "Walk the Line";
      Album newAlbum = new Album(title, albumArtist);
      List<Album> newList = new List<Album> { newAlbum };
      string name = "Work";
      Artist newArtist = new Artist(name);
      newArtist.AddAlbum(newAlbum);

      //Act
      List<Album> result = newArtist.GetAlbums();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}
