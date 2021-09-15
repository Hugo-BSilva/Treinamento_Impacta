using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDapper.Utils
{
    static class DataExtensions
    {
        public static string FormatarDataSistema(this DateTime data)
        {
            return data.Month + "/" + data.Year;
        }
    }
}
