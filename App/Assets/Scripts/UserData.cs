using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class UserData
{
    [XmlArray("FavouriteGames")]
    [XmlArrayItem("Game")]
    public List<string> favouriteGames = new List<string>();

    [XmlArray("GameHistory")]
    [XmlArrayItem("History")]
    public List<string> gameHistory = new List<string>();


    public static UserData LoadUserData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(UserData));
        string text = PlayerPrefs.GetString("user data");

        if(text.Length == 0)
        {
            return new UserData();
        }
        else
        {
            using(StringReader reader = new StringReader(text))
            {
                return serializer.Deserialize(reader) as UserData;
            }
        }
    }
    private void SaveUserData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(UserData));
        using (StringWriter sw = new StringWriter())
        {
            serializer.Serialize(sw, this);
            PlayerPrefs.SetString("user data", sw.ToString());
        }
    }

    public override string ToString() 
    {
        return string.Format("favouriteGames count: {0}", this.favouriteGames.Count);
    }

    public bool HandleFavouriteGame(string gameName) 
    {
        if(this.favouriteGames.IndexOf(gameName) == -1) 
        {
            this.SaveFavouriteGame(gameName);
            return true;
        }
        else 
        {
            this.RemoveFavouriteGame(gameName);
            return false;
        }
    }

    public void SaveFavouriteGame(string gameName) {
        this.favouriteGames.Add(gameName);
        this.SaveUserData();
    }

    public void RemoveFavouriteGame(string gameName) {
        this.favouriteGames.RemoveAll(favGame => favGame.Contains(gameName));
        this.SaveUserData();
    }
}
