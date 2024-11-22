using ChinookDal.Model;

namespace WpfCommunityToolkit.Presentation;

public class Genre
{
    public Genre(ChinookDal.Model.Genre genre, List<Artist> artists)
    {
        this.DatabaseGenre = genre;
        this.Artists = artists;
    }

    public string Name { get => this.DatabaseGenre.Name; private set => this.DatabaseGenre.Name = value; }
    public ChinookDal.Model.Genre DatabaseGenre { get; set; }
    public List<Artist> Artists { get; set; }
}
