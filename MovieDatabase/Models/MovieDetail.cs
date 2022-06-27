using System;
using System.Collections.Generic;

namespace MovieDatabase.Models
{
    public partial class MovieDetail
    {
        public int MovieDetailsId { get; set; }
        public DateTime WatchedOn { get; set; }
        public int MovieType { get; set; }
        public int MovieImpression { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
    }
}
