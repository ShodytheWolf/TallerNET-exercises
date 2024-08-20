using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineExercise.Pipeline.PipelineImpl
{
    internal class PruebaStep2 : IStep{

        public void Process(IContext context){

            Console.WriteLine(((PruebaContext)context).TextoPrueba);
        }
    }
}
