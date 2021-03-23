using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTools.Models
{
    public enum PaperSizeType
    {
        [Description("US Letter")]
        usLetter = 0,
        [Description("A4")]
        a4 = 1
    }
}
