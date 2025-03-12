using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QLTK_Nro_Pro
{
    public partial class Form1 : Form
    {
        public static string string_0 = Path.Combine(Path.GetTempPath(), "koi occtiu957", "mod 222");
        public static string string_1 = Path.Combine(string_0, "data");
        public static bool bool_0;
        public static string string_3 = "Data\\version.ini";

        public static string filePath = "Data\\size.ini";
        public static string ChatPublic = "Data\\TextChatPublic.ini";
        public static string ChatGlobal = "Data\\TextChatGlobal.ini";
        public static string ChatInbox = "Data\\TextChatInbox.ini";
        public static string nro244 = Path.Combine(Application.StartupPath, "Nro_244.exe");
        public static string nro222 = "Data\\Version222\\Dragonboy_vn_v222.exe";
        public static string NameWindownro244 = "ragonboy244";
        public static string NameWindownro222 = "Dragonboy222";


        public Form1()
        {
            InitializeComponent();
        }
        private int indexSTT = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Path.Combine(Path.GetTempPath(), "koi occtiu957", "mod 222")))
            {
                Directory.CreateDirectory((Path.Combine(Path.GetTempPath(), "koi occtiu957", "mod 222")));
                if (!File.Exists(string_1))
                {
                    File.Create(string_1).Close();
                }
            }
            string version = File.ReadAllText(string_3);
            if (version.Equals("222"))
            {
                cbbVersion.SelectedIndex = 0;
            }
            else
            {
                cbbVersion.SelectedIndex = 1;
            }
            try
            {
                string[] a = File.ReadAllText(filePath).Split('|');
                txtX.Text = a[0];
                txtY.Text = a[1];
            }
            catch { }
            try
            {
                txtPublic.Text = File.ReadAllText(ChatPublic);
                txtInbox.Text = File.ReadAllText(ChatInbox);
                txtGlobal.Text = File.ReadAllText(ChatGlobal);
            }
            catch
            {

            }
            
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            docFile();
            
        }
        private void docFile()
        {
            if (!File.Exists(string_1))
            {
                File.Create(string_1).Close();
            }
            try
            {
                indexSTT = dataGridView1.RowCount;
                string[] a = File.ReadAllLines(string_1);
                for (int i = 0; i < a.Length; i++)
                {
                    string[] b = a[i].Split('|');

                    dataGridView1.Rows.Add(new object[]{
                    b[0],
                   b[1],
                   b[2],
                    b[3],
                    b[4],
                });
                    indexSTT++;

                }
            }
            catch { }
        }
        public static string smethod_2(string str, string key)
        {
            byte[] array = Convert.FromBase64String(str);
            byte[] key2 = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(key));
            byte[] bytes = new TripleDESCryptoServiceProvider
            {
                Key = key2,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            }.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
            return Encoding.UTF8.GetString(bytes);
        }
        public void ghifile(DataGridView gridView)
        {
            if(gridView.RowCount > 0)
            {
                String Text = "";
                for (int i = 0; i < gridView.Rows.Count; i++)
                {
                    Text += i + "|" +
                            gridView.Rows[i].Cells[1].Value.ToString() + "|" +
                            gridView.Rows[i].Cells[2].Value.ToString() + "|" +
                            gridView.Rows[i].Cells[3].Value.ToString() + "|" +
                            gridView.Rows[i].Cells[4].Value.ToString();
                    if (i != gridView.Rows.Count - 1)
                    {
                        Text += '\n';
                    }
                }
                File.WriteAllText(string_1, Text);
            }
        }

        public string Reserver(int x)
        {
            if (x == 13)
            {
                return "Võ đài liên vũ trụ[13]";
            }
            if (x == 14)
            {
                return "Universe1 (14)";
            }
            if (x == 15)
            {
                return "Naga [15]";
            }
            if (x == 16)
            {
                return "Super 1 [16]";
            }
            if (x == 17)
            {
                return "Super 2 [17]";
            }
            if (x == 18)
            {
                return "13 [18]";
            }
            if (x == 19)
            {
                return "VIP 2 [19]";
            }
            if (x == 20)
            {
                return "14 [20]";
            }
            return x.ToString();
        }
        public int server (string x)
        {
            if (x.Equals("Võ đài liên vũ trụ [13]"))
            {
                return 13;
            }
            if (x.Equals("Universe1 (14)"))
            {
                return 14;
            }
            if (x.Equals("Naga [15]"))
            {
                return 15;
            }
            if (x.Equals("Super 1 [16]"))
            {
                return 16;
            }
            if (x.Equals("Super 2 [17]"))
            {
                return 17;
            }
            if (x.Equals("13 [18]"))
            {
                return 18;
            }
            if (x.Equals("VIP 2 [19]"))
            {
                return 19;
            }
            if (x.Equals("14 [20]"))
            {
                return 20;
            }
            return int.Parse(x);
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_user.Text) || string.IsNullOrEmpty(txt_server.Text) || string.IsNullOrEmpty(txt_password.Text))
            {
                MessageBox.Show("Nhập đầy đủ vào rồi thêm cục cưng ", "Thông báo",MessageBoxButtons.OK);
                txt_user.Focus();
                return;
            }
            dataGridView1.Rows.Add(new object[]
            {
                indexSTT,
                    txt_user.Text,
                    server(txt_server.Text),
                    smethod_1(txt_password.Text, "ud"),
                    txt_note.Text,
                    
                });
            indexSTT++;
            ghifile(dataGridView1);
            txt_user.Clear();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentCell != null && dataGridView1.RowCount > 1)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(index);
                ghifile(dataGridView1);
                dataGridView1.Rows.Clear();
            }
            else if (dataGridView1.RowCount == 1)
            {
                dataGridView1.Rows.Clear();
                File.WriteAllText(string_1, string.Empty);
            }

            docFile();
        }


        public static string smethod_1(string string_5, string string_6)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(string_5);
            byte[] key = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(string_6));
            byte[] array = new TripleDESCryptoServiceProvider
            {
                Key = key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            }.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            return Convert.ToBase64String(array, 0, array.Length);
        }
        private static List<IntPtr> gameWindows = new List<IntPtr>();
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        public void SortWindows()
        {
            int num = 0;  // Vị trí cột
            int num1 = 0; // Vị trí dòng

            foreach (IntPtr hWnd in gameWindows)
            {
                if (hWnd != IntPtr.Zero)
                {
                    // Lấy kích thước gốc của cửa sổ
                    if (GetWindowRect(hWnd, out RECT rect))
                    {
                        int width = rect.Right - rect.Left;
                        int height = rect.Bottom - rect.Top;

                        int x = width * num;
                        if (x + width > Screen.PrimaryScreen.Bounds.Width)
                        {
                            x = 0;
                            num = 0;
                            num1 += height;
                        }

                        MoveWindow(hWnd, x, num1, width, height, true);
                        num++;
                    }
                }
            }
        }

        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        [DllImport("user32.dll")]
        private static extern bool SetWindowText(IntPtr hWnd, string windowName);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int SizeW, int SizeH, bool Repaint);
        public static void smethod_3(int int_0, string PathGame, string nameWindowGame)
        {
            if (!bool_0)
            {
                bool_0 = true;
                Process.Start(arguments: File.ReadAllLines(string_1)[int_0 - 1], fileName: PathGame);
                Thread.Sleep(200);
                IntPtr hWnd = FindWindow(null, nameWindowGame);


                if (hWnd != IntPtr.Zero)
                {
                    SetWindowText(hWnd, "ID: " + (int_0 -1).ToString()+ " Cuong Le");
                    gameWindows.Add(hWnd);
                }
                bool_0 = false;
            }
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string pathGame1 = nro222;
            string nameWindowGame1 = NameWindownro222;
            if (cbbVersion.SelectedIndex == 1)
            {
                pathGame1 = nro244;
                nameWindowGame1 = NameWindownro244;
            }
            if (e.RowIndex >= 0)
            {
                Thread.Sleep(500);
                try
                {
                    int index = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    smethod_3(index + 1, pathGame1, nameWindowGame1);
                }
                catch
                {
                }

            }
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            if (check.Checked)
            {
                txt_password.PasswordChar = '\0';
            }
            if (check.Checked == false)
            {
                txt_password.PasswordChar = '*';
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_user.Text) || string.IsNullOrEmpty(txt_server.Text) || string.IsNullOrEmpty(txt_password.Text))
            {
                MessageBox.Show("Nhập đầy đủ vào rồi thêm cục cưng ", "Thông báo", MessageBoxButtons.OK);
                return;
            }

                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value = txt_user.Text;
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value = smethod_1(txt_password.Text, "ud");
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value = server(txt_server.Text);
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value = txt_note.Text;
            ghifile(dataGridView1);

                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK);
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
                txt_user.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_server.Text = Reserver(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
            txt_password.Text = smethod_2(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),"ud");
            txt_note.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Nro_244");
            if (process.Length == 0)
            {
                MessageBox.Show("Đã tắt hết toàn bộ Tab game rồi mà :(", "Cường có điều muốn nói", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            foreach (Process item in process)
            {
                item.Kill();

            }
        }

       
        private void btn_sapXep_Click(object sender, EventArgs e)
        {
            if(int.Parse(txtX.Text) > 720 && int.Parse(txtY.Text) > 320)
            {
                MessageBox.Show("Yêu cầu kích thước game phải nhỏ hơn 720 x 320 để tránh lỗi", "Thông báo");
                return;
            }
            SortWindows();
        }
        private void nextMap (int x)
        {
            File.WriteAllText("Data/LoadMap.ini", "T|"+ x.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            nextMap(44);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nextMap(14);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            nextMap(15);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            nextMap(16);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            nextMap(17);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            nextMap(18);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            nextMap(20);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            nextMap(19);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            nextMap(35);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            nextMap(36);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            nextMap(37);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            nextMap(38);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            nextMap(52);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            nextMap(26);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            nextMap(129);
        }

        private void button95_Click(object sender, EventArgs e)
        {
            nextMap(113);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            nextMap(42);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            nextMap(0);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            nextMap(1);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            nextMap(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nextMap(3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nextMap(4);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            nextMap(5);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            nextMap(6);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            nextMap(27);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            nextMap(28);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            nextMap(29);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            nextMap(30);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            nextMap(47);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            nextMap(24);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            nextMap(46);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            nextMap(45);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            nextMap(48);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            nextMap(43);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            nextMap(7);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            nextMap(8);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            nextMap(12);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            nextMap(11);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            nextMap(13);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            nextMap(10);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            nextMap(31);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            nextMap(32);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            nextMap(33);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            nextMap(34);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            nextMap(25);
        }

        private void button60_Click(object sender, EventArgs e)
        {
            nextMap(68);
        }

        private void button59_Click(object sender, EventArgs e)
        {
            nextMap(69);
        }

        private void button58_Click(object sender, EventArgs e)
        {
            nextMap(70);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            nextMap(71);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            nextMap(72);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            nextMap(64);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            nextMap(65);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            nextMap(63);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            nextMap(66);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            nextMap(67);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            nextMap(73);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            nextMap(74);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            nextMap(75);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            nextMap(76);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            nextMap(77);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            nextMap(81);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            nextMap(82);
        }

        private void button61_Click(object sender, EventArgs e)
        {
            nextMap(83);
        }

        private void button66_Click(object sender, EventArgs e)
        {
            nextMap(79);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            nextMap(80);
        }

        private void button78_Click(object sender, EventArgs e)
        {
            nextMap(102);
        }

        private void button77_Click(object sender, EventArgs e)
        {
            nextMap(92);
        }

        private void button76_Click(object sender, EventArgs e)
        {
            nextMap(93);
        }

        private void button75_Click(object sender, EventArgs e)
        {
            nextMap(94);
        }

        private void button64_Click(object sender, EventArgs e)
        {
            nextMap(96);
        }

        private void button74_Click(object sender, EventArgs e)
        {
            nextMap(97);
        }

        private void button72_Click(object sender, EventArgs e)
        {
            nextMap(98);
        }

        private void button71_Click(object sender, EventArgs e)
        {
            nextMap(99);
        }

        private void button70_Click(object sender, EventArgs e)
        {
            nextMap(100);
        }

        private void button69_Click(object sender, EventArgs e)
        {
            nextMap(103);
        }

        private void button90_Click(object sender, EventArgs e)
        {
            nextMap(109);
        }

        private void button89_Click(object sender, EventArgs e)
        {
            nextMap(108);
        }

        private void button88_Click(object sender, EventArgs e)
        {
            nextMap(107);
        }

        private void button87_Click(object sender, EventArgs e)
        {
            nextMap(110);
        }

        private void button86_Click(object sender, EventArgs e)
        {
            nextMap(106);
        }

        private void button85_Click(object sender, EventArgs e)
        {
            nextMap(105);
        }

        private void button98_Click(object sender, EventArgs e)
        {
            nextMap(131);
        }

        private void button97_Click(object sender, EventArgs e)
        {
            nextMap(132);
        }

        private void button96_Click(object sender, EventArgs e)
        {
            nextMap(133);
        }

        private void button73_Click(object sender, EventArgs e)
        {
            nextMap(53);
        }

        private void button84_Click(object sender, EventArgs e)
        {
            nextMap(58);
        }

        private void button80_Click(object sender, EventArgs e)
        {
            nextMap(59);
        }

        private void button83_Click(object sender, EventArgs e)
        {
            nextMap(60);
        }

        private void button79_Click(object sender, EventArgs e)
        {
            nextMap(61);
        }

        private void button92_Click(object sender, EventArgs e)
        {
            nextMap(62);
        }

        private void button82_Click(object sender, EventArgs e)
        {
            nextMap(55);
        }

        private void button91_Click(object sender, EventArgs e)
        {
            nextMap(56);
        }

        private void button81_Click(object sender, EventArgs e)
        {
            nextMap(54);
        }

        private void button93_Click(object sender, EventArgs e)
        {
            nextMap(57);
        }

        private void button94_Click(object sender, EventArgs e)
        {
            nextMap(84);
        }

        private void button67_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Data/LoadMap.ini", "F|-1");
            MessageBox.Show("Đã Khôi phục NextMap khắc phục lỗi", "Thông báo");
        }

        private void btnUpdateSize_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtX.Text) || string.IsNullOrEmpty(txtY.Text))
            {
                MessageBox.Show("Nhập đầy đủ kích thước theo chiều ngang và chiều dọc","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            File.WriteAllText(filePath, txtX.Text + '|' + txtY.Text + '|' + '0');
            MessageBox.Show("Đã cập nhập kích thước game thành công", "Thông báo");

        }

        private void button68_Click(object sender, EventArgs e)
        {
            File.WriteAllText(ChatGlobal, txtGlobal.Text);
            File.WriteAllText(ChatPublic, txtPublic.Text);
            File.WriteAllText(ChatInbox, txtInbox.Text);
            MessageBox.Show("Đã cập nhập nội dung chat thành công", "Thông báo");
        }

        private void button99_Click(object sender, EventArgs e)
        {
            nextMap(-99);
        }

        private void btnfb_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/cuongle1002/");
        }

        private void btnZaloSuper2_Click(object sender, EventArgs e)
        {
            Process.Start("https://zalo.me/g/axbwpn039");
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            using (WebClient webClient = new WebClient())
            {
                if (!webClient.DownloadString("https://www.dropbox.com/scl/fi/0iacu1ujg30nbl7suncea/checkVersionNro.txt?rlkey=7vcuj3zim83gvviimg8k26ns5&st=2g41ahjg&dl=1").Contains("1.2"))
                {
                    if (MessageBox.Show("Đã có phiên bản mới. Bạn có muốn cập nhập không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Process.Start("https://drive.google.com/drive/u/0/folders/1-FQLm1txnoQcAtvkl27g7Osed58yRSgL");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi update:  " + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Đang là phiên bản mới nhất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

        }

        private void btnUpdateVersionNro_Click(object sender, EventArgs e)
        {
            if(cbbVersion.SelectedIndex == 0)
            {
                File.WriteAllText(string_3, "222");
                MessageBox.Show("Bạn đã chọn " + cbbVersion.Text + " làm phiên bản login", "Thông báo");
            }
            else
            {
                File.WriteAllText(string_3, "244");
                MessageBox.Show("Bạn đã chọn " + cbbVersion.Text + " làm phiên bản login", "Thông báo");
            }
        }
    }

    
}