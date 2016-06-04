using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux.MvcCore.Learn.DDL.BindingModel
{
    public class AllStatisticsBindingModel
    {
        public AllStatisticsBindingModel()
        {
            TagThreshold = 1;
        }

        public int TagThreshold { get; set; }
    }
}
