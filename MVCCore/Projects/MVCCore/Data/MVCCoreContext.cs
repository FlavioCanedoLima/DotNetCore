using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCCore.Models.ViewModels;

namespace MVCCore.Models
{
    public class MVCCoreContext : DbContext
    {
        public MVCCoreContext (DbContextOptions<MVCCoreContext> options)
            : base(options)
        {
        }

        public DbSet<MVCCore.Models.CursoModel> CursoModel { get; set; }
        public DbSet<CursoCategoriaViewModel> CursoCategoriaViewModel { get; set; }
    }
}
