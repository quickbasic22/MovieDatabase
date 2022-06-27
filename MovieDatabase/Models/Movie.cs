using System;
using System.Collections.Generic;

namespace MovieDatabase.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
            MovieDetails = new HashSet<MovieDetail>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; } = null!;
        public int Length { get; set; }
        public int Released { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<MovieDetail> MovieDetails { get; set; }
    }
}
