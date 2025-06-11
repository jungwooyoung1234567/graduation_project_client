namespace Graduation
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Windows.Forms;
    using System.Net.Http;

    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        private TcpClient tcpClient;
        private NetworkStream networkStream;

        public Form1()
        {
            InitializeComponent();

            this.BackgroundImage = Image.FromFile("C:\\Users\\zzung\\source\\repos\\Graduation\\Graduation\\bin\\Debug\\mornitoring.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // 📤 버튼 클릭 시 문자열을 서버로 전송
        private async void SendDataToServerAsync(string data)
        {
            var content = new StringContent($"{data}", Encoding.UTF8, "application/json");

            try
            {
                await client.PostAsync("http://10.220.4.212:8080/receive", content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e) => SendDataToServerAsync("00");
        private void button2_Click(object sender, EventArgs e) => SendDataToServerAsync("01");
        private void button3_Click(object sender, EventArgs e) => SendDataToServerAsync("03");
        private void button4_Click(object sender, EventArgs e) => SendDataToServerAsync("02");
        private void button5_Click(object sender, EventArgs e) => SendDataToServerAsync("13");
        private void button6_Click(object sender, EventArgs e) => SendDataToServerAsync("12");
        private void button7_Click(object sender, EventArgs e) => SendDataToServerAsync("14");
        private void button8_Click(object sender, EventArgs e) => SendDataToServerAsync("21");

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }


        private void ConnectToServer()
        {
            try
            {
                tcpClient = new TcpClient("10.220.4.212", 1234);
                networkStream = tcpClient.GetStream();
                MessageBox.Show("서버에 연결되었습니다.");
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"소켓 오류: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"서버 연결 실패: {ex.Message}");
            }
        }
    }
}