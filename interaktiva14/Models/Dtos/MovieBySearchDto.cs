using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interaktiva14.Models
{
    public partial class MovieBySearchDto
    {
        public List<MovieDto> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }

        


}
