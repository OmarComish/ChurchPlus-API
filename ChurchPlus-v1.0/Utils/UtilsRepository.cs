using System;
using System.Collections.Generic;
using System.Linq;
using ChurchPlus_v1._0.Models;
using ChurchPlus_v1._0.DAL;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace ChurchPlus_v1._0.Utils
{
    public class UtilsRepository: IUtils
    {
        public int GetRecordStatusId(string status)
        {
            using(var context = new DataContext())
            {
                return context.RecordStatus.Where(r=>r.Name == status).Select(r => r.Id).FirstOrDefault();
            }
        }
    }
}