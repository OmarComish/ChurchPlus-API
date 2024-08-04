using System;
using System.Collections.Generic;
using System.Linq;
using ChurchPlus_v1._0.Models;
using ChurchPlus_v1._0.DAL;

namespace ChurchPlus_v1._0.Middleware
{
    public class ISettingsrRepository :ISettings
    {
        public List<OfferingGroup> GetOfferingGroups()
        {
            using(var context = new DataContext())
            {
                return context.OfferingGroup.ToList<OfferingGroup>();
            }
        }
    }
}