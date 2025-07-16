using OpenTK.GLControl;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bogosort {
    internal class Candidate {

        static Random rnd = new Random();

        static GLControl Control;

        static GLControl BestControl;

        static Shader ShowCandidate;
        static Shader ShowCandidateBest;

        public static void SetControl(GLControl control, GLControl bestcontrol) {
            Control = control;
            BestControl = bestcontrol;

            Control.MakeCurrent();

            GL.Viewport(0, 0, Control.Width, Control.Height);
            GL.ClearColor(0f, 0f, 0f, 1f);
            Control.SwapBuffers();

            ShowCandidate = new Shader("Shaders/vertex.vert", "Shaders/fragment.frag");
            ShowCandidate.Use();


            BestControl.MakeCurrent();

            GL.Viewport(0, 0, BestControl.Width, BestControl.Height);
            GL.ClearColor(0f, 0f, 0f, 1f);
            BestControl.SwapBuffers();

            ShowCandidateBest = new Shader("Shaders/vertex.vert", "Shaders/fragment.frag");
            ShowCandidateBest.Use();
        }

        byte[] items;
        public int Score;

        public Candidate(int itemcount) {

            // Fill array
            items = new byte[itemcount];
            for(byte i=0; i<itemcount; i++) {
                items[i] = i;
            }

            // Shuffle & Score
            Score = 0;
            for (int i = items.Length - 1; i >= 0; i--) {
                int num = rnd.Next(i+1);
                (items[i], items[num]) = (items[num], items[i]);
                Score += Math.Abs(items[i] - i);
            }

            //Debug.WriteLine($"Score: {Score}");
        }

        public void Show() {

            Control.MakeCurrent();
            GL.Viewport(0, 0, Control.Width, Control.Height);
            ShowCandidate.Use();

            // 1. Create VAO and bind
            int VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            // 2. Create VBO, bind, and upload data
            int VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            float[] vertices = getVertices();
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            // 3. Tell VAO how to interpret the VBO
            GL.EnableVertexAttribArray(0); // Position
            GL.VertexAttribPointer(
                index: 0, // (location = 0)
                size: 3,  // (x, y, z)
                type: VertexAttribPointerType.Float,
                normalized: false,
                stride: 12, // 3 * sizeof(float)
                offset: 0);

            // 4. Unbind VBO
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            // 5. Render
            GL.Clear(ClearBufferMask.ColorBufferBit);
            ShowCandidate.Use();
            GL.BindVertexArray(VAO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length / 3);
            GL.BindVertexArray(0);

            // 6. Show on screen
            Control.SwapBuffers(); // already swaps buffers

            // DISPOSE OF EVERYTHING
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteVertexArray(VAO);
            GL.DeleteBuffer(VBO);

        }

        public void ShowBest() {

            BestControl.MakeCurrent();
            GL.Viewport(0, 0, BestControl.Width, BestControl.Height);
            ShowCandidateBest.Use();

            // 1. Create VAO and bind
            int VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            // 2. Create VBO, bind, and upload data
            int VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            float[] vertices = getVertices();
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            // 3. Tell VAO how to interpret the VBO
            GL.EnableVertexAttribArray(0); // Position
            GL.VertexAttribPointer(
                index: 0, // (location = 0)
                size: 3,  // (x, y, z)
                type: VertexAttribPointerType.Float,
                normalized: false,
                stride: 12, // 3 * sizeof(float)
                offset: 0);

            // 4. Unbind VBO
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            // 5. Render
            GL.Clear(ClearBufferMask.ColorBufferBit);
            ShowCandidateBest.Use();
            GL.BindVertexArray(VAO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length / 3);
            GL.BindVertexArray(0);

            // 6. Show on screen
            BestControl.SwapBuffers(); // already swaps buffers

            // DISPOSE OF EVERYTHING
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteVertexArray(VAO);
            GL.DeleteBuffer(VBO);

        }

        private float[] getVertices() {

            float[] vertices = new float[items.Length * 18];

            float thickness = 2f / items.Length * 0.8f;
            float distance = 2f / items.Length;
            float offset = 2f / items.Length * 0.1f;

            for (int i=0; i<items.Length; i++) {
                Array.Copy(new float[] { 
                    -1 + (i*distance) + offset, -1 + ((items[i] * 2f + 1f)/items.Length), 0f,
                    -1 + (i*distance + thickness) + offset, -1 + ((items[i] * 2f + 1f)/items.Length), 0f,
                    -1 + (i*distance) + offset, -1, 0f,
                    -1 + (i*distance + thickness) + offset, -1 + ((items[i] * 2f + 1f)/items.Length), 0f,
                    -1 + (i*distance + thickness) + offset, -1, 0f,
                    -1 + (i*distance) + offset, -1, 0f
                }, 0, vertices, i * 18, 18);
            }

            return vertices;
        }

    }
}
