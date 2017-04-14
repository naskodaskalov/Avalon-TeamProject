using Avalon.Data;
using Avalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalon.Service
{
    public static class DistributorService
    {



        public static void AddDistributor(Distributor distributor)
        {


            using (var context = new AvalonContext())
            {
                context.Distributors.Add(distributor);
                context.SaveChanges();
            }
        }


    }
}
