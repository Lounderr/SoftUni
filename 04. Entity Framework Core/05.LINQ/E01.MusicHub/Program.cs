using Microsoft.EntityFrameworkCore;
using MusicHub.Data;
using System.Text;

var db = new ApplicationDbContext();
//db.Database.Migrate();
//db.Database.EnsureDeleted();
//db.Database.EnsureCreated();

Console.WriteLine(ExportAlbumsInfo(db, 1));

string ExportAlbumsInfo(ApplicationDbContext context, int producerId)
{
    /*
    Export all albums which are produced by the provided Producer Id. 
    For each Album, get the Name, Release date in format the "MM/dd/yyyy", 
    Producer Name, the Album Songs with each Song Name, Price (formatted to the second digit) 
    and the Song Writer Name. Sort the Songs by Song Name (descending) and by Writer (ascending). 
    At the end export the Total Album Price with exactly two digits after the decimal place. 
    Sort the Albums by their Total Price (descending).     
    */


    var albums = context.Albums
        .ToArray()
        .Where(a => a.ProducerId == producerId)
        .Select(a => new 
        { 
            AlbumName = a.Name, 
            ReleaseDate = a.ReleaseDate,
            ProducerName = a.Producer.Name, 
            Songs = a.Songs
                        .Select(s => new 
                        { 
                            SongId = s.Id, 
                            SongName = s.Name, 
                            SongPrice = s.Price, 
                            SongWriter = s.Writer 
                        }).ToArray(), 
            AlbumPrice = a.Price })
        .ToList();

    StringBuilder sb = new StringBuilder();
    foreach (var a in albums)
    {
        sb.AppendLine($"-AlbumName: {a.AlbumName}");
        sb.AppendLine($"-ReleaseDate: {a.ReleaseDate.ToString("MM/dd/yyyy")}");
        sb.AppendLine($"-ProducerName: {a.ProducerName}");
        sb.AppendLine($"-Songs:");
        foreach (var s in a.Songs)
        {
            sb.AppendLine($"----#{s.SongId}");
            sb.AppendLine($"----SongName: {s.SongName}");
            sb.AppendLine($"----Price: {s.SongPrice}");
            sb.AppendLine($"----Writer: {s.SongWriter}");
        }
        sb.AppendLine($"-AlbumPrice: {a.AlbumPrice:f2}");
    }

    return sb.ToString();
}