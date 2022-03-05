using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BowlingScore.Pages
{
  public class IndexModel : PageModel
  {
    public string Message { get; set; }
    public string Result { get; set; }

    public ScoringSystem Scoring = new ScoringSystem();

    public IndexModel()
    {

    }

    public void OnPostUpload(IFormFile postedFile)
    {
      if (postedFile == null)
      {
        Message = "Błąd. Nie wybrano pliku";
        return;
      }
      if (!postedFile.FileName.EndsWith(".txt"))
      {
        Message = "Błąd. Plik nie jest w formacie .txt";
        return;
      }
      var lines = new List<string>();
      using (var streamReader = new StreamReader(postedFile.OpenReadStream()))
        while (streamReader.Peek() >= 0)
          lines.Add(streamReader.ReadLine());
      string message = "";
      Result = Scoring.GetScoreHTMLTable(lines, ref message);
      Message = message;
      return;

    }

    public void View()
    {

    }
  }
}
