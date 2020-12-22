
namespace JkTsGetterTool
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelChannel = new System.Windows.Forms.Label();
            this.comboChannels = new System.Windows.Forms.ComboBox();
            this.labelDateStart = new System.Windows.Forms.Label();
            this.dateStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateStartTime = new System.Windows.Forms.DateTimePicker();
            this.buttonStartDateMinus7 = new System.Windows.Forms.Button();
            this.buttonEndDateMinus7 = new System.Windows.Forms.Button();
            this.buttonDateCopy = new System.Windows.Forms.Button();
            this.checkDateAutoCopy = new System.Windows.Forms.CheckBox();
            this.dateEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonEndPlus30m = new System.Windows.Forms.Button();
            this.buttonEndPlus1h = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPagePastLog = new System.Windows.Forms.TabPage();
            this.buttonOpenTimeShiftBrowser = new System.Windows.Forms.Button();
            this.checkBoxAlwaysAPI = new System.Windows.Forms.CheckBox();
            this.buttonSaveToFolder = new System.Windows.Forms.Button();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.textSaveTo = new System.Windows.Forms.TextBox();
            this.labelSaveTo = new System.Windows.Forms.Label();
            this.buttonPastLogDownload = new System.Windows.Forms.Button();
            this.tabPageTimeShift = new System.Windows.Forms.TabPage();
            this.checkTimeShiftOverwrite = new System.Windows.Forms.CheckBox();
            this.labelSeparator = new System.Windows.Forms.Label();
            this.checkTimeShiftSubFolder = new System.Windows.Forms.CheckBox();
            this.buttonTimeShiftSaveToFolder = new System.Windows.Forms.Button();
            this.buttonTimeShiftSaveToFile = new System.Windows.Forms.Button();
            this.textTimeShiftSaveTo = new System.Windows.Forms.TextBox();
            this.labelTimeShiftSaveTo = new System.Windows.Forms.Label();
            this.buttonTimeShiftAlllDownload = new System.Windows.Forms.Button();
            this.buttonTimeShiftDownload = new System.Windows.Forms.Button();
            this.labelTimeShiftDate = new System.Windows.Forms.Label();
            this.dateTimeShiftDate = new System.Windows.Forms.DateTimePicker();
            this.tabPageEtc = new System.Windows.Forms.TabPage();
            this.labelAbout = new System.Windows.Forms.Label();
            this.buttonJkTsGetterAbout = new System.Windows.Forms.Button();
            this.buttonOpenGitHub = new System.Windows.Forms.Button();
            this.buttonOpenChannelLive = new System.Windows.Forms.Button();
            this.buttonOpenChannelTop = new System.Windows.Forms.Button();
            this.buttonOpenNicoJkTop = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.labelSeparator2 = new System.Windows.Forms.Label();
            this.buttonTimeShiftUpdateCache = new System.Windows.Forms.Button();
            this.tabPageTool = new System.Windows.Forms.TabPage();
            this.textToolXml1 = new System.Windows.Forms.TextBox();
            this.labelToolXml1 = new System.Windows.Forms.Label();
            this.textToolXml2 = new System.Windows.Forms.TextBox();
            this.labelToolXml2 = new System.Windows.Forms.Label();
            this.textToolSaveTo = new System.Windows.Forms.TextBox();
            this.labelToolSaveTo = new System.Windows.Forms.Label();
            this.buttonToolXml1 = new System.Windows.Forms.Button();
            this.buttonToolXml2 = new System.Windows.Forms.Button();
            this.buttonToolSaveTo = new System.Windows.Forms.Button();
            this.buttonToolMerge = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPagePastLog.SuspendLayout();
            this.tabPageTimeShift.SuspendLayout();
            this.tabPageEtc.SuspendLayout();
            this.tabPageTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.Location = new System.Drawing.Point(14, 19);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(71, 15);
            this.labelChannel.TabIndex = 0;
            this.labelChannel.Text = "チャンネル(&C)";
            // 
            // comboChannels
            // 
            this.comboChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChannels.FormattingEnabled = true;
            this.comboChannels.Location = new System.Drawing.Point(119, 16);
            this.comboChannels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboChannels.Name = "comboChannels";
            this.comboChannels.Size = new System.Drawing.Size(225, 23);
            this.comboChannels.TabIndex = 1;
            this.comboChannels.SelectedIndexChanged += new System.EventHandler(this.comboChannels_SelectedIndexChanged);
            // 
            // labelDateStart
            // 
            this.labelDateStart.AutoSize = true;
            this.labelDateStart.Location = new System.Drawing.Point(14, 25);
            this.labelDateStart.Name = "labelDateStart";
            this.labelDateStart.Size = new System.Drawing.Size(73, 15);
            this.labelDateStart.TabIndex = 0;
            this.labelDateStart.Text = "開始日時(&S)";
            // 
            // dateStartDate
            // 
            this.dateStartDate.CustomFormat = "yyyy年MM月dd日    ";
            this.dateStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartDate.Location = new System.Drawing.Point(103, 19);
            this.dateStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateStartDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateStartDate.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            this.dateStartDate.Name = "dateStartDate";
            this.dateStartDate.Size = new System.Drawing.Size(130, 23);
            this.dateStartDate.TabIndex = 1;
            this.dateStartDate.ValueChanged += new System.EventHandler(this.dateStartDate_ValueChanged);
            // 
            // dateStartTime
            // 
            this.dateStartTime.CustomFormat = "HH:mm:ss";
            this.dateStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartTime.Location = new System.Drawing.Point(239, 19);
            this.dateStartTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateStartTime.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateStartTime.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            this.dateStartTime.Name = "dateStartTime";
            this.dateStartTime.ShowUpDown = true;
            this.dateStartTime.Size = new System.Drawing.Size(75, 23);
            this.dateStartTime.TabIndex = 2;
            this.dateStartTime.Value = new System.DateTime(2020, 12, 19, 0, 0, 0, 0);
            this.dateStartTime.ValueChanged += new System.EventHandler(this.dateStartDate_ValueChanged);
            // 
            // buttonStartDateMinus7
            // 
            this.buttonStartDateMinus7.Location = new System.Drawing.Point(103, 49);
            this.buttonStartDateMinus7.Name = "buttonStartDateMinus7";
            this.buttonStartDateMinus7.Size = new System.Drawing.Size(100, 23);
            this.buttonStartDateMinus7.TabIndex = 3;
            this.buttonStartDateMinus7.Text = "-7日";
            this.buttonStartDateMinus7.UseVisualStyleBackColor = true;
            this.buttonStartDateMinus7.Click += new System.EventHandler(this.buttonStartDateMinus7_Click);
            // 
            // buttonEndDateMinus7
            // 
            this.buttonEndDateMinus7.Location = new System.Drawing.Point(214, 49);
            this.buttonEndDateMinus7.Name = "buttonEndDateMinus7";
            this.buttonEndDateMinus7.Size = new System.Drawing.Size(100, 23);
            this.buttonEndDateMinus7.TabIndex = 4;
            this.buttonEndDateMinus7.Text = "+7日";
            this.buttonEndDateMinus7.UseVisualStyleBackColor = true;
            this.buttonEndDateMinus7.Click += new System.EventHandler(this.buttonEndDateMinus7_Click);
            // 
            // buttonDateCopy
            // 
            this.buttonDateCopy.Location = new System.Drawing.Point(170, 78);
            this.buttonDateCopy.Name = "buttonDateCopy";
            this.buttonDateCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonDateCopy.TabIndex = 5;
            this.buttonDateCopy.Text = "↓";
            this.buttonDateCopy.UseVisualStyleBackColor = true;
            this.buttonDateCopy.Click += new System.EventHandler(this.buttonDateCopy_Click);
            // 
            // checkDateAutoCopy
            // 
            this.checkDateAutoCopy.AutoSize = true;
            this.checkDateAutoCopy.Location = new System.Drawing.Point(251, 81);
            this.checkDateAutoCopy.Name = "checkDateAutoCopy";
            this.checkDateAutoCopy.Size = new System.Drawing.Size(50, 19);
            this.checkDateAutoCopy.TabIndex = 6;
            this.checkDateAutoCopy.Text = "自動";
            this.checkDateAutoCopy.UseVisualStyleBackColor = true;
            this.checkDateAutoCopy.CheckedChanged += new System.EventHandler(this.checkDateAutoCopy_CheckedChanged);
            // 
            // dateEndTime
            // 
            this.dateEndTime.CustomFormat = "HH:mm:ss";
            this.dateEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndTime.Location = new System.Drawing.Point(239, 108);
            this.dateEndTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEndTime.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateEndTime.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            this.dateEndTime.Name = "dateEndTime";
            this.dateEndTime.ShowUpDown = true;
            this.dateEndTime.Size = new System.Drawing.Size(75, 23);
            this.dateEndTime.TabIndex = 9;
            this.dateEndTime.Value = new System.DateTime(2020, 12, 19, 0, 0, 0, 0);
            // 
            // dateEndDate
            // 
            this.dateEndDate.CustomFormat = "yyyy年MM月dd日    ";
            this.dateEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndDate.Location = new System.Drawing.Point(103, 108);
            this.dateEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEndDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateEndDate.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Size = new System.Drawing.Size(130, 23);
            this.dateEndDate.TabIndex = 8;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(14, 114);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(72, 15);
            this.labelEndDate.TabIndex = 7;
            this.labelEndDate.Text = "終了日時(&E)";
            // 
            // buttonEndPlus30m
            // 
            this.buttonEndPlus30m.Location = new System.Drawing.Point(214, 138);
            this.buttonEndPlus30m.Name = "buttonEndPlus30m";
            this.buttonEndPlus30m.Size = new System.Drawing.Size(100, 23);
            this.buttonEndPlus30m.TabIndex = 11;
            this.buttonEndPlus30m.Text = "+30日";
            this.buttonEndPlus30m.UseVisualStyleBackColor = true;
            this.buttonEndPlus30m.Click += new System.EventHandler(this.buttonEndPlus30m_Click);
            // 
            // buttonEndPlus1h
            // 
            this.buttonEndPlus1h.Location = new System.Drawing.Point(103, 138);
            this.buttonEndPlus1h.Name = "buttonEndPlus1h";
            this.buttonEndPlus1h.Size = new System.Drawing.Size(100, 23);
            this.buttonEndPlus1h.TabIndex = 10;
            this.buttonEndPlus1h.Text = "+1時間";
            this.buttonEndPlus1h.UseVisualStyleBackColor = true;
            this.buttonEndPlus1h.Click += new System.EventHandler(this.buttonEndPlus1h_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPagePastLog);
            this.tabControlMain.Controls.Add(this.tabPageTimeShift);
            this.tabControlMain.Controls.Add(this.tabPageTool);
            this.tabControlMain.Controls.Add(this.tabPageEtc);
            this.tabControlMain.Location = new System.Drawing.Point(12, 54);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(336, 356);
            this.tabControlMain.TabIndex = 2;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPagePastLog
            // 
            this.tabPagePastLog.Controls.Add(this.buttonOpenTimeShiftBrowser);
            this.tabPagePastLog.Controls.Add(this.checkBoxAlwaysAPI);
            this.tabPagePastLog.Controls.Add(this.buttonSaveToFolder);
            this.tabPagePastLog.Controls.Add(this.buttonSaveToFile);
            this.tabPagePastLog.Controls.Add(this.textSaveTo);
            this.tabPagePastLog.Controls.Add(this.labelSaveTo);
            this.tabPagePastLog.Controls.Add(this.buttonPastLogDownload);
            this.tabPagePastLog.Controls.Add(this.labelDateStart);
            this.tabPagePastLog.Controls.Add(this.buttonEndPlus30m);
            this.tabPagePastLog.Controls.Add(this.dateStartDate);
            this.tabPagePastLog.Controls.Add(this.buttonEndPlus1h);
            this.tabPagePastLog.Controls.Add(this.dateStartTime);
            this.tabPagePastLog.Controls.Add(this.dateEndTime);
            this.tabPagePastLog.Controls.Add(this.buttonStartDateMinus7);
            this.tabPagePastLog.Controls.Add(this.dateEndDate);
            this.tabPagePastLog.Controls.Add(this.buttonEndDateMinus7);
            this.tabPagePastLog.Controls.Add(this.labelEndDate);
            this.tabPagePastLog.Controls.Add(this.buttonDateCopy);
            this.tabPagePastLog.Controls.Add(this.checkDateAutoCopy);
            this.tabPagePastLog.Location = new System.Drawing.Point(4, 24);
            this.tabPagePastLog.Name = "tabPagePastLog";
            this.tabPagePastLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePastLog.Size = new System.Drawing.Size(328, 328);
            this.tabPagePastLog.TabIndex = 0;
            this.tabPagePastLog.Text = "過去ログ取得";
            this.tabPagePastLog.UseVisualStyleBackColor = true;
            // 
            // buttonOpenTimeShiftBrowser
            // 
            this.buttonOpenTimeShiftBrowser.Location = new System.Drawing.Point(17, 283);
            this.buttonOpenTimeShiftBrowser.Name = "buttonOpenTimeShiftBrowser";
            this.buttonOpenTimeShiftBrowser.Size = new System.Drawing.Size(297, 23);
            this.buttonOpenTimeShiftBrowser.TabIndex = 18;
            this.buttonOpenTimeShiftBrowser.Text = "開始日時のタイムシフトををブラウザで開く(&O)";
            this.buttonOpenTimeShiftBrowser.UseVisualStyleBackColor = true;
            this.buttonOpenTimeShiftBrowser.Click += new System.EventHandler(this.buttonOpenTimeShiftBrowser_Click);
            // 
            // checkBoxAlwaysAPI
            // 
            this.checkBoxAlwaysAPI.AutoSize = true;
            this.checkBoxAlwaysAPI.Location = new System.Drawing.Point(17, 229);
            this.checkBoxAlwaysAPI.Name = "checkBoxAlwaysAPI";
            this.checkBoxAlwaysAPI.Size = new System.Drawing.Size(238, 19);
            this.checkBoxAlwaysAPI.TabIndex = 16;
            this.checkBoxAlwaysAPI.Text = "常にニコニコ実況過去ログ取得APIを使う(&A)";
            this.checkBoxAlwaysAPI.UseVisualStyleBackColor = true;
            // 
            // buttonSaveToFolder
            // 
            this.buttonSaveToFolder.Location = new System.Drawing.Point(103, 200);
            this.buttonSaveToFolder.Name = "buttonSaveToFolder";
            this.buttonSaveToFolder.Size = new System.Drawing.Size(100, 23);
            this.buttonSaveToFolder.TabIndex = 14;
            this.buttonSaveToFolder.Tag = "0";
            this.buttonSaveToFolder.Text = "フォルダー(&D)...";
            this.buttonSaveToFolder.UseVisualStyleBackColor = true;
            this.buttonSaveToFolder.Click += new System.EventHandler(this.buttonSaveToFolder_Click);
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Location = new System.Drawing.Point(214, 200);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(100, 23);
            this.buttonSaveToFile.TabIndex = 15;
            this.buttonSaveToFile.Tag = "0";
            this.buttonSaveToFile.Text = "ファイル(&F)...";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // textSaveTo
            // 
            this.textSaveTo.AllowDrop = true;
            this.textSaveTo.Location = new System.Drawing.Point(103, 171);
            this.textSaveTo.Name = "textSaveTo";
            this.textSaveTo.Size = new System.Drawing.Size(211, 23);
            this.textSaveTo.TabIndex = 13;
            this.textSaveTo.DragDrop += new System.Windows.Forms.DragEventHandler(this.textSaveTo_DragDrop);
            this.textSaveTo.DragEnter += new System.Windows.Forms.DragEventHandler(this.textSaveTo_DragEnter);
            // 
            // labelSaveTo
            // 
            this.labelSaveTo.AutoSize = true;
            this.labelSaveTo.Location = new System.Drawing.Point(14, 174);
            this.labelSaveTo.Name = "labelSaveTo";
            this.labelSaveTo.Size = new System.Drawing.Size(61, 15);
            this.labelSaveTo.TabIndex = 12;
            this.labelSaveTo.Text = "保存先(&T)";
            // 
            // buttonPastLogDownload
            // 
            this.buttonPastLogDownload.Location = new System.Drawing.Point(17, 254);
            this.buttonPastLogDownload.Name = "buttonPastLogDownload";
            this.buttonPastLogDownload.Size = new System.Drawing.Size(297, 23);
            this.buttonPastLogDownload.TabIndex = 17;
            this.buttonPastLogDownload.Text = "ダウンロード(&L)";
            this.buttonPastLogDownload.UseVisualStyleBackColor = true;
            this.buttonPastLogDownload.Click += new System.EventHandler(this.buttonPastLogDownload_Click);
            // 
            // tabPageTimeShift
            // 
            this.tabPageTimeShift.Controls.Add(this.buttonTimeShiftUpdateCache);
            this.tabPageTimeShift.Controls.Add(this.labelSeparator2);
            this.tabPageTimeShift.Controls.Add(this.checkTimeShiftOverwrite);
            this.tabPageTimeShift.Controls.Add(this.labelSeparator);
            this.tabPageTimeShift.Controls.Add(this.checkTimeShiftSubFolder);
            this.tabPageTimeShift.Controls.Add(this.buttonTimeShiftSaveToFolder);
            this.tabPageTimeShift.Controls.Add(this.buttonTimeShiftSaveToFile);
            this.tabPageTimeShift.Controls.Add(this.textTimeShiftSaveTo);
            this.tabPageTimeShift.Controls.Add(this.labelTimeShiftSaveTo);
            this.tabPageTimeShift.Controls.Add(this.buttonTimeShiftAlllDownload);
            this.tabPageTimeShift.Controls.Add(this.buttonTimeShiftDownload);
            this.tabPageTimeShift.Controls.Add(this.labelTimeShiftDate);
            this.tabPageTimeShift.Controls.Add(this.dateTimeShiftDate);
            this.tabPageTimeShift.Location = new System.Drawing.Point(4, 24);
            this.tabPageTimeShift.Name = "tabPageTimeShift";
            this.tabPageTimeShift.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTimeShift.Size = new System.Drawing.Size(328, 328);
            this.tabPageTimeShift.TabIndex = 1;
            this.tabPageTimeShift.Text = "タイムシフト取得";
            this.tabPageTimeShift.UseVisualStyleBackColor = true;
            // 
            // checkTimeShiftOverwrite
            // 
            this.checkTimeShiftOverwrite.AutoSize = true;
            this.checkTimeShiftOverwrite.Location = new System.Drawing.Point(17, 199);
            this.checkTimeShiftOverwrite.Name = "checkTimeShiftOverwrite";
            this.checkTimeShiftOverwrite.Size = new System.Drawing.Size(230, 19);
            this.checkTimeShiftOverwrite.TabIndex = 9;
            this.checkTimeShiftOverwrite.Text = "ダウンロード済みのファイルを上書きする(&W)";
            this.checkTimeShiftOverwrite.UseVisualStyleBackColor = true;
            // 
            // labelSeparator
            // 
            this.labelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSeparator.Location = new System.Drawing.Point(18, 151);
            this.labelSeparator.Name = "labelSeparator";
            this.labelSeparator.Size = new System.Drawing.Size(296, 1);
            this.labelSeparator.TabIndex = 7;
            // 
            // checkTimeShiftSubFolder
            // 
            this.checkTimeShiftSubFolder.AutoSize = true;
            this.checkTimeShiftSubFolder.Checked = true;
            this.checkTimeShiftSubFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkTimeShiftSubFolder.Location = new System.Drawing.Point(17, 174);
            this.checkTimeShiftSubFolder.Name = "checkTimeShiftSubFolder";
            this.checkTimeShiftSubFolder.Size = new System.Drawing.Size(210, 19);
            this.checkTimeShiftSubFolder.TabIndex = 8;
            this.checkTimeShiftSubFolder.Text = "チャンネルごとにサブフォルダーを作る(&C)";
            this.checkTimeShiftSubFolder.UseVisualStyleBackColor = true;
            // 
            // buttonTimeShiftSaveToFolder
            // 
            this.buttonTimeShiftSaveToFolder.Location = new System.Drawing.Point(103, 78);
            this.buttonTimeShiftSaveToFolder.Name = "buttonTimeShiftSaveToFolder";
            this.buttonTimeShiftSaveToFolder.Size = new System.Drawing.Size(100, 23);
            this.buttonTimeShiftSaveToFolder.TabIndex = 4;
            this.buttonTimeShiftSaveToFolder.Tag = "1";
            this.buttonTimeShiftSaveToFolder.Text = "フォルダー(&D)...";
            this.buttonTimeShiftSaveToFolder.UseVisualStyleBackColor = true;
            this.buttonTimeShiftSaveToFolder.Click += new System.EventHandler(this.buttonTimeShiftSaveToFolder_Click);
            // 
            // buttonTimeShiftSaveToFile
            // 
            this.buttonTimeShiftSaveToFile.Location = new System.Drawing.Point(214, 78);
            this.buttonTimeShiftSaveToFile.Name = "buttonTimeShiftSaveToFile";
            this.buttonTimeShiftSaveToFile.Size = new System.Drawing.Size(100, 23);
            this.buttonTimeShiftSaveToFile.TabIndex = 5;
            this.buttonTimeShiftSaveToFile.Tag = "1";
            this.buttonTimeShiftSaveToFile.Text = "ファイル(&F)...";
            this.buttonTimeShiftSaveToFile.UseVisualStyleBackColor = true;
            this.buttonTimeShiftSaveToFile.Click += new System.EventHandler(this.buttonTimeShiftSaveToFile_Click);
            // 
            // textTimeShiftSaveTo
            // 
            this.textTimeShiftSaveTo.AllowDrop = true;
            this.textTimeShiftSaveTo.Location = new System.Drawing.Point(103, 49);
            this.textTimeShiftSaveTo.Name = "textTimeShiftSaveTo";
            this.textTimeShiftSaveTo.Size = new System.Drawing.Size(211, 23);
            this.textTimeShiftSaveTo.TabIndex = 3;
            this.textTimeShiftSaveTo.DragDrop += new System.Windows.Forms.DragEventHandler(this.textSaveTo_DragDrop);
            this.textTimeShiftSaveTo.DragEnter += new System.Windows.Forms.DragEventHandler(this.textSaveTo_DragEnter);
            // 
            // labelTimeShiftSaveTo
            // 
            this.labelTimeShiftSaveTo.AutoSize = true;
            this.labelTimeShiftSaveTo.Location = new System.Drawing.Point(14, 52);
            this.labelTimeShiftSaveTo.Name = "labelTimeShiftSaveTo";
            this.labelTimeShiftSaveTo.Size = new System.Drawing.Size(61, 15);
            this.labelTimeShiftSaveTo.TabIndex = 2;
            this.labelTimeShiftSaveTo.Text = "保存先(&T)";
            // 
            // buttonTimeShiftAlllDownload
            // 
            this.buttonTimeShiftAlllDownload.Location = new System.Drawing.Point(17, 224);
            this.buttonTimeShiftAlllDownload.Name = "buttonTimeShiftAlllDownload";
            this.buttonTimeShiftAlllDownload.Size = new System.Drawing.Size(297, 23);
            this.buttonTimeShiftAlllDownload.TabIndex = 10;
            this.buttonTimeShiftAlllDownload.Text = "保存先に全局の全タイムシフトをダウンロード(&A)";
            this.buttonTimeShiftAlllDownload.UseVisualStyleBackColor = true;
            this.buttonTimeShiftAlllDownload.Click += new System.EventHandler(this.buttonTimeShiftAlllDownload_Click);
            // 
            // buttonTimeShiftDownload
            // 
            this.buttonTimeShiftDownload.Location = new System.Drawing.Point(17, 110);
            this.buttonTimeShiftDownload.Name = "buttonTimeShiftDownload";
            this.buttonTimeShiftDownload.Size = new System.Drawing.Size(297, 23);
            this.buttonTimeShiftDownload.TabIndex = 6;
            this.buttonTimeShiftDownload.Text = "ダウンロード(&L)";
            this.buttonTimeShiftDownload.UseVisualStyleBackColor = true;
            this.buttonTimeShiftDownload.Click += new System.EventHandler(this.buttonTimeShiftDownload_Click);
            // 
            // labelTimeShiftDate
            // 
            this.labelTimeShiftDate.AutoSize = true;
            this.labelTimeShiftDate.Location = new System.Drawing.Point(14, 25);
            this.labelTimeShiftDate.Name = "labelTimeShiftDate";
            this.labelTimeShiftDate.Size = new System.Drawing.Size(61, 15);
            this.labelTimeShiftDate.TabIndex = 0;
            this.labelTimeShiftDate.Text = "取得日(&S)";
            // 
            // dateTimeShiftDate
            // 
            this.dateTimeShiftDate.CustomFormat = "yyyy年MM月dd日    ";
            this.dateTimeShiftDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeShiftDate.Location = new System.Drawing.Point(103, 19);
            this.dateTimeShiftDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimeShiftDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateTimeShiftDate.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            this.dateTimeShiftDate.Name = "dateTimeShiftDate";
            this.dateTimeShiftDate.Size = new System.Drawing.Size(130, 23);
            this.dateTimeShiftDate.TabIndex = 1;
            // 
            // tabPageEtc
            // 
            this.tabPageEtc.Controls.Add(this.label1);
            this.tabPageEtc.Controls.Add(this.labelAbout);
            this.tabPageEtc.Controls.Add(this.buttonJkTsGetterAbout);
            this.tabPageEtc.Controls.Add(this.buttonOpenGitHub);
            this.tabPageEtc.Controls.Add(this.buttonOpenChannelLive);
            this.tabPageEtc.Controls.Add(this.buttonOpenChannelTop);
            this.tabPageEtc.Controls.Add(this.buttonOpenNicoJkTop);
            this.tabPageEtc.Location = new System.Drawing.Point(4, 24);
            this.tabPageEtc.Name = "tabPageEtc";
            this.tabPageEtc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEtc.Size = new System.Drawing.Size(328, 328);
            this.tabPageEtc.TabIndex = 2;
            this.tabPageEtc.Text = "その他";
            this.tabPageEtc.UseVisualStyleBackColor = true;
            // 
            // labelAbout
            // 
            this.labelAbout.Location = new System.Drawing.Point(17, 225);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(297, 19);
            this.labelAbout.TabIndex = 22;
            this.labelAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonJkTsGetterAbout
            // 
            this.buttonJkTsGetterAbout.Location = new System.Drawing.Point(17, 282);
            this.buttonJkTsGetterAbout.Name = "buttonJkTsGetterAbout";
            this.buttonJkTsGetterAbout.Size = new System.Drawing.Size(297, 23);
            this.buttonJkTsGetterAbout.TabIndex = 21;
            this.buttonJkTsGetterAbout.Text = "JkTsGetter";
            this.buttonJkTsGetterAbout.UseVisualStyleBackColor = true;
            this.buttonJkTsGetterAbout.Click += new System.EventHandler(this.buttonJkTsGetterAbout_Click);
            // 
            // buttonOpenGitHub
            // 
            this.buttonOpenGitHub.Location = new System.Drawing.Point(17, 253);
            this.buttonOpenGitHub.Name = "buttonOpenGitHub";
            this.buttonOpenGitHub.Size = new System.Drawing.Size(297, 23);
            this.buttonOpenGitHub.TabIndex = 20;
            this.buttonOpenGitHub.Text = "github.com/sasukekinniku/JkTsGetterTool";
            this.buttonOpenGitHub.UseVisualStyleBackColor = true;
            this.buttonOpenGitHub.Click += new System.EventHandler(this.buttonOpenGitHub_Click);
            // 
            // buttonOpenChannelLive
            // 
            this.buttonOpenChannelLive.Location = new System.Drawing.Point(17, 78);
            this.buttonOpenChannelLive.Name = "buttonOpenChannelLive";
            this.buttonOpenChannelLive.Size = new System.Drawing.Size(297, 23);
            this.buttonOpenChannelLive.TabIndex = 19;
            this.buttonOpenChannelLive.Text = "このチャンネルの現在の生放送(&L)";
            this.buttonOpenChannelLive.UseVisualStyleBackColor = true;
            this.buttonOpenChannelLive.Click += new System.EventHandler(this.buttonOpenChannelLive_Click);
            // 
            // buttonOpenChannelTop
            // 
            this.buttonOpenChannelTop.Location = new System.Drawing.Point(17, 49);
            this.buttonOpenChannelTop.Name = "buttonOpenChannelTop";
            this.buttonOpenChannelTop.Size = new System.Drawing.Size(297, 23);
            this.buttonOpenChannelTop.TabIndex = 18;
            this.buttonOpenChannelTop.Text = "このチャンネルのトップページ(&C)";
            this.buttonOpenChannelTop.UseVisualStyleBackColor = true;
            this.buttonOpenChannelTop.Click += new System.EventHandler(this.buttonOpenChannelTop_Click);
            // 
            // buttonOpenNicoJkTop
            // 
            this.buttonOpenNicoJkTop.Location = new System.Drawing.Point(17, 20);
            this.buttonOpenNicoJkTop.Name = "buttonOpenNicoJkTop";
            this.buttonOpenNicoJkTop.Size = new System.Drawing.Size(297, 23);
            this.buttonOpenNicoJkTop.TabIndex = 17;
            this.buttonOpenNicoJkTop.Text = "ニコニコ実況 トップページ(&J)";
            this.buttonOpenNicoJkTop.UseVisualStyleBackColor = true;
            this.buttonOpenNicoJkTop.Click += new System.EventHandler(this.buttonOpenNicoJkTop_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "ニコニコ実況 コメント ファイル|*.xml; *.nicojk; *.jkl|すべてのファイル|*.*";
            // 
            // labelSeparator2
            // 
            this.labelSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSeparator2.Location = new System.Drawing.Point(16, 265);
            this.labelSeparator2.Name = "labelSeparator2";
            this.labelSeparator2.Size = new System.Drawing.Size(296, 1);
            this.labelSeparator2.TabIndex = 11;
            // 
            // buttonTimeShiftUpdateCache
            // 
            this.buttonTimeShiftUpdateCache.Location = new System.Drawing.Point(15, 285);
            this.buttonTimeShiftUpdateCache.Name = "buttonTimeShiftUpdateCache";
            this.buttonTimeShiftUpdateCache.Size = new System.Drawing.Size(297, 23);
            this.buttonTimeShiftUpdateCache.TabIndex = 12;
            this.buttonTimeShiftUpdateCache.Text = "キャッシュ フォルダーに全局の全タイムシフトをダウンロード(&H)";
            this.buttonTimeShiftUpdateCache.UseVisualStyleBackColor = true;
            this.buttonTimeShiftUpdateCache.Click += new System.EventHandler(this.buttonTimeShiftUpdateCache_Click);
            // 
            // tabPageTool
            // 
            this.tabPageTool.Controls.Add(this.buttonToolMerge);
            this.tabPageTool.Controls.Add(this.buttonToolSaveTo);
            this.tabPageTool.Controls.Add(this.buttonToolXml2);
            this.tabPageTool.Controls.Add(this.buttonToolXml1);
            this.tabPageTool.Controls.Add(this.textToolSaveTo);
            this.tabPageTool.Controls.Add(this.labelToolSaveTo);
            this.tabPageTool.Controls.Add(this.textToolXml2);
            this.tabPageTool.Controls.Add(this.labelToolXml2);
            this.tabPageTool.Controls.Add(this.textToolXml1);
            this.tabPageTool.Controls.Add(this.labelToolXml1);
            this.tabPageTool.Location = new System.Drawing.Point(4, 24);
            this.tabPageTool.Name = "tabPageTool";
            this.tabPageTool.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTool.Size = new System.Drawing.Size(328, 328);
            this.tabPageTool.TabIndex = 3;
            this.tabPageTool.Text = "ツール";
            this.tabPageTool.UseVisualStyleBackColor = true;
            // 
            // textToolXml1
            // 
            this.textToolXml1.AllowDrop = true;
            this.textToolXml1.Location = new System.Drawing.Point(103, 19);
            this.textToolXml1.Name = "textToolXml1";
            this.textToolXml1.Size = new System.Drawing.Size(175, 23);
            this.textToolXml1.TabIndex = 5;
            this.textToolXml1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textToolXml1_DragDrop);
            this.textToolXml1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textToolXml1_DragEnter);
            // 
            // labelToolXml1
            // 
            this.labelToolXml1.AutoSize = true;
            this.labelToolXml1.Location = new System.Drawing.Point(14, 22);
            this.labelToolXml1.Name = "labelToolXml1";
            this.labelToolXml1.Size = new System.Drawing.Size(80, 15);
            this.labelToolXml1.TabIndex = 4;
            this.labelToolXml1.Text = "xmlファイル(&1)";
            // 
            // textToolXml2
            // 
            this.textToolXml2.AllowDrop = true;
            this.textToolXml2.Location = new System.Drawing.Point(103, 48);
            this.textToolXml2.Name = "textToolXml2";
            this.textToolXml2.Size = new System.Drawing.Size(175, 23);
            this.textToolXml2.TabIndex = 7;
            this.textToolXml2.DragDrop += new System.Windows.Forms.DragEventHandler(this.textToolXml1_DragDrop);
            this.textToolXml2.DragEnter += new System.Windows.Forms.DragEventHandler(this.textToolXml1_DragEnter);
            // 
            // labelToolXml2
            // 
            this.labelToolXml2.AutoSize = true;
            this.labelToolXml2.Location = new System.Drawing.Point(14, 51);
            this.labelToolXml2.Name = "labelToolXml2";
            this.labelToolXml2.Size = new System.Drawing.Size(80, 15);
            this.labelToolXml2.TabIndex = 6;
            this.labelToolXml2.Text = "xmlファイル(&2)";
            // 
            // textToolSaveTo
            // 
            this.textToolSaveTo.AllowDrop = true;
            this.textToolSaveTo.Location = new System.Drawing.Point(103, 77);
            this.textToolSaveTo.Name = "textToolSaveTo";
            this.textToolSaveTo.Size = new System.Drawing.Size(175, 23);
            this.textToolSaveTo.TabIndex = 9;
            this.textToolSaveTo.DragDrop += new System.Windows.Forms.DragEventHandler(this.textSaveTo_DragDrop);
            this.textToolSaveTo.DragEnter += new System.Windows.Forms.DragEventHandler(this.textSaveTo_DragEnter);
            // 
            // labelToolSaveTo
            // 
            this.labelToolSaveTo.AutoSize = true;
            this.labelToolSaveTo.Location = new System.Drawing.Point(14, 80);
            this.labelToolSaveTo.Name = "labelToolSaveTo";
            this.labelToolSaveTo.Size = new System.Drawing.Size(61, 15);
            this.labelToolSaveTo.TabIndex = 8;
            this.labelToolSaveTo.Text = "保存先(&T)";
            // 
            // buttonToolXml1
            // 
            this.buttonToolXml1.Location = new System.Drawing.Point(283, 19);
            this.buttonToolXml1.Name = "buttonToolXml1";
            this.buttonToolXml1.Size = new System.Drawing.Size(30, 23);
            this.buttonToolXml1.TabIndex = 10;
            this.buttonToolXml1.Tag = "textToolXml1";
            this.buttonToolXml1.Text = "...";
            this.buttonToolXml1.UseVisualStyleBackColor = true;
            this.buttonToolXml1.Click += new System.EventHandler(this.buttonToolXml1_Click);
            // 
            // buttonToolXml2
            // 
            this.buttonToolXml2.Location = new System.Drawing.Point(283, 48);
            this.buttonToolXml2.Name = "buttonToolXml2";
            this.buttonToolXml2.Size = new System.Drawing.Size(30, 23);
            this.buttonToolXml2.TabIndex = 11;
            this.buttonToolXml2.Tag = "textToolXml2";
            this.buttonToolXml2.Text = "...";
            this.buttonToolXml2.UseVisualStyleBackColor = true;
            this.buttonToolXml2.Click += new System.EventHandler(this.buttonToolXml2_Click);
            // 
            // buttonToolSaveTo
            // 
            this.buttonToolSaveTo.Location = new System.Drawing.Point(283, 77);
            this.buttonToolSaveTo.Name = "buttonToolSaveTo";
            this.buttonToolSaveTo.Size = new System.Drawing.Size(30, 23);
            this.buttonToolSaveTo.TabIndex = 12;
            this.buttonToolSaveTo.Tag = "textToolSaveTo";
            this.buttonToolSaveTo.Text = "...";
            this.buttonToolSaveTo.UseVisualStyleBackColor = true;
            this.buttonToolSaveTo.Click += new System.EventHandler(this.buttonToolSaveTo_Click);
            // 
            // buttonToolMerge
            // 
            this.buttonToolMerge.Location = new System.Drawing.Point(17, 106);
            this.buttonToolMerge.Name = "buttonToolMerge";
            this.buttonToolMerge.Size = new System.Drawing.Size(297, 23);
            this.buttonToolMerge.TabIndex = 13;
            this.buttonToolMerge.Text = "2つのコメントxmlファイルをマージする(&M)";
            this.buttonToolMerge.UseVisualStyleBackColor = true;
            this.buttonToolMerge.Click += new System.EventHandler(this.buttonToolMerge_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "ニコニコ実況 コメント ファイル|*.xml; *.nicojk; *.jkl|すべてのファイル|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 60);
            this.label1.TabIndex = 23;
            this.label1.Text = "[使い方のヒント]\r\n「過去ログ取得」「タイムシフト取得」タブに\r\n.ts ファイルをドラッグ&ドロップすると、\r\nファイルからチャンネル、日時を取得します。\r\n" +
    "";
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 422);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.comboChannels);
            this.Controls.Add(this.labelChannel);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "JkTsGetterTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.tabControlMain.ResumeLayout(false);
            this.tabPagePastLog.ResumeLayout(false);
            this.tabPagePastLog.PerformLayout();
            this.tabPageTimeShift.ResumeLayout(false);
            this.tabPageTimeShift.PerformLayout();
            this.tabPageEtc.ResumeLayout(false);
            this.tabPageEtc.PerformLayout();
            this.tabPageTool.ResumeLayout(false);
            this.tabPageTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChannel;
        private System.Windows.Forms.ComboBox comboChannels;
        private System.Windows.Forms.Label labelDateStart;
        private System.Windows.Forms.DateTimePicker dateStartDate;
        private System.Windows.Forms.DateTimePicker dateStartTime;
        private System.Windows.Forms.Button buttonStartDateMinus7;
        private System.Windows.Forms.Button buttonEndDateMinus7;
        private System.Windows.Forms.Button buttonDateCopy;
        private System.Windows.Forms.CheckBox checkDateAutoCopy;
        private System.Windows.Forms.DateTimePicker dateEndTime;
        private System.Windows.Forms.DateTimePicker dateEndDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Button buttonEndPlus30m;
        private System.Windows.Forms.Button buttonEndPlus1h;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePastLog;
        private System.Windows.Forms.TabPage tabPageTimeShift;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.TextBox textSaveTo;
        private System.Windows.Forms.Label labelSaveTo;
        private System.Windows.Forms.Button buttonPastLogDownload;
        private System.Windows.Forms.Button buttonTimeShiftDownload;
        private System.Windows.Forms.Label labelTimeShiftDate;
        private System.Windows.Forms.DateTimePicker dateTimeShiftDate;
        private System.Windows.Forms.TabPage tabPageEtc;
        private System.Windows.Forms.Button buttonSaveToFolder;
        private System.Windows.Forms.Button buttonTimeShiftSaveToFolder;
        private System.Windows.Forms.Button buttonTimeShiftSaveToFile;
        private System.Windows.Forms.TextBox textTimeShiftSaveTo;
        private System.Windows.Forms.Label labelTimeShiftSaveTo;
        private System.Windows.Forms.Button buttonTimeShiftAlllDownload;
        private System.Windows.Forms.Button buttonOpenChannelLive;
        private System.Windows.Forms.Button buttonOpenChannelTop;
        private System.Windows.Forms.Button buttonOpenNicoJkTop;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox checkBoxAlwaysAPI;
        private System.Windows.Forms.CheckBox checkTimeShiftOverwrite;
        private System.Windows.Forms.Label labelSeparator;
        private System.Windows.Forms.CheckBox checkTimeShiftSubFolder;
        private System.Windows.Forms.Button buttonOpenTimeShiftBrowser;
        private System.Windows.Forms.Button buttonOpenGitHub;
        private System.Windows.Forms.Button buttonJkTsGetterAbout;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.Button buttonTimeShiftUpdateCache;
        private System.Windows.Forms.Label labelSeparator2;
        private System.Windows.Forms.TabPage tabPageTool;
        private System.Windows.Forms.Button buttonToolMerge;
        private System.Windows.Forms.Button buttonToolSaveTo;
        private System.Windows.Forms.Button buttonToolXml2;
        private System.Windows.Forms.Button buttonToolXml1;
        private System.Windows.Forms.TextBox textToolSaveTo;
        private System.Windows.Forms.Label labelToolSaveTo;
        private System.Windows.Forms.TextBox textToolXml2;
        private System.Windows.Forms.Label labelToolXml2;
        private System.Windows.Forms.TextBox textToolXml1;
        private System.Windows.Forms.Label labelToolXml1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
    }
}

