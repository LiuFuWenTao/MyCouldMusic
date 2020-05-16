using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Model
{
    public class MusicTpyeModel
    {
        public int Code { get; set; }
        public AllModel ALL { get; set; }


        public List<AllModel> Sub { get; set; }
        public Dictionary<string,string> Categories { get; set; }


    }
}
