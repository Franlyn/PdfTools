using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTools.Models
{
    public enum LayoutType
    {
        [Description("One Per Page")]
        onePerPage = 0,
        [Description("Append")]
        appendNaturally = 1
    }
}
