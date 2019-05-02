using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;
using System.Collections.Generic;

namespace CdOrganizer.Controllers
{
  public class AlbumsController : Controller
  {

    // [HttpGet("/artists/{artistId}/albums/new")]
    // public ActionResult New(int artistId)
    // {
    //    Artist artist = Artist.Find(artistId);
    //    return View(artist);
    // }

    [HttpGet("/albums")]
    public ActionResult Index()
    {
      List<Album> allAlbums = Album.GetAll();
      return View(allAlbums);
    }

    [HttpGet("/albums/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/albums")]
    public ActionResult Create(string title, string albumArtist)
    {
      Album myAlbum = new Album(title, albumArtist);
      return RedirectToAction("Index");
    }

    [HttpGet("/albums/{id}")]
    public ActionResult Show(int id)
    {
      Album album = Album.Find(id);
      return View(album);
    }

    [HttpPost("/albums/deleteAll")]
    public ActionResult DeleteAll()
    {
      Album.ClearAll();
      return View();
    }

    [HttpPost("/albums/delete")]
    public ActionResult Delete(int id)
    {
      Album.RemoveAlbum(id);
      return View();
    }


  }
}
