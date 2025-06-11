using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Graduation
{
    public partial class Form3 : Form
    {
        private WaveInEvent waveIn;
        private MemoryStream recordedStream;
        private HttpListener httpListener;
        private WaveOutEvent outputDevice;  // 클래스 필드로 선언

        public Form3()
        {
            InitializeComponent();
            StartHttpListener(); // 🔁 클라이언트 수신용 서버 시작
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recordedStream = new MemoryStream();
            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(44100, 1); // 44.1kHz, mono

            var writer = new WaveFileWriter(new IgnoreDisposeStream(recordedStream), waveIn.WaveFormat);

            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
            };

            waveIn.RecordingStopped += async (s, a) =>
            {
                writer.Dispose();
                waveIn.Dispose();

                recordedStream.Position = 0;
                await SendAudioToServer(recordedStream.ToArray());
            };

            waveIn.StartRecording();

            // ✅ 3초 후 자동 종료
            Task.Delay(1000).ContinueWith(t => waveIn.StopRecording());
        }

        private async Task SendAudioToServer(byte[] audioData)
        {
            using (var client = new HttpClient())
            {
                var content = new ByteArrayContent(audioData);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/wav");

                try
                {
                    var response = await client.PostAsync("http://127.0.0.1:12345/audio", content);
                    string result = await response.Content.ReadAsStringAsync();

                    if (result.Trim() == "OK")
                    {
                        MessageBox.Show("🎉 전송 완료!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"전송 실패: {ex.Message}");
                }
            }
        }

        private void StartHttpListener()
        {
            Task.Run(() =>
            {
                httpListener = new HttpListener();
                httpListener.Prefixes.Add("http://+:5000/receive/");
                httpListener.Start();

                while (true)
                {
                    try
                    {
                        var context = httpListener.GetContext();
                        using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                        {
                            string data = reader.ReadToEnd();
                            if (data.Trim() == "11111")
                            {
                                Invoke((MethodInvoker)(() => PlaySiren()));
                            }
                        }

                        byte[] responseBuffer = Encoding.UTF8.GetBytes("OK");
                        context.Response.OutputStream.Write(responseBuffer, 0, responseBuffer.Length);
                        context.Response.Close();
                    }
                    catch (Exception ex)
                    {
                        // 로그 출력 등
                        Console.WriteLine("Listener 오류: " + ex.Message);
                    }
                }
            });
        }

        private void PlaySiren()
        {
            try
            {
                var audioFile = new AudioFileReader(@"C:\Users\zzung\OneDrive\바탕 화면\사이렌소리.mp3");
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사이렌 재생 실패: {ex.Message}");
            }
        }

        private class IgnoreDisposeStream : Stream
        {
            private Stream innerStream;
            public IgnoreDisposeStream(Stream stream) { innerStream = stream; }
            public override bool CanRead => innerStream.CanRead;
            public override bool CanSeek => innerStream.CanSeek;
            public override bool CanWrite => innerStream.CanWrite;
            public override long Length => innerStream.Length;
            public override long Position { get => innerStream.Position; set => innerStream.Position = value; }
            public override void Flush() => innerStream.Flush();
            public override int Read(byte[] buffer, int offset, int count) => innerStream.Read(buffer, offset, count);
            public override long Seek(long offset, SeekOrigin origin) => innerStream.Seek(offset, origin);
            public override void SetLength(long value) => innerStream.SetLength(value);
            public override void Write(byte[] buffer, int offset, int count) => innerStream.Write(buffer, offset, count);
            protected override void Dispose(bool disposing) { /* 무시 */ }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (outputDevice != null)
                {
                    outputDevice.Stop();       // 🔇 재생 중단
                    outputDevice.Dispose();    // 💥 자원 해제
                    outputDevice = null;       // 🔁 다음 재생을 위한 초기화
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사이렌 중단 실패: {ex.Message}");
            }
        }
    }
}
