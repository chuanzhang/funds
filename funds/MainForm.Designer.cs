namespace funds
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FundCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FundName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buy1DynamicPremium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buy1StaticPremium = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeavyIncrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrIncrease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YesterdayValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrEstimateValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimateErrorRateYesterday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimateValuePremiumRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyAndSaleStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FundStyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refreshButton = new System.Windows.Forms.Button();
            this.initStatusLable = new System.Windows.Forms.Label();
            this.sse50Label = new System.Windows.Forms.Label();
            this.sseLable = new System.Windows.Forms.Label();
            this.geiLabel = new System.Windows.Forms.Label();
            this.fundStyleComboBox = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存当前估值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FundCode,
            this.FundName,
            this.Buy1DynamicPremium,
            this.Buy1StaticPremium,
            this.HeavyIncrease,
            this.DealAmount,
            this.FieldAmount,
            this.CurrPrice,
            this.CurrIncrease,
            this.YesterdayValue,
            this.CurrEstimateValue,
            this.EstimateErrorRateYesterday,
            this.EstimateValuePremiumRate,
            this.StockPosition,
            this.BuyAndSaleStatus,
            this.FundStyle});
            this.dataGridView1.Location = new System.Drawing.Point(3, 111);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(1200, 1200);
            this.dataGridView1.TabIndex = 0;
            // 
            // FundCode
            // 
            this.FundCode.HeaderText = "代码";
            this.FundCode.Name = "FundCode";
            this.FundCode.ReadOnly = true;
            this.FundCode.Width = 116;
            // 
            // FundName
            // 
            this.FundName.HeaderText = "名称";
            this.FundName.Name = "FundName";
            this.FundName.ReadOnly = true;
            this.FundName.Width = 116;
            // 
            // Buy1DynamicPremium
            // 
            this.Buy1DynamicPremium.HeaderText = "买一动态溢价率%";
            this.Buy1DynamicPremium.Name = "Buy1DynamicPremium";
            this.Buy1DynamicPremium.ReadOnly = true;
            this.Buy1DynamicPremium.Width = 202;
            // 
            // Buy1StaticPremium
            // 
            this.Buy1StaticPremium.HeaderText = "买一静态溢价率%";
            this.Buy1StaticPremium.Name = "Buy1StaticPremium";
            this.Buy1StaticPremium.ReadOnly = true;
            this.Buy1StaticPremium.Width = 202;
            // 
            // HeavyIncrease
            // 
            this.HeavyIncrease.HeaderText = "重仓涨幅%";
            this.HeavyIncrease.Name = "HeavyIncrease";
            this.HeavyIncrease.ReadOnly = true;
            this.HeavyIncrease.Width = 144;
            // 
            // DealAmount
            // 
            this.DealAmount.HeaderText = "成交金额/万";
            this.DealAmount.Name = "DealAmount";
            this.DealAmount.ReadOnly = true;
            this.DealAmount.Width = 173;
            // 
            // FieldAmount
            // 
            this.FieldAmount.HeaderText = "场内份额/万";
            this.FieldAmount.Name = "FieldAmount";
            this.FieldAmount.ReadOnly = true;
            this.FieldAmount.Width = 173;
            // 
            // CurrPrice
            // 
            this.CurrPrice.HeaderText = "现价";
            this.CurrPrice.Name = "CurrPrice";
            this.CurrPrice.ReadOnly = true;
            this.CurrPrice.Width = 116;
            // 
            // CurrIncrease
            // 
            this.CurrIncrease.HeaderText = "涨幅%";
            this.CurrIncrease.Name = "CurrIncrease";
            this.CurrIncrease.ReadOnly = true;
            this.CurrIncrease.Width = 130;
            // 
            // YesterdayValue
            // 
            this.YesterdayValue.HeaderText = "昨日净值";
            this.YesterdayValue.Name = "YesterdayValue";
            this.YesterdayValue.ReadOnly = true;
            this.YesterdayValue.Width = 144;
            // 
            // CurrEstimateValue
            // 
            this.CurrEstimateValue.HeaderText = "实时估值";
            this.CurrEstimateValue.Name = "CurrEstimateValue";
            this.CurrEstimateValue.ReadOnly = true;
            this.CurrEstimateValue.Width = 144;
            // 
            // EstimateErrorRateYesterday
            // 
            this.EstimateErrorRateYesterday.HeaderText = "昨日估值误差%";
            this.EstimateErrorRateYesterday.Name = "EstimateErrorRateYesterday";
            this.EstimateErrorRateYesterday.ReadOnly = true;
            this.EstimateErrorRateYesterday.Width = 173;
            // 
            // EstimateValuePremiumRate
            // 
            this.EstimateValuePremiumRate.HeaderText = "估值溢价率%";
            this.EstimateValuePremiumRate.Name = "EstimateValuePremiumRate";
            this.EstimateValuePremiumRate.ReadOnly = true;
            this.EstimateValuePremiumRate.Width = 173;
            // 
            // StockPosition
            // 
            this.StockPosition.HeaderText = "股票仓位%";
            this.StockPosition.Name = "StockPosition";
            this.StockPosition.ReadOnly = true;
            this.StockPosition.Width = 144;
            // 
            // BuyAndSaleStatus
            // 
            this.BuyAndSaleStatus.HeaderText = "申赎状态";
            this.BuyAndSaleStatus.Name = "BuyAndSaleStatus";
            this.BuyAndSaleStatus.ReadOnly = true;
            this.BuyAndSaleStatus.Width = 144;
            // 
            // FundStyle
            // 
            this.FundStyle.HeaderText = "基金类型";
            this.FundStyle.Name = "FundStyle";
            this.FundStyle.ReadOnly = true;
            this.FundStyle.Width = 144;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(1371, 39);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(192, 53);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "刷新(&r)";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // initStatusLable
            // 
            this.initStatusLable.AutoSize = true;
            this.initStatusLable.Location = new System.Drawing.Point(35, 59);
            this.initStatusLable.Name = "initStatusLable";
            this.initStatusLable.Size = new System.Drawing.Size(0, 33);
            this.initStatusLable.TabIndex = 2;
            // 
            // sse50Label
            // 
            this.sse50Label.AutoSize = true;
            this.sse50Label.Location = new System.Drawing.Point(351, 61);
            this.sse50Label.Name = "sse50Label";
            this.sse50Label.Size = new System.Drawing.Size(127, 33);
            this.sse50Label.TabIndex = 3;
            this.sse50Label.Text = "上证50 ";
            // 
            // sseLable
            // 
            this.sseLable.AutoSize = true;
            this.sseLable.Location = new System.Drawing.Point(589, 60);
            this.sseLable.Name = "sseLable";
            this.sseLable.Size = new System.Drawing.Size(159, 33);
            this.sseLable.TabIndex = 4;
            this.sseLable.Text = "上证综指 ";
            // 
            // geiLabel
            // 
            this.geiLabel.AutoSize = true;
            this.geiLabel.Location = new System.Drawing.Point(860, 58);
            this.geiLabel.Name = "geiLabel";
            this.geiLabel.Size = new System.Drawing.Size(111, 33);
            this.geiLabel.TabIndex = 5;
            this.geiLabel.Text = "创业板";
            // 
            // fundStyleComboBox
            // 
            this.fundStyleComboBox.FormattingEnabled = true;
            this.fundStyleComboBox.Items.AddRange(new object[] {
            "全部基金",
            "股票型基金",
            "债券型基金",
            "混合型基金",
            "国际(QDII)基金"});
            this.fundStyleComboBox.Location = new System.Drawing.Point(1107, 49);
            this.fundStyleComboBox.Name = "fundStyleComboBox";
            this.fundStyleComboBox.Size = new System.Drawing.Size(235, 41);
            this.fundStyleComboBox.TabIndex = 6;
            this.fundStyleComboBox.Text = "全部基金";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(1739, 44);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(290, 44);
            this.searchBox.TabIndex = 8;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(1658, 50);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(79, 33);
            this.searchLabel.TabIndex = 9;
            this.searchLabel.Text = "搜索";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2333, 39);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存ToolStripMenuItem,
            this.保存当前估值ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.保存ToolStripMenuItem.Text = "保存当前内容";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 保存当前估值ToolStripMenuItem
            // 
            this.保存当前估值ToolStripMenuItem.Name = "保存当前估值ToolStripMenuItem";
            this.保存当前估值ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.保存当前估值ToolStripMenuItem.Text = "保存当前估值";
            this.保存当前估值ToolStripMenuItem.Click += new System.EventHandler(this.保存当前估值ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(2333, 953);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.fundStyleComboBox);
            this.Controls.Add(this.geiLabel);
            this.Controls.Add(this.sseLable);
            this.Controls.Add(this.sse50Label);
            this.Controls.Add(this.initStatusLable);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基金列表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label initStatusLable;
        private System.Windows.Forms.Label sse50Label;
        private System.Windows.Forms.Label sseLable;
        private System.Windows.Forms.Label geiLabel;
        private System.Windows.Forms.ComboBox fundStyleComboBox;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存当前估值ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn FundCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FundName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buy1DynamicPremium;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buy1StaticPremium;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeavyIncrease;
        private System.Windows.Forms.DataGridViewTextBoxColumn DealAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrIncrease;
        private System.Windows.Forms.DataGridViewTextBoxColumn YesterdayValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrEstimateValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimateErrorRateYesterday;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimateValuePremiumRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyAndSaleStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn FundStyle;
    }
}

