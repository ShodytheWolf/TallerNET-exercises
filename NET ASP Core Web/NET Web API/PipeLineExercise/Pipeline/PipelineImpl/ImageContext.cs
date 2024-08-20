using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineExercise.Pipeline.PipelineImpl
{
    internal class ImageContext : IContext{
        public Image? SavedImage { set; get; }
        public string? ImagePath { set; get; }
        public string? ImageExtension { set; get; }
    }
}
