// See https://aka.ms/new-console-template for more information

using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenTKWindow
{
    internal class Program
    {
        public class Game : GameWindow
        {
            private float frameTime = 0.0f;
            private int fps = 0;

            public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
                    : base(gameWindowSettings, nativeWindowSettings)
            {
                Console.WriteLine(GL.GetString(StringName.Version));
                Console.WriteLine(GL.GetString(StringName.Vendor));
                Console.WriteLine(GL.GetString(StringName.Renderer));
                Console.WriteLine(GL.GetString(StringName.ShadingLanguageVersion));

                VSync = VSyncMode.On;
            }

            protected override void OnLoad()
            {
                base.OnLoad();

                GL.ClearColor(Color4.LightGray);
                GL.Clear(ClearBufferMask.ColorBufferBit);
            }
            protected override void OnResize(ResizeEventArgs e)
            {
                GL.Viewport(0, 0, Size.X, Size.Y);
                base.OnResize(e);
            }

            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                frameTime += (float)e.Time;
                fps++;
                if (frameTime >= 1.0f)
                {
                    Title = $"OpenTk Flag   FPS - {fps}";
                    frameTime = 0.0f;
                    fps = 0;
                }

                base.OnUpdateFrame(e);
                //      Keyboard
                KeyboardState input = KeyboardState;
                if (input.IsKeyDown(Keys.Escape))
                {
                    Console.WriteLine("Has been closed by user");
                    Close();
                }
            }
            protected override void OnRenderFrame(FrameEventArgs e)
            {
                drawFlag();

                SwapBuffers();
                base.OnRenderFrame(e);
            }
            protected override void OnUnload()
            {
                base.OnUnload();
            }
            private void drawFlag()
            {
                GL.Clear(ClearBufferMask.ColorBufferBit);

                GL.Color3(1.0f, 0.0f, 0.0f);

                GL.Begin(PrimitiveType.Triangles);
                //  (AEB) Triangle Blue
                GL.Color3(0 / 255.0f, 63 / 255.0f, 135 / 255.0f);
                GL.Vertex2(-1.0f, -1.0f);
                GL.Vertex2(-0.2f, 1.0f);
                GL.Vertex2(-1.0f, 1.0f);
                //  (AGE) Triangle Yellow
                GL.Color3(252 / 255.0f, 216 / 255.0f, 86 / 255.0f);
                GL.Vertex2(-1.0f, -1.0f);
                GL.Vertex2(0.4f, 1.0f);
                GL.Vertex2(-0.2f, 1.0f);
                //  (AHG) Triangle Red first
                GL.Color3(214 / 255.0f, 40 / 255.0f, 40 / 255.0f);
                GL.Vertex2(-1.0f, -1.0f);
                GL.Vertex2(1.0f, 0.4f);
                GL.Vertex2(0.4f, 1.0f);
                //  (HCG) Triangle Red second
                GL.Color3(214 / 255.0f, 40 / 255.0f, 40 / 255.0f);
                GL.Vertex2(1.0f, 0.4f);
                GL.Vertex2(1.0f, 1.0f);
                GL.Vertex2(0.4f, 1.0f);
                //  (AFH) Triangle White
                GL.Color3(255 / 255.0f, 255 / 255.0f, 255 / 255.0f);
                GL.Vertex2(-1.0f, -1.0f);
                GL.Vertex2(1.0f, -0.4f);
                GL.Vertex2(1.0f, 0.4f);
                //  (ADF) Triangle Green
                GL.Color3(0 / 255.0f, 122 / 255.0f, 61 / 255.0f);
                GL.Vertex2(-1.0f, -1.0f);
                GL.Vertex2(1.0f, -1.0f);
                GL.Vertex2(1.0f, -0.4f);

                GL.End();
            }
        }

        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 400),
                Location = new Vector2i(400, 200),
                WindowBorder = WindowBorder.Resizable,
                WindowState = WindowState.Normal,
                Title = "OpenTK     Starting",

                Flags = ContextFlags.Default,     // Forward
                API = ContextAPI.OpenGL,
                APIVersion = new Version(4, 6),
                Profile = ContextProfile.Compatability,

                NumberOfSamples = 0
            };

            using (Game game = new Game(GameWindowSettings.Default, nativeWindowSettings))
            {
                game.Run();
            }
        }

    }
}
