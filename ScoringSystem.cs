using System.Collections.Generic;
using System.Text;

namespace BowlingScore
{
  public class ScoringSystem
  {
    public List<Player> Players;

    private TxtToPlayersParser _txtToPlayersParser = new TxtToPlayersParser();

    
    private string GenerateScoreHTMLTable()
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("<table class=\"results-table\">")
        .AppendLine("<tr>")
        .AppendLine("<th class=\"player\">Gracz </th>")
        .AppendLine("<th class=\"score\">Wynik</th>");
      for (int i = 0; i < 10; i++)
      {
        stringBuilder.AppendLine($"<th>Frame {i+1}</th>");
      }
      stringBuilder.AppendLine("<th>Dod. rz.</th>")
        .AppendLine("</tr>");
      foreach (var player in Players)
      {
        stringBuilder
          .AppendLine("<tr>")
          .AppendLine($"<td class=\"player\">{player.Name}</td>")
          .AppendLine($"<td class=\"score\">{player.TotalScore}</td>");
        foreach (var frame in player.Frames)
        {
          stringBuilder.AppendLine($"<td class=\"throws\">{frame.FirstThrow}  {frame.SecondThrow}</td>");
        }
        stringBuilder.AppendLine("</tr>");
      }
      stringBuilder.AppendLine("</table>");
      return stringBuilder.ToString().Replace("-1","X");
    }

    public string GetScoreHTMLTable(List<string> source, ref string errorMessage)
    {
      Players = _txtToPlayersParser.TxtToPlayers(source, ref errorMessage);
      if (errorMessage != "") return null;
      Players.ForEach(x => x.CalculateScores());
      return GenerateScoreHTMLTable();
    }

  }
}
