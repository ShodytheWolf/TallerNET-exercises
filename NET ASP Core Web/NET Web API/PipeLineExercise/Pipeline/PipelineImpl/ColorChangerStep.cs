using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineExercise.Pipeline.PipelineImpl
{

    internal class ColorChangerStep : IStep{


        public void Process(IContext context)
        {
            //acá ocurren los poderes.
            //llamamos a la función ColorReplace con la imagen previamente guardada, la tolerancia, color a reemplazar y color reemplazado
            ((ImageContext)context).SavedImage = ColorReplace(((ImageContext)context).SavedImage, 100, Color.Orange, Color.Blue);
        }


        //esta función esta copiada *tal cual* del siguiente Stack Overflow:
        // https://stackoverflow.com/questions/9871262/replace-color-in-an-image-in-c-sharp
        public Image ColorReplace( Image inputImage, int tolerance, Color oldColor, Color NewColor)
            {
                
                Bitmap outputImage = new Bitmap(inputImage.Width, inputImage.Height);
                Graphics G = Graphics.FromImage(outputImage);
                G.DrawImage(inputImage, 0, 0);
                for (Int32 y = 0; y < outputImage.Height; y++)
                    for (Int32 x = 0; x < outputImage.Width; x++)
                    {
                        Color PixelColor = outputImage.GetPixel(x, y);
                        if (PixelColor.R > oldColor.R - tolerance && PixelColor.R < oldColor.R + tolerance && PixelColor.G > oldColor.G - tolerance && PixelColor.G < oldColor.G + tolerance && PixelColor.B > oldColor.B - tolerance && PixelColor.B < oldColor.B + tolerance)
                        {
                            int RColorDiff = oldColor.R - PixelColor.R;
                            int GColorDiff = oldColor.G - PixelColor.G;
                            int BColorDiff = oldColor.B - PixelColor.B;

                            if (PixelColor.R > oldColor.R) RColorDiff = NewColor.R + RColorDiff;
                            else RColorDiff = NewColor.R - RColorDiff;
                            if (RColorDiff > 255) RColorDiff = 255;
                            if (RColorDiff < 0) RColorDiff = 0;
                            if (PixelColor.G > oldColor.G) GColorDiff = NewColor.G + GColorDiff;
                            else GColorDiff = NewColor.G - GColorDiff;
                            if (GColorDiff > 255) GColorDiff = 255;
                            if (GColorDiff < 0) GColorDiff = 0;
                            if (PixelColor.B > oldColor.B) BColorDiff = NewColor.B + BColorDiff;
                            else BColorDiff = NewColor.B - BColorDiff;
                            if (BColorDiff > 255) BColorDiff = 255;
                            if (BColorDiff < 0) BColorDiff = 0;

                            outputImage.SetPixel(x, y, Color.FromArgb(RColorDiff, GColorDiff, BColorDiff));
                        }
                    }
                return outputImage;
            }



    }



}
