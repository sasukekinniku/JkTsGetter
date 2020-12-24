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
    public partial class FormMain : Form
    {
        readonly string GetterExeName = "JkTsGetter";

        public FormMain()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.JkTsGetterTool;

            pictureBox1.Image = Properties.Resources.JkTsGetterTool.ToBitmap();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var ch in JkTsGetter.Channel.Channels)
            {
                comboChannels.Items.Add(ch.name);
            }

            comboChannels.SelectedIndex = 0;

            var now = DateTime.Now;
            now.AddHours(-4);
            dateStartDate.Value = dateStartTime.Value = dateEndDate.Value = dateEndTime.Value = dateTimeShiftDate.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            System.Diagnostics.FileVersionInfo ver =
                System.Diagnostics.FileVersionInfo.GetVersionInfo(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            labelAbout.Text = $"{ver.ProductName} {ver.ProductVersion}";
        }

        private void buttonStartDateMinus7_Click(object sender, EventArgs e)
        {
            dateStartDate.Value = dateStartDate.Value.AddDays(-7);
        }

        private void buttonEndDateMinus7_Click(object sender, EventArgs e)
        {
            dateStartDate.Value = dateStartDate.Value.AddDays(7);
        }
        private void AddMinutes(DateTimePicker date, DateTimePicker time, int minutes)
        {
            int day = time.Value.Day;
            time.Value = time.Value.AddMinutes(minutes);
            date.Value = date.Value.AddDays(day != time.Value.Day ? 1 : 0);
        }

        private void buttonDateCopy_Click(object sender, EventArgs e)
        {
            dateEndDate.Value = dateStartDate.Value;
            dateEndTime.Value = dateStartTime.Value;
            AddMinutes(dateEndDate, dateEndTime, 30);
        }

        private void buttonEndPlus1h_Click(object sender, EventArgs e)
        {
            AddMinutes(dateEndDate, dateEndTime, 60);
        }

        private void buttonEndPlus30m_Click(object sender, EventArgs e)
        {
            AddMinutes(dateEndDate, dateEndTime, 30);
        }

        private void buttonSaveToFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textSaveTo.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textSaveTo.Text = saveFileDialog.FileName;
            }
        }


        private void buttonTimeShiftSaveToFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textTimeShiftSaveTo.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonTimeShiftSaveToFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textTimeShiftSaveTo.Text = saveFileDialog.FileName;
            }
        }

        private bool OverWriteCheck(string fileName)
        {
            if (System.IO.File.Exists(fileName))
            {
                if (MessageBox.Show(this, fileName + " はすでに存在します。\r\n\r\n上書きしてもよろしいですか?", "コメントファイル上書きの確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        private void buttonPastLogDownload_Click(object sender, EventArgs e)
        {
            string fileName = textSaveTo.Text;
            if (!OverWriteCheck(fileName)) { return; }

            JkTsGetter.Channel channel = JkTsGetter.Channel.Channels[comboChannels.SelectedIndex];
            string param = $"jk{channel.jk} {dateStartDate.Value.ToString("yyyyMMdd")}{dateStartTime.Value.ToString("HHmmss")} {dateEndDate.Value.ToString("yyyyMMdd")}{dateEndTime.Value.ToString("HHmmss")}";
            if (!string.IsNullOrEmpty(fileName))
            {
                param += $" -f \"{fileName}\"";
            }
            if (checkBoxAlwaysAPI.Checked)
            {
                param += " -api";
            }

            var formExecute = new FormExecute();
            formExecute.Execute(this, GetterExeName, param);
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            //コントロール内にドラッグされたとき実行される
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                if (System.IO.Path.GetExtension(fileName[0]).ToLower() == ".ts")
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //コントロール内にドロップされたとき実行される
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            JkTsGetter.Common.TsAnalyzer.GetTsFileInfo(fileName[0], out int jk, out DateTime? startTime, out DateTime? endTime);
            if (startTime != null)
            {
                comboChannels.SelectedIndex = JkTsGetter.Channel.GetIndex(jk);

                if (tabControlMain.SelectedTab == tabPagePastLog)
                {
                    dateStartDate.Value = startTime.Value;
                    dateStartTime.Value = startTime.Value;
                    dateEndDate.Value = endTime.Value;
                    dateEndTime.Value = endTime.Value;
                    textSaveTo.Text = System.IO.Path.ChangeExtension(fileName[0], "xml");
                }
                else if (tabControlMain.SelectedTab == tabPageTimeShift)
                {
                    dateTimeShiftDate.Value = startTime.Value;
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void buttonTimeShiftDownload_Click(object sender, EventArgs e)
        {
            string fileName = textTimeShiftSaveTo.Text;
            if (!OverWriteCheck(fileName)) { return; }

            JkTsGetter.Channel channel = JkTsGetter.Channel.Channels[comboChannels.SelectedIndex];
            string param = $"jk{channel.jk} {dateTimeShiftDate.Value.ToString("yyyyMMdd")} -ts";
            if (!string.IsNullOrEmpty(fileName))
            {
                param += $" -f \"{fileName}\"";
            }

            var formExecute = new FormExecute();
            formExecute.Execute(this, GetterExeName, param);
        }

        private void buttonTimeShiftAlllDownload_Click(object sender, EventArgs e)
        {
            string fileName = textTimeShiftSaveTo.Text;
            if (!OverWriteCheck(fileName)) { return; }

            string param = $"-all";
            if (checkTimeShiftSubFolder.Checked)
            {
                param += " -d";
            }
            if (!checkTimeShiftOverwrite.Checked)
            {
                param += " -v";
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                param += $" -f \"{fileName}\"";
            }

            var formExecute = new FormExecute();
            formExecute.Execute(this, GetterExeName, param);
        }

        private void buttonOpenNicoJkTop_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://jk.nicovideo.jp/");
        }

        private void buttonOpenChannelTop_Click(object sender, EventArgs e)
        {
            JkTsGetter.Channel channel = JkTsGetter.Channel.Channels[comboChannels.SelectedIndex];
            if (channel.ch == 0)
            {
                return;
            }
            System.Diagnostics.Process.Start("https://ch.nicovideo.jp/jk" + channel.jk.ToString());
        }

        private void buttonOpenChannelLive_Click(object sender, EventArgs e)
        {
            JkTsGetter.Channel channel = JkTsGetter.Channel.Channels[comboChannels.SelectedIndex];
            if (channel.ch == 0)
            {
                return;
            }
            System.Diagnostics.Process.Start("https://live.nicovideo.jp/watch/ch" + channel.ch.ToString());
        }

        private void buttonOpenTimeShiftBrowser_Click(object sender, EventArgs e)
        {
            var date = new DateTime(dateStartDate.Value.Year, dateStartDate.Value.Month, dateStartDate.Value.Day, dateStartTime.Value.Hour, dateStartTime.Value.Minute, dateStartTime.Value.Second);
            var today = date.AddHours(-4);
            JkTsGetter.Channel channel = JkTsGetter.Channel.Channels[comboChannels.SelectedIndex];
            if (channel.ch == 0)
            {
                return;
            }
            var liveInfo = JkTsGetter.Util.GetTimeShiftItem(channel, today.Year, today.Month, today.Day);
            if (liveInfo == null)
            {
                MessageBox.Show(this, "指定した日の生放送はありません");
                return;
            }
            if (liveInfo.category == "past")
            {
                System.Diagnostics.Process.Start(liveInfo.link + $"#{today.Hour}:{today.Minute}:{today.Second}");
            }
            else
            {
                System.Diagnostics.Process.Start(liveInfo.link);
            }
        }

        private void buttonOpenGitHub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/sasukekinniku/JkTsGetter");
        }

        private void buttonJkTsGetterAbout_Click(object sender, EventArgs e)
        {
            var formExecute = new FormExecute();
            formExecute.Execute(this, GetterExeName, "");
        }

        private void buttonTimeShiftUpdateCache_Click(object sender, EventArgs e)
        {
            var formExecute = new FormExecute();
            formExecute.Execute(this, GetterExeName, "-all -cache");
        }

        private void buttonToolXml1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textToolXml1.Text = openFileDialog.FileName;
            }
        }

        private void buttonToolXml2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textToolXml2.Text = openFileDialog.FileName;
            }
        }

        private void buttonToolSaveTo_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textToolSaveTo.Text = saveFileDialog.FileName;
            }
        }

        private void buttonToolMerge_Click(object sender, EventArgs e)
        {
            string fileName = textToolSaveTo.Text;
            if (!OverWriteCheck(fileName)) { return; }

            string param = $"{textToolXml1.Text} {textToolXml2.Text} -merge";
            if (!string.IsNullOrEmpty(fileName))
            {
                param += $" -f \"{fileName}\"";
            }

            var formExecute = new FormExecute();
            formExecute.Execute(this, GetterExeName, param);
        }

        private void textToolXml1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            //コントロール内にドラッグされたとき実行される
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void textToolXml1_DragDrop(object sender, DragEventArgs e)
        {
            //コントロール内にドロップされたとき実行される
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            ((TextBox)sender).Text = fileName[0];
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = tabControlMain.SelectedIndex;
            AllowDrop = (index == 0 || index == 1);
            textToolXml1.AllowDrop = textToolXml2.AllowDrop = (index == 2);
        }

        private void dateStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (checkDateAutoCopy.Checked)
            {
                buttonDateCopy_Click(sender, e);
            }
        }

        private void checkDateAutoCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDateAutoCopy.Checked)
            {
                buttonDateCopy_Click(sender, e);
            }
        }

        private void comboChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            JkTsGetter.Channel channel = JkTsGetter.Channel.Channels[comboChannels.SelectedIndex];
            buttonOpenTimeShiftBrowser.Enabled = buttonTimeShiftDownload.Enabled = buttonOpenChannelTop.Enabled = buttonOpenChannelLive.Enabled = (channel.ch > 0);
        }

        private void textSaveTo_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            //コントロール内にドラッグされたとき実行される
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //コントロール内にドロップされたとき実行される
                string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                string[] acceptExts = { ".xml", ".nicojk", ".jkl", ".txt" };

                if (System.IO.Directory.Exists(fileName[0]) || Array.IndexOf(acceptExts, System.IO.Path.GetExtension(fileName[0]).ToLower()) >= 0)
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void textSaveTo_DragDrop(object sender, DragEventArgs e)
        {
            //コントロール内にドロップされたとき実行される
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            ((TextBox)sender).Text = fileName[0];
        }
    }
}
