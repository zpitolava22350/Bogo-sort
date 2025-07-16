using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OpenTK.Graphics.OpenGL4;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Haukcode.HighResolutionTimer;

namespace bogosort {
    public partial class Form1: Form {

        HighResolutionTimer timer;
        int items;
        Stopwatch sw;
        int iterations;
        int bestScore;

        private readonly SynchronizationContext _uiContext;
        private readonly Action _postTick;
        object threadlock = new object();

        int loaded = 0;

        public Form1() {
            InitializeComponent();

            _uiContext = SynchronizationContext.Current!;
            _postTick = () => _uiContext.Post(_ => OnTimerTick(), null);

            timer = new HighResolutionTimer();

            StartWorker();

            CreateServer();

            glControl1.Paint += GlControl1_Paint;
            glControl1.Load += GlControl_Load;
            glControl1.Resize += GlControl1_Resize;

            glControl2.Paint += GlControl2_Paint;
            glControl2.Load += GlControl_Load;
            glControl2.Resize += GlControl2_Resize;
        }

        private void StartWorker() {
            var worker = new Thread(() => {
                try {
                    while (true) {
                        timer.WaitForTrigger();
                        lock (threadlock) {
                            // Marshal the tick call to the main thread
                            _postTick();
                        }
                    }
                } catch (ThreadAbortException) {
                    // clean exit
                }
            }) {
                IsBackground = true,
                Name = "HighResTimerWorker"
            };
            worker.Start();
        }

        private void OnTimerTick() {
            Candidate c = new Candidate(items);
            iterations++;
            lbl_Iterations.Text = $"{iterations} iterations";

            if(iterations % 16 == 0) {
                c.Show();
                lbl_SortTime.Text = $"{sw.Elapsed.Hours:D2}:{sw.Elapsed.Minutes:D2}:{sw.Elapsed.Seconds:D2}.{sw.Elapsed.Milliseconds:D3}";
            }

            if(c.Score < bestScore) {
                bestScore = c.Score;
                c.ShowBest();
                lbl_PointsOff.Text = $"{bestScore} points off";
                lbl_WhenBestIteration.Text = $"Achieved on iteration {iterations}";
            }

            if (c.Score == 0) {
                sw.Stop();

                lbx_PreviousSorts.Items.Add($"{items}x - {sw.Elapsed.Hours:D2}:{sw.Elapsed.Minutes:D2}:{sw.Elapsed.Seconds:D2}.{sw.Elapsed.Milliseconds:D3} - {iterations} iterations");

                items++;
                iterations = 0;
                bestScore = int.MaxValue;

                lbl_Items.Text = $"Sorting {items} items";
                lbl_PointsOff.Text = $"";
                lbl_WhenBestIteration.Text = $"";
                lbl_SortTime.Text = $"";

                sw.Restart();
            }
        }

        private void GlControl1_Paint(object? sender, PaintEventArgs e) {
            if (!glControl1.Context.IsCurrent)
                glControl1.MakeCurrent();

            glControl1.SwapBuffers();
        }
        private void GlControl2_Paint(object? sender, PaintEventArgs e) {
            if (!glControl2.Context.IsCurrent)
                glControl2.MakeCurrent();

            glControl2.SwapBuffers();
        }

        private void GlControl1_Resize(object? sender, EventArgs e) {
            if (!glControl1.Context.IsCurrent)
                glControl1.MakeCurrent();

            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
        }
        private void GlControl2_Resize(object? sender, EventArgs e) {
            if (!glControl2.Context.IsCurrent)
                glControl2.MakeCurrent();

            GL.Viewport(0, 0, glControl2.Width, glControl2.Height);
        }

        private void GlControl_Load(object? sender, EventArgs e) {
            loaded++;
            if(loaded == 2) {
                Candidate.SetControl(glControl1, glControl2);
                Start();
            }
        }

        

        

        public void Start() {
            iterations = 0;
            items = 3;
            bestScore = int.MaxValue;
            lbl_Items.Text = $"Sorting {items} items";

            sw = Stopwatch.StartNew();

            timer.SetPeriod(1);
            timer.Start();
        }

    }
}
