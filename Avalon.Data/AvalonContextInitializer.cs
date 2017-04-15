using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalon.Data
{
    public class AvalonContextInitializer : DropCreateDatabaseAlways<AvalonContext>
    {

        protected override void Seed(AvalonContext context)
        {
           
            context.Database.ExecuteSqlCommand(File.ReadAllText("../../data/AvalonDataInsert.sql"));

            base.Seed(context);
        }
    }
}
