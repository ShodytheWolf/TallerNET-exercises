using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineExercise.Pipeline.PipelineImpl
{
    internal class PruebaContext : IContext
    {
        public string TextoPrueba { set; get; }

        public PruebaContext(string prueba) { 
            TextoPrueba = prueba;
        }
    }
}
