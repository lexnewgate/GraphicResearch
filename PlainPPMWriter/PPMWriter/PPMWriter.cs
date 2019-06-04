using System.Collections.Generic;
using System.IO;

namespace PPMWriter
{

    //ref: http://netpbm.sourceforge.net/doc/ppm.html
    class PPMWriter
    {
        //todo
        //write comments #
        // no line should longer than 70

        //write header plain format is P3
        private const string Header = "P3";

        //max color value less than 65536
        private const string MaxColor = "255";
        private readonly int _width;
        private readonly int _height;

        private readonly string []_pixels;

        public PPMWriter(int width, int height)
        {
            this._width = width;
            this._height = height;
            this._pixels=new string[width*height];
        }

        public void WritePixel(int x, int y, int r, int g, int b)
        {
            int index = x + this._width * (_height-y-1);
            _pixels[index] = $"{r} {g} {b}";
        }

        public void Output(string fp)
        {
            var ppmContents = new List<string> {Header, $"{_width} {_height}", MaxColor};
            ppmContents.AddRange(_pixels);
            if (Path.GetExtension(fp) != "ppm")
            {
                fp = $"{fp}.ppm";
            }
            File.WriteAllLines(fp, ppmContents);
        }
    }
}
