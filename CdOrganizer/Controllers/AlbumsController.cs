using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;
using System.Collections.Generic;

namespace CdOrganizer.Controllers
{
  public class AlbumsController : Controller
  {

    [HttpGet("/artists/{artistId}/albums/new")]
    public ActionResult New(int artistId)
    {
       Artist artist = Artist.Find(artistId);
       return View(artist);
    }

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

    [HttpGet("/artists/{artistId}/albums/{albumId}")]
    public ActionResult Show(int artistId, int albumId)
    {
      Album album = Album.Find(albumId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist artist = Artist.Find(artistId);
      model.Add("album", album);
      model.Add("artist", artist);
      return View(model);
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
