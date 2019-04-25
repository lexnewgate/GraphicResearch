using System;
using OpenTkTest.Scripts;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;

namespace OpenTkTest
{
    internal class Game : GameWindow
    {
        private int _vbo;
        private int _vao;
        private int _ebo;
        private Shader _shader;


        private readonly float[] _vertices = {
            0f,  0f, 0.0f,  // top right
            0.5f, -0.5f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,  // bottom left
            -0.5f,  0.5f, 0.0f   // top left
        };

        private readonly uint[] _indices = {  // note that we start from 0!
            0,// 1, 3,   // first triangle
            //1, 2, 3    // second triangle
        };
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(.9f, .9f, 0.9f, 1.0f);
            GL.PointSize(600);

            //ebo
            _ebo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer,_ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer,_indices.Length*sizeof(uint),_indices,BufferUsageHint.StaticDraw);

            //vbo
            _vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            //shader
            _shader = new Shader("shader.vert", "shader.frag");

            //bind vao
            _vao = GL.GenVertexArray();
            GL.BindVertexArray(_vao);
            GL.VertexAttribPointer(0,3,VertexAttribPointerType.Float,false,3*sizeof(float),0 );
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer,_vbo);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer,_ebo);
            GL.BindVertexArray(0);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.BindVertexArray(_vao);
            _shader.Use();
            //GL.DrawElements(PrimitiveType.Triangles,_indices.Length,DrawElementsType.UnsignedInt,0);

            //GL.DrawElements(PrimitiveType.Points,_indices.Length,DrawElementsType.UnsignedInt,0);
            GL.DrawElements(PrimitiveType.Points,_indices.Length,DrawElementsType.UnsignedInt,0);
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
            // Unbind all the resources by binding the targets to 0/null.
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer,0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);


            // Delete all the resources.
            GL.DeleteBuffer(_vbo);
            GL.DeleteVertexArray(_vao);
            GL.DeleteBuffer(_ebo);

            _shader.Dispose();
        }
    }
}
