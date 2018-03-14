using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models.ViewModels
{
    public class Category
    {
        public string Name { get; set; }
    }
    public class CursoCategoriaViewModel
    {        
        public CursoModel CursoModel { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
