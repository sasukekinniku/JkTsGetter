using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JkTsGetterTool
{
    public partial class FormExecute : Form
    {
        System.Diagnostics.Process _executing = null;
        bool _closed = false;

        public FormExecute()
        {
            InitializeComponent();
        }

        public void Execute(IWin32Window owner, string command, string param)
        {
            Show(owner);
            textBoxLogs.AppendText($"> {command} {param}\r\n\r\n");

            //エントリポイント
            //Processオブジェクトを作成
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            //出力とエラーをストリームに書き込むようにする
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.EnableRaisingEvents = true;
            //OutputDataReceivedとErrorDataReceivedイベントハンドラを追加
            p.OutputDataReceived += p_OutputDataReceived;
            p.ErrorDataReceived += p_ErrorDataReceived;
            p.Exited += p_Exited;

            p.StartInfo.FileName = command;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = param;

            //起動
            p.Start();
            _executing = p;

            //非同期で出力とエラーの読み取りを開始
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
        }

        //OutputDataReceivedイベントハンドラ
        //行が出力されるたびに呼び出される
        void p_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (e.Data == null) { return; }

            if (textBoxLogs.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => textBoxLogs.AppendText(e.Data + "\r\n")));
            }
            else
            {
                textBoxLogs.AppendText(e.Data + "\r\n");
            }
        }

        //ErrorDataReceivedイベントハンドラ
        void p_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (e.Data == null) { return; }

            if (textBoxLogs.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => textBoxLogs.AppendText(e.Data + "\r\n")));
                this.Invoke((MethodInvoker)(() => _executing = null));
            }
            else
            {
                textBoxLogs.AppendText(e.Data + "\r\n");
            }
        }

        void p_Exited(object sender, EventArgs e)
        {
            if (_closed) { return; }

            _executing?.WaitForExit();

            string str = "[ 完了しました ]";
            if (((System.Diagnostics.Process)sender).ExitCode != 0)
            {
                str = "[ うまくいかなったようです ]";
            }
            if (textBoxLogs.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => textBoxLogs.AppendText("\r\n" + str + "\r\n")));
                this.Invoke((MethodInvoker)(() => _executing = null));
            }
            else
            {
                textBoxLogs.AppendText("\r\n" + str + "\r\n");
                _executing.Exited -= p_Exited;
                _executing = null;
            }
        }

        private void FormExecute_FormClosed(object sender, FormClosedEventArgs e)
        {
            _closed = true;

            if (_executing != null)
            {
                _executing.Exited -= p_Exited;
                _executing.Kill();
                _executing = null;
            }
        }

        private void FormExecute_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_executing != null)
            {
                if (MessageBox.Show(this, "まだ処理中です。この処理を中断しますか?", "処理ウインドウ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
