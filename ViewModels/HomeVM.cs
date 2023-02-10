﻿using Fiorello.Models;
using System.Collections.Generic;

namespace Fiorello.ViewModels
{
    public class HomeVM
    {
       public IEnumerable<Slider> Sliders { get; set; }
       public SliderDetail SliderDetail { get; set; }    
       public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }

    }
}
