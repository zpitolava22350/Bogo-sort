using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace bogosort {
    public partial class Form1: Form {

        TcpListener listener;

        CancellationTokenSource cancel;
        CancellationTokenSource cancelListener;

        private void CreateServer() {
            listener = new TcpListener(IPAddress.Any, 25566);
            cancelListener = new CancellationTokenSource();
            cancel = new CancellationTokenSource();
            listener.Start();
            ListenForConnections();
        }

        async private void ListenForConnections() {
            while (!cancelListener.IsCancellationRequested) {

                try {
                    TcpClient temp = await listener.AcceptTcpClientAsync(cancelListener.Token);
                    temp.NoDelay = true;

                    cancel.Cancel();
                    cancel.Dispose();
                    cancel = new CancellationTokenSource();

                    HandleClientAsync(temp, cancel.Token);
                }
                catch (OperationCanceledException) { break; }
                catch (Exception ex) {
                    Debug.WriteLine($"Exception in ListenForConnections:\n{ex.Message}");
                }

            }
        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken) {

            try {
                using NetworkStream stream = client.GetStream();

                while (true) {
                    // 1. Read 4-byte length (async)
                    byte[] lengthBytes = new byte[4];
                    int readLen = 0;

                    while (readLen < 4) {
                        int lenRead = await stream.ReadAsync(lengthBytes, readLen, 4 - readLen, cancellationToken);
                        if (lenRead == 0) throw new IOException("Connection closed while reading length");
                        readLen += lenRead;
                    }
                    int length = BitConverter.ToInt32(lengthBytes, 0);

                    // 2. Read image bytes (async)
                    byte[] imgBytes = new byte[length];
                    int read = 0;
                    while (read < length) {
                        int bytesRead = await stream.ReadAsync(imgBytes, read, length - read, cancellationToken);
                        if (bytesRead == 0) throw new IOException("Connection closed while reading image");
                        read += bytesRead;
                    }
                    // 3. Convert and display image
                    using MemoryStream ms = new MemoryStream(imgBytes);
                    Image image = Image.FromStream(ms);
                    // Use Invoke if you're not on the UI thread
                    pbx_Slop.Invoke(() => pbx_Slop.Image = image);

                }
            } catch (OperationCanceledException) {
                //Debug.WriteLine("DIE!!!!!!!!!  (handler canceled)");
            } catch (IOException ioex) {
                //Debug.WriteLine("DIE!!!!!!!!!  (IO error: " + ioex.Message + ")");
            } catch (Exception ex) {
                //Debug.WriteLine("DIE!!!!!!!!!  (unexpected: " + ex.Message + ")");
            } finally {
                client.Close();
            }

        }

    }
}
