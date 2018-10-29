namespace Demo_WinForms_FlintstonesViewer
{
    partial class ListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_Characters = new System.Windows.Forms.DataGridView();
            this.btn_DetailView = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.buttonFilterName = new System.Windows.Forms.Button();
            this.buttonSortByName = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Characters)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Characters
            // 
            this.dataGridView_Characters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Characters.Location = new System.Drawing.Point(66, 136);
            this.dataGridView_Characters.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_Characters.Name = "dataGridView_Characters";
            this.dataGridView_Characters.RowTemplate.Height = 24;
            this.dataGridView_Characters.Size = new System.Drawing.Size(651, 186);
            this.dataGridView_Characters.TabIndex = 0;
            // 
            // btn_DetailView
            // 
            this.btn_DetailView.Location = new System.Drawing.Point(66, 342);
            this.btn_DetailView.Margin = new System.Windows.Forms.Padding(2);
            this.btn_DetailView.Name = "btn_DetailView";
            this.btn_DetailView.Size = new System.Drawing.Size(81, 39);
            this.btn_DetailView.TabIndex = 2;
            this.btn_DetailView.Text = "View Detail";
            this.btn_DetailView.UseVisualStyleBackColor = true;
            this.btn_DetailView.Click += new System.EventHandler(this.btn_DetailView_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(61, 26);
            this.lbl_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(237, 29);
            this.lbl_Title.TabIndex = 3;
            this.lbl_Title.Text = "Medium Publications";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(636, 342);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(81, 39);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // buttonFilterName
            // 
            this.buttonFilterName.Location = new System.Drawing.Point(66, 86);
            this.buttonFilterName.Name = "buttonFilterName";
            this.buttonFilterName.Size = new System.Drawing.Size(85, 23);
            this.buttonFilterName.TabIndex = 6;
            this.buttonFilterName.Text = "Filter By Name";
            this.buttonFilterName.UseVisualStyleBackColor = true;
            this.buttonFilterName.Click += new System.EventHandler(this.buttonFilterName_Click);
            // 
            // buttonSortByName
            // 
            this.buttonSortByName.Location = new System.Drawing.Point(157, 86);
            this.buttonSortByName.Name = "buttonSortByName";
            this.buttonSortByName.Size = new System.Drawing.Size(81, 23);
            this.buttonSortByName.TabIndex = 7;
            this.buttonSortByName.Text = "Sort by Name";
            this.buttonSortByName.UseVisualStyleBackColor = true;
            this.buttonSortByName.Click += new System.EventHandler(this.buttonSortByName_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(465, 86);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 8;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(287, 88);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(172, 20);
            this.textBoxSearch.TabIndex = 9;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(550, 342);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(81, 39);
            this.buttonHelp.TabIndex = 10;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 439);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonSortByName);
            this.Controls.Add(this.buttonFilterName);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.btn_DetailView);
            this.Controls.Add(this.dataGridView_Characters);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publications";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Characters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Characters;
        private System.Windows.Forms.Button btn_DetailView;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button buttonFilterName;
        private System.Windows.Forms.Button buttonSortByName;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonHelp;
    }
}

