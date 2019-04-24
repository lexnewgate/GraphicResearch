using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace OpenTkTest.Scripts
{
    class Texture
    {
        private int Handle;

        public Texture(string path)
        {
            Handle = GL.GenTexture();

            Image<Rgba32> image = Image.Load(path);
            image.Mutate(x=>x.Flip(FlipMode.Vertical));
            Rgba32[] tempPixels = image.GetPixelSpan().ToArray();
            List<byte>pixels=new List<byte>();
            foreach (var tempPixel in tempPixels)
            {
                pixels.Add(tempPixel.R);
                pixels.Add(tempPixel.G);
                pixels.Add(tempPixel.B);
                pixels.Add(tempPixel.A);
            }
        }

        public void Use()
        {
            GL.BindTexture(TextureTarget.Texture2D,Handle);
        }


    }
}
