using ChinookDal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookExplorerUi.Presentation
{
    public class Genre
    {
        public Genre(ChinookDal.Model.Genre genre, List<Artist> artists)
        {
            this.DatabaseGenre = genre;
            this.Artists = artists;
        }

        public List<Artist> Artists { get; set; }
        public string Name
        {
            get => DatabaseGenre.Name;
            set => DatabaseGenre.Name = value;
        }

        public ChinookDal.Model.Genre DatabaseGenre { get; set; }


    }
}
