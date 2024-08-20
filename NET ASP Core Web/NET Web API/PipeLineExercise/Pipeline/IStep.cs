using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineExercise.Pipeline
{
    //En la implementación de esta interfaz es donde ejecutaremos los pasos
    internal interface IStep{

        
        public void Process(IContext context) { } 
    }
}
