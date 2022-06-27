using System;
using System.Collections.Generic;

namespace MovieDatabase.Models
{
    public partial class Actor
    {
        public int ActorsId { get; set; }
        public string Actor1 { get; set; } = null!;
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
    }
}
