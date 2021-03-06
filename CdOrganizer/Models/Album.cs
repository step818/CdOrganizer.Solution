using System.Collections.Generic;

namespace CdOrganizer.Models
{
  public class Album
  {
    private string _title;
    private string _albumArtist;
    private int _id;
    private static List<Album> _instances = new List<Album> {};

    public Album (string title, string albumArtist)
    {
      _title = title;
      _albumArtist = albumArtist;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetTitle()
    {
      return _title;
    }

    public void SetTitle(string newTitle)
    {
      _title = newTitle;
    }

    public string GetAlbumArtist()
    {
      return _albumArtist;
    }

    public void SetAlbumArtist(string newAlbumArtist)
    {
      _albumArtist = newAlbumArtist;
    }

    public static List<Album> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static void RemoveAlbum(int id)
    {
      _instances.Remove(_instances[id]);
    }

    public int GetId()
    {
      return _id;
    }

    public static Album Find(int searchId)
    {
      for(int i=0; i<_instances.Count; i++)
      {
        if(_instances[i]._id == searchId)
        {
          return _instances[i];
        }

      }
      return _instances[0];
    }

  }
}
