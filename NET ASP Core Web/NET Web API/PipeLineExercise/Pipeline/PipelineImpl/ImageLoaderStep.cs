using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineExercise.Pipeline.PipelineImpl
{
    internal class ImageLoaderStep: IStep{

        public void Process (IContext context)
        {
            //aquí guardamos en contexto el path en donde se encuentra nuestra imagen
            ((ImageContext)context).ImagePath = @"C:\Users\shodyWindows\Documents\GitHub\TallerNET-exercises\NET ASP Core Web\NET Web API\PipeLineExercise\test3.jpg";
            
            //sacamos el tipo de extensión del archivo que acabamos de cargar
            ((ImageContext)context).ImageExtension = Path.GetExtension(((ImageContext)context).ImagePath);

            //nos aseguramos que NO sea WEBP (tira exception Out of Memory cuando se trabaja con WEBP específicamente) 
            if ( ((ImageContext)context).ImageExtension.Equals(".webp") )
            {
                throw new Exception("Este código no soporta webp");
            }


            try
            {
                //inténtamos guardar la imágen
                ((ImageContext)context).SavedImage = Image.FromFile(((ImageContext)context).ImagePath);
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo cargar la imagen correctamente, razón: " + e.InnerException.Message);

            }
        }
    }
}
