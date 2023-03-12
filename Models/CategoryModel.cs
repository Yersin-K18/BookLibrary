﻿using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.Models
{
    public class CategoryModel
    {
        static BookLibraryEntities database = new BookLibraryEntities();

        public static List<Category> GetCategories()
        {
            return database.Categories.ToList();
        }
        public static Category GetCategory(int? id) 
        {
            return database.Categories.Find(id);
        }
    }
}