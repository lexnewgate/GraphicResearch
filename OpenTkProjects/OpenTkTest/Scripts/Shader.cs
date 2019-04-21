using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace OpenTkTest.Scripts
{
    public class Shader
    {
        int Handle;

        private string ShaderFolderName = "Shaders";

        public Shader(string vertexfn, string fragmentfn)
        {
            int vertexShader;
            int fragShader;

            string VertexShaderSource;

            using (StreamReader reader = new StreamReader(Path.Combine(ShaderFolderName,vertexfn),Encoding.UTF8))
            {
                VertexShaderSource = reader.ReadToEnd();
            }

            string FragmentShaderSource;

            using (StreamReader reader = new StreamReader(Path.Combine(ShaderFolderName,fragmentfn) , Encoding.UTF8))
            {
                FragmentShaderSource = reader.ReadToEnd();
            }

            vertexShader= GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, VertexShaderSource);

            fragShader= GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragShader, FragmentShaderSource);

            GL.CompileShader(vertexShader);

            string infoLogVert = GL.GetShaderInfoLog(vertexShader);
            if (infoLogVert != System.String.Empty)
                System.Console.WriteLine(infoLogVert);

            GL.CompileShader(fragShader);

            string infoLogFrag = GL.GetShaderInfoLog(fragShader);

            if (infoLogFrag != System.String.Empty)
                System.Console.WriteLine(infoLogFrag);

            Handle = GL.CreateProgram();

            GL.AttachShader(Handle, vertexShader);
            GL.AttachShader(Handle, fragShader);

            GL.LinkProgram(Handle);

            GL.DetachShader(Handle, vertexShader);
            GL.DetachShader(Handle, fragShader);
            GL.DeleteShader(fragShader);
            GL.DeleteShader(vertexShader);
        }

        void Use()
        {
            GL.UseProgram(Handle);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(Handle);

                disposedValue = true;
            }
        }

        ~Shader()
        {
            GL.DeleteProgram(Handle);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
