using ImageProcessor;
using ImageProcessor.Imaging.Filters.Photo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualSign.Business
{
  class ImageProcessing
  {
    ImageFactory _imageFactory;
    public ImageProcessing() {
      _imageFactory = new ImageFactory();
    }
    public Bitmap ConvertToGrayscale(Bitmap img)
    {
      _imageFactory.Load(img);
      _imageFactory.Filter(MatrixFilters.BlackWhite);
      return _imageFactory.Image as Bitmap;
    }
  }
}
