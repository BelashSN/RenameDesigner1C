namespace _1CRenameDesigner
{
    partial class FormMe
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMe));
            this.TextResult = new System.Windows.Forms.TextBox();
            this.NotifyIconMe = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerMe = new System.Windows.Forms.Timer(this.components);
            this.PanelCommand = new System.Windows.Forms.Panel();
            this.lblClickForCopy = new System.Windows.Forms.Label();
            this.chkSkip = new System.Windows.Forms.CheckBox();
            this.chkErrors = new System.Windows.Forms.CheckBox();
            this.chkRename = new System.Windows.Forms.CheckBox();
            this.TimerCopyLog = new System.Windows.Forms.Timer(this.components);
            this.ContextMenuNotify.SuspendLayout();
            this.PanelCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextResult
            // 
            this.TextResult.AcceptsTab = true;
            this.TextResult.BackColor = System.Drawing.Color.Ivory;
            this.TextResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextResult.Location = new System.Drawing.Point(0, 29);
            this.TextResult.Multiline = true;
            this.TextResult.Name = "TextResult";
            this.TextResult.ReadOnly = true;
            this.TextResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextResult.Size = new System.Drawing.Size(827, 481);
            this.TextResult.TabIndex = 0;
            this.TextResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TextResult_MouseDoubleClick);
            // 
            // NotifyIconMe
            // 
            this.NotifyIconMe.ContextMenuStrip = this.ContextMenuNotify;
            this.NotifyIconMe.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIconMe.Icon")));
            this.NotifyIconMe.Text = "1C Rename Designer";
            this.NotifyIconMe.Visible = true;
            this.NotifyIconMe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMe_MouseClick);
            // 
            // ContextMenuNotify
            // 
            this.ContextMenuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShow,
            this.toolStripMenuItemClose,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.ContextMenuNotify.Name = "ContextMenuNotify";
            this.ContextMenuNotify.Size = new System.Drawing.Size(224, 76);
            // 
            // toolStripMenuItemShow
            // 
            this.toolStripMenuItemShow.Image = global::_1CRenameDesigner.Properties.Resources.Window;
            this.toolStripMenuItemShow.Name = "toolStripMenuItemShow";
            this.toolStripMenuItemShow.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemShow.Text = "Показать окно программы";
            this.toolStripMenuItemShow.Click += new System.EventHandler(this.toolStripMenuItemShow_Click);
            // 
            // toolStripMenuItemClose
            // 
            this.toolStripMenuItemClose.Image = global::_1CRenameDesigner.Properties.Resources.to_tray_icon;
            this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            this.toolStripMenuItemClose.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemClose.Text = "Скрыть окно программы";
            this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Image = global::_1CRenameDesigner.Properties.Resources.logout_icon;
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItemExit.Text = "Выход из программы";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // TimerMe
            // 
            this.TimerMe.Enabled = true;
            this.TimerMe.Interval = 5000;
            this.TimerMe.Tick += new System.EventHandler(this.TimerMe_Tick);
            // 
            // PanelCommand
            // 
            this.PanelCommand.BackColor = System.Drawing.SystemColors.Control;
            this.PanelCommand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelCommand.Controls.Add(this.lblClickForCopy);
            this.PanelCommand.Controls.Add(this.chkSkip);
            this.PanelCommand.Controls.Add(this.chkErrors);
            this.PanelCommand.Controls.Add(this.chkRename);
            this.PanelCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCommand.Location = new System.Drawing.Point(0, 0);
            this.PanelCommand.Name = "PanelCommand";
            this.PanelCommand.Size = new System.Drawing.Size(827, 29);
            this.PanelCommand.TabIndex = 2;
            // 
            // lblClickForCopy
            // 
            this.lblClickForCopy.AutoSize = true;
            this.lblClickForCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClickForCopy.ForeColor = System.Drawing.Color.Blue;
            this.lblClickForCopy.Location = new System.Drawing.Point(232, 4);
            this.lblClickForCopy.Name = "lblClickForCopy";
            this.lblClickForCopy.Size = new System.Drawing.Size(569, 17);
            this.lblClickForCopy.TabIndex = 3;
            this.lblClickForCopy.Text = "Для копирования текста лога в буфер обмена - двойной клик мыши по полю лога ↓";
            // 
            // chkSkip
            // 
            this.chkSkip.AutoSize = true;
            this.chkSkip.Location = new System.Drawing.Point(152, 5);
            this.chkSkip.Name = "chkSkip";
            this.chkSkip.Size = new System.Drawing.Size(75, 17);
            this.chkSkip.TabIndex = 2;
            this.chkSkip.Text = "Пропуски";
            this.chkSkip.UseVisualStyleBackColor = true;
            // 
            // chkErrors
            // 
            this.chkErrors.AutoSize = true;
            this.chkErrors.Location = new System.Drawing.Point(81, 5);
            this.chkErrors.Name = "chkErrors";
            this.chkErrors.Size = new System.Drawing.Size(66, 17);
            this.chkErrors.TabIndex = 1;
            this.chkErrors.Text = "Ошибки";
            this.chkErrors.UseVisualStyleBackColor = true;
            // 
            // chkRename
            // 
            this.chkRename.AutoSize = true;
            this.chkRename.Location = new System.Drawing.Point(5, 5);
            this.chkRename.Name = "chkRename";
            this.chkRename.Size = new System.Drawing.Size(67, 17);
            this.chkRename.TabIndex = 0;
            this.chkRename.Text = "Замены";
            this.chkRename.UseVisualStyleBackColor = true;
            // 
            // TimerCopyLog
            // 
            this.TimerCopyLog.Interval = 3000;
            this.TimerCopyLog.Tick += new System.EventHandler(this.TimerCopyLog_Tick);
            // 
            // FormMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 510);
            this.Controls.Add(this.TextResult);
            this.Controls.Add(this.PanelCommand);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(830, 540);
            this.Name = "FormMe";
            this.ShowInTaskbar = false;
            this.Text = "1C Rename Designer";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMe_FormClosing);
            this.Load += new System.EventHandler(this.FormMe_Load);
            this.ContextMenuNotify.ResumeLayout(false);
            this.PanelCommand.ResumeLayout(false);
            this.PanelCommand.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextResult;
        private System.Windows.Forms.NotifyIcon NotifyIconMe;
        private System.Windows.Forms.ContextMenuStrip ContextMenuNotify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.Timer TimerMe;
        private System.Windows.Forms.Panel PanelCommand;
        private System.Windows.Forms.CheckBox chkSkip;
        private System.Windows.Forms.CheckBox chkErrors;
        private System.Windows.Forms.CheckBox chkRename;
        private System.Windows.Forms.Label lblClickForCopy;
        private System.Windows.Forms.Timer TimerCopyLog;
    }
}

