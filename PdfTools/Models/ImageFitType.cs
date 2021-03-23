using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTools.Models
{
    public enum ImageFitType
    {
        // The replaced content is sized to fill the element’s content box. 
        // The entire object will completely fill the box. 
        // If the object's aspect ratio does not match the aspect ratio of its box, then the object will be stretched to fit.
        [Description("Stretch to fit")]
        fill = 0,
        // The replaced content is scaled to maintain its aspect ratio 
        // while fitting within the element’s content box. 
        // The entire object is made to fill the box, while preserving its aspect ratio, 
        // so the object will be "letterboxed" if its aspect ratio does not match the aspect ratio of the box.
        [Description("Preserve the aspect ratio")]
        contain = 1
    }
}
