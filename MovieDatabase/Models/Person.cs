using System;
using System.Collections.Generic;

namespace MovieDatabase.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
