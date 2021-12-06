using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLHV.Common
{
    [Serializable]
    public class UserLogin
    {
        //public string UserID { set; get; }
        public string MaHV { set; get; }
        public string UserName { set; get; }

        public string Name { set; get; }
        
        

        public int MaHPN { set; get; }

        public List<string> Roles { set; get; }

        public int MaCD { set; get; }
        public string Anh { set; get; }

        //public string TokenAccess { set; get; }
    }
}