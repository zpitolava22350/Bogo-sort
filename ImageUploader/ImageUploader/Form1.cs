using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Drawing.Imaging;

namespace ImageUploader {
    public partial class Form1: Form {

        TcpClient client;

        public Form1() {
            InitializeComponent();
            pbx_Image.AllowDrop = true;
        }

        private void pbx_Image_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1) {
                string filePath = files[0];
                pbx_Image.Image = Image.FromFile(filePath);
            }
        }

        private void pbx_Image_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                // Get the dragged file(s)
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                // Check if the file has the ".nbs" extension
                if (files.Length == 1 && (Path.GetExtension(files[0]).Equals(".png", StringComparison.OrdinalIgnoreCase) || Path.GetExtension(files[0]).Equals(".jpg", StringComparison.OrdinalIgnoreCase))) {
                    e.Effect = DragDropEffects.Copy; // Allow drop
                } else {
                    e.Effect = DragDropEffects.None; // Disallow drop
                }
            } else {
                e.Effect = DragDropEffects.None; // Disallow drop
            }
        }

        private async void btn_Connect_Click(object sender, EventArgs e) {
            string address = tbx_IP.Text;
            int port;

            if (int.TryParse(tbx_Port.Text, out port)) {
                client = new TcpClient();
                btn_Connect.Enabled = false;
                tbx_IP.Enabled = false;
                tbx_Port.Enabled = false;
                await client.ConnectAsync(address, port);
                btn_Upload.Enabled = true;
            }
        }

        /// <summary>
        /// Sends image as stream
        /// 4 bytes for length
        /// 'length' bytes for the image
        /// </summary>
        /// <param name="client">The client to send stream to</param>
        /// <param name="image">Image to send</param>
        void SendImage(TcpClient client, Image image) {
            NetworkStream stream = client.GetStream();
            using MemoryStream ms = new MemoryStream();

            // Convert image to PNG or JPEG bytes
            image.Save(ms, ImageFormat.Png);
            byte[] imgBytes = ms.ToArray();

            // Send the length first (4 bytes, little-endian)
            byte[] lengthBytes = BitConverter.GetBytes(imgBytes.Length);
            stream.Write(lengthBytes, 0, lengthBytes.Length);

            // Then send the image bytes
            stream.Write(imgBytes, 0, imgBytes.Length);
        }

        private void btn_Upload_Click(object sender, EventArgs e) {
            if (pbx_Image.Image != null) {
                SendImage(client, pbx_Image.Image);
            }
        }
    }
}
