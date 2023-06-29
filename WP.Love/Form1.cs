using System.Diagnostics;

namespace WP.Love
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 同意点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("哈哈, 我就知道你会同意的 ~");
            MessageBox.Show("恭喜你获得男朋友一只!");
            MessageBox.Show("微信发送“我愿意”即可获得解锁指令!");
        }

        /// <summary>
        /// 不同意点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("不能拒绝!");
            MessageBox.Show("拒绝无效!");
        }

        /// <summary>
        /// 鼠标进入控件可见部分时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            // 获取 x y 坐标
            int x = this.ClientSize.Width - pictureBox3.Width;
            int y = this.ClientSize.Height - pictureBox3.Height;
            // 定义随机数
            Random random = new Random();
            pictureBox3.Location = new Point(random.Next(0, x + 1), random.Next(0, y + 1));
        }

        /// <summary>
        /// 窗体关闭之前执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("不回答我就不能退出哦");
            e.Cancel = true;
        }

        /// <summary>
        /// 计时器, 定时关闭任务管理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 获取系统运行的进程
            Process[] p = Process.GetProcesses();
            foreach (Process item in p)
            {
                try
                {
                    // 如果进程中存在名称为 taskmgr, 则说明我们的任务管理器已经打开
                    var name = item.ProcessName.ToLower().Trim();
                    if (name == "taskmgr" || name == "cmd")
                    {
                        // 关闭当前这个任务管理器
                        item.Kill();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    break;
                }

            }
        }

        /// <summary>
        /// 后门, 通过组合键关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ALT + X 组合键, 关闭应用
            if (e.Alt && e.KeyCode == Keys.X)
            {
                this.Dispose();
            }
        }
    }
}