namespace BowlingScore
{
  public class Frame
  {
    public readonly int FrameNumber;
    public int FirstThrow;
    public int SecondThrow;
    public int Score;
    public Frame(int frameNumber = 0)
    {
      FrameNumber = frameNumber;
    }

  }
}
