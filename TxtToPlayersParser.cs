using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScore
{
  public class TxtToPlayersParser
  {
    public List<Player> TxtToPlayers(List<string> source, ref string errorMessage)
    {
      var players = new List<Player>();
      if (source.Count() % 2 != 0 || source == null)
      {
        errorMessage = "Błąd danych";
        return null;
      }
      for (int i = 0; i < source.Count; i += 2)
      {
        var separated = source.ElementAt(i + 1)
          .Replace(" ", "")
          .ToLower()
          .Replace("x", "0")
          .Split(",")
          .ToList();
        if (separated.Count < 22)
        {
          separated.Add("0");
          separated.Add("0");
        }
        var throwValues = new List<short>();
        try
        {
          foreach (var item in separated)
          {
            throwValues.Add(Convert.ToInt16(item));
          }
        }
        catch (Exception)
        {
          errorMessage = "Błąd danych";
          return null;
        }
        var player = new Player(source[i]);
        for (int j = 0, k = 0; j < 10; j++, k += 2)
        {
          if ((throwValues.ElementAt(k) + throwValues.ElementAt(k + 1)) > 10)
          {
            errorMessage = "Błąd danych";
            return null;
          }
          if (throwValues.ElementAt(k) == 10)
          {
            player.Frames.ElementAt(j).FirstThrow = throwValues.ElementAt(k);
            player.Frames.ElementAt(j).SecondThrow = -1;
          } else
          {
            player.Frames.ElementAt(j).FirstThrow = throwValues.ElementAt(k);
            player.Frames.ElementAt(j).SecondThrow = throwValues.ElementAt(k + 1);
          }
          player.Frames.ElementAt(10).FirstThrow = throwValues.ElementAt(20);
          player.Frames.ElementAt(10).SecondThrow = throwValues.ElementAt(21);
        }
        players.Add(player);
      }
      return players;
    }
  }
}
