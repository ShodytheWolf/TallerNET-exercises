using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineExercise.Pipeline.PipelineImpl
{
    internal class ImageSaverStep: IStep{

        public void Process(IContext context)
        {
            int c = 0;
            while (true)//itero hasta que encuentre un nombre de archivo que no haya sido usado
            {
                //pregunto si existe algún archivo "output" que esté concatenado con el valor de la variable c
                if (!File.Exists(@"C:\Users\shodyWindows\Documents\GitHub\TallerNET-exercises\NET ASP Core Web\NET Web API\PipeLineExercise\OutPuts\output" + c + ((ImageContext)context).ImageExtension))
                {
                    break; //si no lo encuentro, salgo del loop
                }
                c++;
            }
            //guardo la imagen al directorio específicado, concatenando el valor de la variable c, más el formato original de la imágen
            ((ImageContext)context).SavedImage.Save(@"C:\Users\shodyWindows\Documents\GitHub\TallerNET-exercises\NET ASP Core Web\NET Web API\PipeLineExercise\OutPuts\output" + c + ((ImageContext)context).ImageExtension);

        }
    }
}
