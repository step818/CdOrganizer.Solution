using Microsoft.VisualStudio.TestTools.UnitTesting;
using CdOrganizer.Models;
using System.Collections.Generic;
using System;

namespace CdOrganizer.Tests
{
  [TestClass]
  public class AlbumTest : IDisposable
  {
    public void Dispose()
    {
      Album.ClearAll();
    }

    [TestMethod]
    public void AlbumConstructor_CreatesInstanceOfAlbum_Album()
    {
      string thisCd = "Now20";
      string thisArtist = "Nelly";
      Album newAlbum = new Album(thisCd, thisArtist);
      Assert.AreEqual(typeof(Album), newAlbum.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      string title = "Now34";
      string artist = "Nelly";
      Album newAlbum = new Album(title, artist);

      string result = newAlbum.GetTitle();

      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void SetTitle_SetTitle_String()
    {
      string title = "Now35";
      string artist = "Nelly";
      Album newAlbum = new Album(title, artist);

      string updatedTitle = "Now Kids 35";
      newAlbum.SetTitle(updatedTitle);
      string result = newAlbum.GetTitle();

      Assert.AreEqual(updatedTitle, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_AlbumList()
    {
      //Arrange
      List<Album> newList = new List<Album> { };

      //Act
      List<Album> result = Album.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAlbums_AlbumList()
    {
      //Arrange
      string title01 = "Now72";
      string title02 = "Now58";
      string artist1 = "Nelly";
      string artist2 = "DMX";
      Album newAlbum1 = new Album(title01, artist1);
      Album newAlbum2 = new Album(title02, artist2);
      List<Album> newList = new List<Album> { newAlbum1, newAlbum2 };

      //Act
      List<Album> result = Album.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_AlbumsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string title = "Now93";
      string artist = "Nelly";
      Album newAlbum = new Album(title, artist);

      int result = newAlbum.GetId();

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectAlbum_Album()
    {
      // Arrange
      string title01 = "Now101";
      string title02 = "Now91";
      string artist = "Nelly";
      Album newAlbum1 = new Album(title01, artist);
      Album newAlbum2 = new Album (title02, artist);
      // Act
      Album result = Album.Find(1);
      // Assert
      Assert.AreEqual(newAlbum1, result);
    }

  }
}
