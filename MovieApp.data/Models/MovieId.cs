using System;
using System.Collections.Generic;

#nullable disable

namespace MovieApp.data.Models
{
    public partial class MovieId
    {
        public int MovieId1 { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? GenreId { get; set; }
        public int? DirectorId { get; set; }
    }
}
