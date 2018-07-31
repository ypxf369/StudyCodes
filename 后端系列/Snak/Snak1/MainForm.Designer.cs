namespace Snak1
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.levelComboBox = new System.Windows.Forms.ComboBox();
            this.chooseLevel = new System.Windows.Forms.CheckBox();
            this.btnReloadMap = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.labLengthValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labLevelVlue = new System.Windows.Forms.Label();
            this.labLength = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTip = new System.Windows.Forms.Label();
            this.labLevelText = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 440);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.levelComboBox);
            this.panel3.Controls.Add(this.chooseLevel);
            this.panel3.Controls.Add(this.btnReloadMap);
            this.panel3.Controls.Add(this.btnStop);
            this.panel3.Controls.Add(this.btnPause);
            this.panel3.Controls.Add(this.btnStart);
            this.panel3.Controls.Add(this.labLengthValue);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.labLevelVlue);
            this.panel3.Controls.Add(this.labLength);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.labelTip);
            this.panel3.Controls.Add(this.labLevelText);
            this.panel3.Location = new System.Drawing.Point(591, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 426);
            this.panel3.TabIndex = 2;
            // 
            // levelComboBox
            // 
            this.levelComboBox.FormattingEnabled = true;
            this.levelComboBox.Location = new System.Drawing.Point(45, 296);
            this.levelComboBox.Name = "levelComboBox";
            this.levelComboBox.Size = new System.Drawing.Size(121, 20);
            this.levelComboBox.TabIndex = 3;
            this.levelComboBox.Text = "5";
            this.levelComboBox.SelectedIndexChanged += new System.EventHandler(this.levelComboBox_SelectedIndexChanged);
            // 
            // chooseLevel
            // 
            this.chooseLevel.AutoSize = true;
            this.chooseLevel.Location = new System.Drawing.Point(63, 259);
            this.chooseLevel.Name = "chooseLevel";
            this.chooseLevel.Size = new System.Drawing.Size(48, 16);
            this.chooseLevel.TabIndex = 2;
            this.chooseLevel.Text = "选关";
            this.chooseLevel.UseVisualStyleBackColor = true;
            this.chooseLevel.CheckedChanged += new System.EventHandler(this.chooseLevel_CheckedChanged);
            // 
            // btnReloadMap
            // 
            this.btnReloadMap.Location = new System.Drawing.Point(63, 217);
            this.btnReloadMap.Name = "btnReloadMap";
            this.btnReloadMap.Size = new System.Drawing.Size(75, 23);
            this.btnReloadMap.TabIndex = 1;
            this.btnReloadMap.Text = "加载地图";
            this.btnReloadMap.UseVisualStyleBackColor = true;
            this.btnReloadMap.Click += new System.EventHandler(this.btnReloadMap_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(63, 173);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(63, 131);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(63, 88);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labLengthValue
            // 
            this.labLengthValue.AutoSize = true;
            this.labLengthValue.Location = new System.Drawing.Point(109, 51);
            this.labLengthValue.Name = "labLengthValue";
            this.labLengthValue.Size = new System.Drawing.Size(11, 12);
            this.labLengthValue.TabIndex = 0;
            this.labLengthValue.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "0";
            // 
            // labLevelVlue
            // 
            this.labLevelVlue.AutoSize = true;
            this.labLevelVlue.Location = new System.Drawing.Point(109, 20);
            this.labLevelVlue.Name = "labLevelVlue";
            this.labLevelVlue.Size = new System.Drawing.Size(11, 12);
            this.labLevelVlue.TabIndex = 0;
            this.labLevelVlue.Text = "1";
            // 
            // labLength
            // 
            this.labLength.AutoSize = true;
            this.labLength.Location = new System.Drawing.Point(43, 51);
            this.labLength.Name = "labLength";
            this.labLength.Size = new System.Drawing.Size(41, 12);
            this.labLength.TabIndex = 0;
            this.labLength.Text = "长度：";
            this.labLength.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "label1";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Location = new System.Drawing.Point(61, 329);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(41, 12);
            this.labelTip.TabIndex = 0;
            this.labelTip.Text = "label1";
            this.labelTip.Click += new System.EventHandler(this.label2_Click);
            // 
            // labLevelText
            // 
            this.labLevelText.AutoSize = true;
            this.labLevelText.Location = new System.Drawing.Point(43, 20);
            this.labLevelText.Name = "labLevelText";
            this.labLevelText.Size = new System.Drawing.Size(41, 12);
            this.labLevelText.TabIndex = 0;
            this.labLevelText.Text = "关数：";
            this.labLevelText.Click += new System.EventHandler(this.label2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labLevelVlue;
        private System.Windows.Forms.Label labLevelText;
        private System.Windows.Forms.ComboBox levelComboBox;
        private System.Windows.Forms.CheckBox chooseLevel;
        private System.Windows.Forms.Button btnReloadMap;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labLengthValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTip;
    }
}

