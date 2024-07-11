﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Domain
{
    /// <summary>
    /// Блюдо.
    /// </summary>
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<FavoriteUsersDish> FavoriteUsers { get; set; } = new();
    }
}
