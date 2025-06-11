using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graduation
{
    public partial class Form2 : Form
    {
        private string streamUrl = "https://len-among-collectibles-pos.trycloudflare.com/";

        public Form2()
        {
            InitializeComponent();
            StartStreaming();
        }

        private async void StartStreaming()
        {
            await Task.Run(() => MJPEGStreamLoop());
        }

        private void MJPEGStreamLoop()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(streamUrl);
                request.Timeout = 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();

                byte[] boundary = System.Text.Encoding.ASCII.GetBytes("--frame");
                MemoryStream imageStream = new MemoryStream();

                byte[] buffer = new byte[4096];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    imageStream.Write(buffer, 0, bytesRead);

                    byte[] imgBytes = ExtractJpeg(imageStream);
                    if (imgBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            Image image = Image.FromStream(ms);
                            pictureBox1.Invoke((MethodInvoker)(() =>
                            {
                                pictureBox1.Image?.Dispose();
                                pictureBox1.Image = new Bitmap(image);
                            }));
                        }
                        imageStream.SetLength(0);  // Clear stream for next image
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("스트리밍 중 오류 발생: " + ex.Message);
            }
        }

        // JPEG 헤더와 EOI (0xFFD9)를 이용해 완전한 JPEG 이미지 추출
        private byte[] ExtractJpeg(MemoryStream ms)
        {
            byte[] buffer = ms.ToArray();
            int start = FindStartOfImage(buffer);
            int end = FindEndOfImage(buffer, start);

            if (start != -1 && end != -1 && end > start)
            {
                int length = end - start + 2;
                byte[] jpeg = new byte[length];
                Array.Copy(buffer, start, jpeg, 0, length);
                return jpeg;
            }
            return null;
        }

        private int FindStartOfImage(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length - 1; i++)
            {
                if (buffer[i] == 0xFF && buffer[i + 1] == 0xD8)
                    return i;
            }
            return -1;
        }

        private int FindEndOfImage(byte[] buffer, int start)
        {
            for (int i = start + 2; i < buffer.Length - 1; i++)
            {
                if (buffer[i] == 0xFF && buffer[i + 1] == 0xD9)
                    return i + 1;
            }
            return -1;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox1.Image?.Dispose();
        }
    }
}