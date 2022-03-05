using System.Collections.Generic;
using System.Linq;

namespace BowlingScore
{
  public class Player
  {
    public string Name;
    public int TotalScore { get => Frames.Sum(x => x.Score); }
    public List<Frame> Frames;

    public Player(string name)
    {
      Name = name;
      Frames = new List<Frame>(11);
      for (int i = 0; i < 11; i++)
      {
        Frames.Add(new Frame(i)) ;
      }
    }

    public void CalculateScores()
    {
      for (int i = 0; i < Frames.Count()-1; i++)
      {
        if ( (Frames.ElementAt(i).FirstThrow == 10 || Frames.ElementAt(i).SecondThrow == 10) && Frames.ElementAt(i).FrameNumber !=9)
        {
          if (Frames.ElementAt(i + 1).FirstThrow == 10 )
            Frames.ElementAt(i).Score = 10 +
              Frames.ElementAt(i + 1).FirstThrow +
              Frames.ElementAt(i + 2).FirstThrow;
          else
            Frames.ElementAt(i).Score = 10 +
              Frames.ElementAt(i + 1).FirstThrow +
              Frames.ElementAt(i + 1).SecondThrow;
          continue;
        }
        if ((Frames.ElementAt(i).FirstThrow == 10 || Frames.ElementAt(i).SecondThrow == 10) && Frames.ElementAt(i).FrameNumber == 9)
        {
            Frames.ElementAt(i).Score = 10 +
              Frames.ElementAt(i + 1).FirstThrow +
              Frames.ElementAt(i + 1).SecondThrow;
          continue;
        }

        if ((Frames.ElementAt(i).FirstThrow + Frames.ElementAt(i).SecondThrow) == 10)
        {
          Frames.ElementAt(i).Score = 10 + 
            Frames.ElementAt(i + 1).FirstThrow;
          continue;
        }

        Frames.ElementAt(i).Score = 
          Frames.ElementAt(i).FirstThrow +
          Frames.ElementAt(i).SecondThrow;
      }
      Frames.ElementAt(10).Score = 0;
    }
  }
}
