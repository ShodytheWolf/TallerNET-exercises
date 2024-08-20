using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineExercise.Pipeline.PipelineImpl
{
    internal class PruebaStep : IStep {

        public void Process(IContext context)
        {
            ((PruebaContext)context).TextoPrueba = "algo";
        }
    }
}
