using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity; //AREGAR
using OperaWebSite.Models; //AGREGAR

namespace OperaWebSite.Data
{
    public class OperasInitializer : DropCreateDatabaseAlways<OperaDBContext>
    {
        protected override void Seed(OperaDBContext context)
        {
            var operas = new List<Opera>
            {
               new Opera {
                  Title = "Cosi Fan Tutte",
                  Year = 1790,
                  Composer = "Mozart"
               }
            };
            operas.ForEach(s => context.Operas.Add(s));
            context.SaveChanges();

        }

    }
}