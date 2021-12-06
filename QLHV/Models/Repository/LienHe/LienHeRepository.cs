using QLHV.Models.Context;
using QLHV.Models.ViewModels.LienHe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Models.Repository.LienHe
{
    public class LienHeRepository
    {
        public static List<LienHeView> GetLienHe()
        {
            using (var context = new MyContext())
            {
                var list= context.Database.SqlQuery<LienHeView>("select * from bang").ToList();
                return list;
            }
            return null;
        }
    }
}