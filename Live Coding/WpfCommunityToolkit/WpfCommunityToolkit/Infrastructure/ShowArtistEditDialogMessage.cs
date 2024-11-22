using ChinookDal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCommunityToolkit.Infrastructure
{
    public class ShowArtistEditDialogMessage
    {
        public ShowArtistEditDialogMessage(Artist artist)
        {
            this.Artist = artist;
        }

        public Artist Artist { get; set; }

    }
}
