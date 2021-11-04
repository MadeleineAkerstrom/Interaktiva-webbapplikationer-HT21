using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static interaktiva14.Models.MovieBySearchDto;

namespace interaktiva14.Models.ViewModels
{
    public class HomeViewModel
    {
        
        /// <summary>
        /// Movie club information from CMDb
        /// </summary>
        /// <value>Return toplist from CMDb, sorted on number of likes</value>
        public List<MovieInformationDto> Toplist {get; set;}

        
        public HomeViewModel(List<MovieInformationDto> movieList)
        {
            Toplist = movieList.OrderByDescending(o=>o.NumberOfLikes).ToList(); 
        }
        public HomeViewModel()
        {   
        }
    }
}
