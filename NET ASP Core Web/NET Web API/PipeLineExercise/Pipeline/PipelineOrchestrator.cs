using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineExercise.Pipeline
{
    internal class PipelineOrchestrator{

        private List<IStep> _steps;
        private IContext _context;

        public PipelineOrchestrator(IContext context)
        {
            _steps = new List<IStep>();
            _context = context;
        }

        public void addStep(IStep step)
        {
            _steps.Add(step);
        }


        public void execute()
        {
            Console.WriteLine("Arranca el pipeline orchestrator!");

            int c = 1;
            foreach (IStep step in _steps) {
                
                Console.WriteLine("Ejecutando paso N° " + c);

                step.Process(_context);
                c++;
            }
            Console.WriteLine("SE ACABO PIPELINE!!!");
        }

    }
}
