namespace EasyCurrencyConverter
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmbA = new System.Windows.Forms.ComboBox();
            this.cmbB = new System.Windows.Forms.ComboBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbA
            // 
            this.cmbA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbA.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbA.FormattingEnabled = true;
            this.cmbA.Location = new System.Drawing.Point(250, 14);
            this.cmbA.Name = "cmbA";
            this.cmbA.Size = new System.Drawing.Size(379, 28);
            this.cmbA.TabIndex = 0;
            this.cmbA.SelectedIndexChanged += new System.EventHandler(this.cmbA_SelectedIndexChanged);
            // 
            // cmbB
            // 
            this.cmbB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbB.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbB.FormattingEnabled = true;
            this.cmbB.Location = new System.Drawing.Point(250, 88);
            this.cmbB.Name = "cmbB";
            this.cmbB.Size = new System.Drawing.Size(379, 28);
            this.cmbB.TabIndex = 1;
            this.cmbB.SelectedIndexChanged += new System.EventHandler(this.cmbB_SelectedIndexChanged);
            // 
            // txtA
            // 
            this.txtA.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.Location = new System.Drawing.Point(14, 12);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(230, 31);
            this.txtA.TabIndex = 2;
            this.txtA.Text = "1234.00";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtA_KeyPress);
            // 
            // txtB
            // 
            this.txtB.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.Location = new System.Drawing.Point(14, 86);
            this.txtB.Name = "txtB";
            this.txtB.ReadOnly = true;
            this.txtB.Size = new System.Drawing.Size(230, 31);
            this.txtB.TabIndex = 3;
            this.txtB.Text = "1234.00";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Location = new System.Drawing.Point(12, 9);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(625, 23);
            this.lblLastUpdated.TabIndex = 5;
            this.lblLastUpdated.Text = "lblLastUpdated";
            this.lblLastUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChange);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbA);
            this.panel1.Controls.Add(this.cmbB);
            this.panel1.Controls.Add(this.txtA);
            this.panel1.Controls.Add(this.txtB);
            this.panel1.Location = new System.Drawing.Point(8, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 132);
            this.panel1.TabIndex = 7;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(250, 48);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(379, 34);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "↕ &Switch";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "converts to:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Font = new System.Drawing.Font("굴림", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAuthor.Location = new System.Drawing.Point(117, 190);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(520, 23);
            this.lblAuthor.TabIndex = 8;
            this.lblAuthor.Text = "lblAuthor";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tooltip
            // 
            this.tooltip.AutoPopDelay = 5000;
            this.tooltip.InitialDelay = 50;
            this.tooltip.ReshowDelay = 100;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 227);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblLastUpdated);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbA;
        private System.Windows.Forms.ComboBox cmbB;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChange;
    }
}

