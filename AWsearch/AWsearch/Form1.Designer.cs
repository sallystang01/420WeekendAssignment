namespace AWsearch
{
    partial class OrderSearch
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
            this.cbCustName = new System.Windows.Forms.ComboBox();
            this.dgOrders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCustName
            // 
            this.cbCustName.FormattingEnabled = true;
            this.cbCustName.Location = new System.Drawing.Point(30, 28);
            this.cbCustName.Name = "cbCustName";
            this.cbCustName.Size = new System.Drawing.Size(121, 21);
            this.cbCustName.TabIndex = 0;
            this.cbCustName.SelectedIndexChanged += new System.EventHandler(this.cbCustName_SelectedIndexChanged);
            // 
            // dgOrders
            // 
            this.dgOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrders.Location = new System.Drawing.Point(30, 78);
            this.dgOrders.Name = "dgOrders";
            this.dgOrders.Size = new System.Drawing.Size(547, 210);
            this.dgOrders.TabIndex = 1;
            // 
            // OrderSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 319);
            this.Controls.Add(this.dgOrders);
            this.Controls.Add(this.cbCustName);
            this.Name = "OrderSearch";
            this.Text = "Order Search Pro";
            ((System.ComponentModel.ISupportInitialize)(this.dgOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCustName;
        private System.Windows.Forms.DataGridView dgOrders;
    }
}

