using Khuari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Khuari.ViewModels
{
    public class NewMoviesViewModel
    {


        public IEnumerable<Genre> Gener { get; set; }

        public Movie movie { get; set; }



    }
}