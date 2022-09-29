namespace DesktopApplication {
    partial class DoctorAppointmentManagerUC {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxUpcomingAppointments = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonUpcomingAdd = new System.Windows.Forms.Button();
            this.buttonUpcomingEdit = new System.Windows.Forms.Button();
            this.buttonUpcomingDelete = new System.Windows.Forms.Button();
            this.buttonUpcomingRefresh = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxPastAppointments = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPastRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 500);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 494);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Upcoming";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.listBoxUpcomingAppointments, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(610, 460);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // listBoxUpcomingAppointments
            // 
            this.listBoxUpcomingAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUpcomingAppointments.FormattingEnabled = true;
            this.listBoxUpcomingAppointments.ItemHeight = 15;
            this.listBoxUpcomingAppointments.Location = new System.Drawing.Point(2, 2);
            this.listBoxUpcomingAppointments.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxUpcomingAppointments.Name = "listBoxUpcomingAppointments";
            this.listBoxUpcomingAppointments.Size = new System.Drawing.Size(606, 426);
            this.listBoxUpcomingAppointments.TabIndex = 0;
            this.listBoxUpcomingAppointments.SelectedIndexChanged += new System.EventHandler(this.listBoxUpcomingAppointments_SelectedIndexChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.buttonUpcomingAdd, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonUpcomingEdit, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonUpcomingDelete, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonUpcomingRefresh, 3, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 430);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(324, 30);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // buttonUpcomingAdd
            // 
            this.buttonUpcomingAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpcomingAdd.AutoSize = true;
            this.buttonUpcomingAdd.Location = new System.Drawing.Point(3, 3);
            this.buttonUpcomingAdd.Name = "buttonUpcomingAdd";
            this.buttonUpcomingAdd.Size = new System.Drawing.Size(75, 24);
            this.buttonUpcomingAdd.TabIndex = 0;
            this.buttonUpcomingAdd.Text = "Add";
            this.buttonUpcomingAdd.UseVisualStyleBackColor = true;
            // 
            // buttonUpcomingEdit
            // 
            this.buttonUpcomingEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpcomingEdit.AutoSize = true;
            this.buttonUpcomingEdit.Location = new System.Drawing.Point(84, 3);
            this.buttonUpcomingEdit.Name = "buttonUpcomingEdit";
            this.buttonUpcomingEdit.Size = new System.Drawing.Size(75, 24);
            this.buttonUpcomingEdit.TabIndex = 1;
            this.buttonUpcomingEdit.Text = "Edit";
            this.buttonUpcomingEdit.UseVisualStyleBackColor = true;
            // 
            // buttonUpcomingDelete
            // 
            this.buttonUpcomingDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpcomingDelete.AutoSize = true;
            this.buttonUpcomingDelete.Location = new System.Drawing.Point(165, 3);
            this.buttonUpcomingDelete.Name = "buttonUpcomingDelete";
            this.buttonUpcomingDelete.Size = new System.Drawing.Size(75, 24);
            this.buttonUpcomingDelete.TabIndex = 2;
            this.buttonUpcomingDelete.Text = "Delete";
            this.buttonUpcomingDelete.UseVisualStyleBackColor = true;
            // 
            // buttonUpcomingRefresh
            // 
            this.buttonUpcomingRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpcomingRefresh.AutoSize = true;
            this.buttonUpcomingRefresh.Location = new System.Drawing.Point(246, 3);
            this.buttonUpcomingRefresh.Name = "buttonUpcomingRefresh";
            this.buttonUpcomingRefresh.Size = new System.Drawing.Size(75, 24);
            this.buttonUpcomingRefresh.TabIndex = 3;
            this.buttonUpcomingRefresh.Text = "Refresh";
            this.buttonUpcomingRefresh.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Past";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.listBoxPastAppointments, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(610, 460);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // listBoxPastAppointments
            // 
            this.listBoxPastAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPastAppointments.FormattingEnabled = true;
            this.listBoxPastAppointments.ItemHeight = 15;
            this.listBoxPastAppointments.Location = new System.Drawing.Point(2, 2);
            this.listBoxPastAppointments.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxPastAppointments.Name = "listBoxPastAppointments";
            this.listBoxPastAppointments.Size = new System.Drawing.Size(606, 426);
            this.listBoxPastAppointments.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.buttonPastRefresh, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 430);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(81, 30);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // buttonPastRefresh
            // 
            this.buttonPastRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPastRefresh.AutoSize = true;
            this.buttonPastRefresh.Location = new System.Drawing.Point(3, 3);
            this.buttonPastRefresh.Name = "buttonPastRefresh";
            this.buttonPastRefresh.Size = new System.Drawing.Size(75, 24);
            this.buttonPastRefresh.TabIndex = 0;
            this.buttonPastRefresh.Text = "Refresh";
            this.buttonPastRefresh.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(633, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 494);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary";
            // 
            // DoctorAppointmentManagerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DoctorAppointmentManagerUC";
            this.Size = new System.Drawing.Size(900, 500);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private ListBox listBoxUpcomingAppointments;
        private ListBox listBoxPastAppointments;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Button buttonUpcomingAdd;
        private Button buttonUpcomingEdit;
        private Button buttonUpcomingDelete;
        private Button buttonUpcomingRefresh;
        private Button buttonPastRefresh;
    }
}
