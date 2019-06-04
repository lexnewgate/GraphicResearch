namespace PPMWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            var ppmWriter=new PPMWriter(2,2);
            ppmWriter.WritePixel(0,0,255,0,0);
            ppmWriter.WritePixel(1,0,0,255,0);
            ppmWriter.WritePixel(0,1,0,0,255);
            ppmWriter.WritePixel(1,1,0,0,0);
            ppmWriter.Output("2");
        }
    }
}
