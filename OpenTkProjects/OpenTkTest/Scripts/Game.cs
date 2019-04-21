using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTkTest.Scripts;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using OpenTK.Input;

namespace OpenTkTest
{
    internal class Game : GameWindow
    {
        int vbo;
        int VertexArrayObject;
        private Shader shader;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(.9f, .9f, 0.9f, 1.0f);

            float[] vertices = {
                -0.5f, -0.5f, 0.0f, //Bottom-left vertex
                0.5f, -0.5f, 0.0f, //Bottom-right vertex
                0.0f,  0.5f, 0.0f  //Top vertex
            };

            VertexArrayObject = GL.GenBuffer();
            GL.bind

            shader = new Shader("shader.vert", "shader.frag");

            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0,3,VertexAttribPointerType.Float,false,3*sizeof(float),0 );
            GL.EnableVertexAttribArray(0);
            
            shader.Use();


        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);


            Context.SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(vbo);
            shader.Dispose();
        }
    }
}
