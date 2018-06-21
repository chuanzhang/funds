using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace funds
{
    public partial class MainForm : Form
    {
        //全局变量，存放基金数据
        public static Dictionary<String, FundInfo> gFundInfoDict = new Dictionary<string, FundInfo> ();
        
        //股票型基金
        public static Dictionary<String, FundInfo> gStockFundInfoDict = new Dictionary<string, FundInfo>();
        //债券型基金
        public static Dictionary<String, FundInfo> gBondsFundInfoDict = new Dictionary<string, FundInfo>();

        //混合型基金
        public static Dictionary<String, FundInfo> gMixFundInfoDict = new Dictionary<string, FundInfo>();

        //国际QDII基金
        public static Dictionary<String, FundInfo> gQDIIFundInfoDict = new Dictionary<string, FundInfo>();

        //不需要展示的基金
        public static Dictionary<String, String> expFundInfoDict = new Dictionary<string, string>();

        //股票涨跌本地缓存，含指数
        public static Dictionary<String, float> gStockPriceDict = new Dictionary<string, float>();


        //指数涨幅，小数表示，非百分比
        public static float sseIndexIncr = 0; // 上证指数涨幅
        public static float geiIndexIncr = 0; //创业板指数涨幅
        public static float csi300IndexIncr = 0; //沪深300涨幅
        public static float sse50IndexIncr = 0;//上证50涨幅

        public delegate void CallBackDelegate(Dictionary<String, FundInfo> gFundInfoDict);

        public delegate void CallBackDelegateParam(String text);

        private static string yesterdayEstimateValueFileName = "yesterdayEstimateValue.txt";

        public MainForm()
        {
            this.SizeChanged += MainForm_SizeChanged;
            InitializeComponent();
            this.searchBox.KeyDown += SearchBox_KeyDown;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            
            Thread th = new Thread(Init);
            th.Start();
        }

        /// <summary>
        /// 基金搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                String text = searchBox.Text.Trim();
                if (text == "") return;
                dataGridView1.ClearSelection();
                for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                    if (dataGridView1["FundName", i].Value.ToString().Contains(text)
                        || dataGridView1["FundCode", i].Value.ToString().Contains(text)) {
                        dataGridView1.CurrentCell = dataGridView1["FundCode", i];
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 窗体大小发生变化时自动调整数据表格大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, System.EventArgs e)
        {
            dataGridView1.Width = this.Width - 20;
            dataGridView1.Height = this.Height - 100;
        }


        private void ShowStatus(String text) {
            initStatusLable.Text = text;
        }

        /// <summary>
        /// 展示基金列表
        /// </summary>
        /// <param name="fundInfoDict"></param>
        private void ShowResult(Dictionary<String, FundInfo> fundInfoDict) {
            int i = 0;
            sse50Label.Text = "上证50 " + sse50IndexIncr*100 + "%";
            sseLable.Text = "上证综指" + sseIndexIncr*100 + "%";
            geiLabel.Text = "创业板指" + geiIndexIncr*100 + "%";

            dataGridView1.Rows.Clear();

            //没有参数情况下默认展示全部
            if (fundInfoDict == null) fundInfoDict = gFundInfoDict;

            foreach (var fundInfoKV in fundInfoDict) {
                
                //过滤掉场内停盘基金
                if (fundInfoKV.Value.currPrice == 1 && fundInfoKV.Value.dealAmount == 0 && fundInfoKV.Value.currPercentageIncrease == 0)
                {
                    continue;
                }

                dataGridView1.Rows.Add(" ");
                
                dataGridView1["FundCode",i].Value = fundInfoKV.Key;
                dataGridView1.Rows[i].HeaderCell.Value = i;

                if (fundInfoKV.Value != null)
                {
                    dataGridView1["FundName", i].Value = fundInfoKV.Value.fundName;
                    dataGridView1["CurrPrice", i].Value = fundInfoKV.Value.currPrice;
                    dataGridView1["CurrIncrease", i].Value = fundInfoKV.Value.currPercentageIncrease *100;
                    dataGridView1["DealAmount", i].Value = Math.Round((fundInfoKV.Value.dealAmount/10000),2);
                    //dataGridView1["FieldAmount", i].Value = fundInfoKV.Value.fieldAmount;
                    dataGridView1["CurrEstimateValue", i].Value = Math.Round(fundInfoKV.Value.currEstimateValue,4);
                    dataGridView1["YesterdayValue", i].Value = fundInfoKV.Value.fundYesterDayValue;

                    dataGridView1["EstimateValuePremiumRate", i].Value = Math.Round(fundInfoKV.Value.currEstimateValuePremiumRate * 100,2);
                    dataGridView1["Buy1StaticPremium", i].Value = Math.Round(fundInfoKV.Value.buy1StaticPremium * 100,2);
                    dataGridView1["Buy1DynamicPremium", i].Value = Math.Round(fundInfoKV.Value.buy1DynamicPremium * 100,2);
                    dataGridView1["HeavyIncrease", i].Value = Math.Round(fundInfoKV.Value.heavyIncrease * 100,2);

                    dataGridView1["StockPosition", i].Value = fundInfoKV.Value.stockPosition * 100;
                    dataGridView1["BuyAndSaleStatus", i].Value = fundInfoKV.Value.buyAndSaleStatus;
                    dataGridView1["FundStyle", i].Value = fundInfoKV.Value.fundStyle;

                    if (fundInfoKV.Value.yesterdayEstimateValue > 0 && fundInfoKV.Value.fundYesterDayValue > 0) {
                        dataGridView1["EstimateErrorRateYesterday", i].Value = Math.Round((fundInfoKV.Value.yesterdayEstimateValue - fundInfoKV.Value.fundYesterDayValue) *100  / fundInfoKV.Value.fundYesterDayValue, 2);
                    }

                }
                
                dataGridView1.InvalidateRow(i);
                i++;
                
            }
            this.dataGridView1.Refresh();
            
        }

        /// <summary>
        /// 窗体加载时由子线程执行
        /// </summary>
        private void Init() {
            lock (gFundInfoDict) {
                loadFundFile();
                queryAndCompute(gFundInfoDict);
            }
            this.Invoke(new CallBackDelegate(ShowResult),new Object[] { gFundInfoDict});
            this.Invoke(new CallBackDelegateParam(ShowStatus),new Object[] { "加载完成"} );
        }

        /// <summary>
        /// 窗体加载时由子线程执行
        /// </summary>
        private void RefreshData(Object fundInfoDict )
        {
            lock (gFundInfoDict)
            {
                queryAndCompute((Dictionary<String, FundInfo>)fundInfoDict);
            }
            this.Invoke(new CallBackDelegate(ShowResult), new Object[] { fundInfoDict });
            this.Invoke(new CallBackDelegateParam(ShowStatus), new Object[] { "加载完成" });
        }


        /// <summary>
        /// 初始化时从文件读数据
        /// </summary>
        private int loadFundFile() {
            this.Invoke(new CallBackDelegateParam(ShowStatus), new Object[] { "正在加载文件信息..." });

            //先加载排除的基金列表
            FileStream aFile = new FileStream("exp.txt", FileMode.Open);
            StreamReader sr = new StreamReader(aFile);
            String strLine = sr.ReadLine();
            while (strLine != null)
            {
                if(!expFundInfoDict.ContainsKey(strLine)) expFundInfoDict.Add(strLine, "1");

                strLine = sr.ReadLine();
            }
            sr.Close();

            //加载基金列表
            String path = "a.xlsx";
            DataSet fileData = ExcelReader.ToDataTable(path);
            
            for (int i = 0;i<fileData.Tables[0].Rows.Count;i++) {
                FundInfo fi = new funds.FundInfo();
                fi.fundCode = fileData.Tables[0].Rows[i][0].ToString();
                
                if (fi.fundCode == "" || expFundInfoDict.ContainsKey(fi.fundCode)) continue;

                Dictionary<String,StockInfo> stockList = new Dictionary<String,StockInfo>();
                fi.stockList = stockList;

                //重仓股仓位
                try
                {
                    fi.stockPosition = Convert.ToSingle(fileData.Tables[0].Rows[i][23]) / 100;
                    fi.unHeavyStockPosition = fi.stockPosition - Convert.ToSingle(fileData.Tables[0].Rows[i][22]) / 100;
                    

                    //加载最新净值(一般是上一交易日的净值)
                    if (fileData.Tables[0].Rows[i][24].ToString() == "") continue;

                    fi.fundYesterDayValue = Convert.ToSingle(fileData.Tables[0].Rows[i][24]);

                    //加载前十重仓股
                    for (int j = 0; j < 10; j++) {
                        StockInfo stockInfo = new StockInfo();
                        stockInfo.stockCode = (String)fileData.Tables[0].Rows[i][2*j+2];
                        if (stockInfo.stockCode.Length != 6)
                        {
                            break;
                        }

                        if (!gStockPriceDict.ContainsKey(stockInfo.stockCode)) {
                            gStockPriceDict.Add(stockInfo.stockCode,0);
                        }
                        
                        if (fileData.Tables[0].Rows[i][2 * j + 3] != null) {
                            stockInfo.stockAmount = Convert.ToSingle(fileData.Tables[0].Rows[i][2 * j + 3])/100;
                        }

                        //加载到全局信息
                        stockList.Add(stockInfo.stockCode,stockInfo);
                    
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    continue;
                }
                //加载到全局变量
                gFundInfoDict.Add(fi.fundCode.Split('.')[0], fi);

                //申赎状态，基金类型，如果为空，不影响加到全局变量
                try
                {
                    fi.buyAndSaleStatus = fileData.Tables[0].Rows[i][25].ToString();
                    fi.fundStyle = fileData.Tables[0].Rows[i][26].ToString();

                    //按类型加载基金全局变量
                    if ("股票型基金".Equals(fi.fundStyle)) {
                        gStockFundInfoDict.Add((String)fileData.Tables[0].Rows[i][0], fi);
                    }
                    else if ("债券型基金".Equals(fi.fundStyle)){
                        gBondsFundInfoDict.Add((String)fileData.Tables[0].Rows[i][0], fi);
                    }
                    else if ("混合型基金".Equals(fi.fundStyle))
                    {
                        gMixFundInfoDict.Add((String)fileData.Tables[0].Rows[i][0], fi);
                    }
                    else if ("国际(QDII)基金".Equals(fi.fundStyle))
                    {
                        gQDIIFundInfoDict.Add((String)fileData.Tables[0].Rows[i][0], fi);
                    }
                }
                catch { }

            }

            //读取指数基金信息
            DataSet indexFundFileData = ExcelReader.ToDataTable("index_fund.xlsx");
            for (int i = 0; i < indexFundFileData.Tables[0].Rows.Count; i++)
            {
                if (indexFundFileData.Tables[0].Rows[i][0] == DBNull.Value) continue;
                String fundCode = (String)indexFundFileData.Tables[0].Rows[i][0];
                fundCode = fundCode.Replace(".OF","");
                if (!gFundInfoDict.ContainsKey(fundCode)) {
                    continue;
                }

                String indexCode = (String)indexFundFileData.Tables[0].Rows[i][2];
                if (!indexCode.EndsWith("SH") && !indexCode.EndsWith("SZ")) continue;

                FundInfo fi = gFundInfoDict[fundCode];
                if (fi == null) continue;
                fi.isIndexFund = true;
                fi.indexCode = indexCode;

                if (!gStockPriceDict.ContainsKey(indexCode))
                {
                    gStockPriceDict.Add(indexCode, 0);
                }
            }

                //如果有就读取
            if (File.Exists(yesterdayEstimateValueFileName))
            {
                FileStream fs = new FileStream(yesterdayEstimateValueFileName, FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fs);
                string line = streamReader.ReadLine();
                while (line != null && line.Contains("|")) {
                    string[] info = line.Split('|');
                    if (info[1].Length > 1) {
                        FundInfo tempFundInfo = gFundInfoDict[info[0]];
                        if (tempFundInfo != null) {
                            try
                            {
                                tempFundInfo.yesterdayEstimateValue = (float)Convert.ToDouble(info[1]);
                            }
                            catch (Exception ex) {

                            }
                        }
                    }
                    line = streamReader.ReadLine();

                }
            }
            else {
                //没有则创建
                FileStream fs = new FileStream(yesterdayEstimateValueFileName, FileMode.CreateNew);
                fs.Close();
            }
            return gFundInfoDict.Count;
        }

        /// <summary>
        /// 查询所有股票涨跌幅，放到全局变量
        /// </summary>
        private void queryAllPrice() {

        }


        /// <summary>
        /// 取全局的的基金列表信息，请求网络接口，实时计算，填充信息
        /// </summary>
        private void queryAndCompute(Dictionary<String, FundInfo> fundInfoDict) {
            this.Invoke(new CallBackDelegateParam(ShowStatus), new Object[] { "正在请求实时股价..." });
            //查询指数数据，如上证指数、沪深300、创业板
            String indexParam = "SH:000001|SZ:399006|SH:000016";
            String queryResult = QueryStockPriceByStockAPI(indexParam);
            QueryResult indexQueryResult = JSON.parse<QueryResult>(queryResult);

            if (indexQueryResult != null && indexQueryResult.results != null && indexQueryResult.results.Count > 1)
            {
                sseIndexIncr = Convert.ToSingle(indexQueryResult.results[0][12]);
                geiIndexIncr = Convert.ToSingle(indexQueryResult.results[1][12]);
                sse50IndexIncr = Convert.ToSingle(indexQueryResult.results[2][12]);

            }
            else {
                MessageBox.Show("查询指数涨幅信息异常，后续的涨幅将按指数无涨幅计算");
            }

            //查询接口
            queryAllPrice();

            foreach (var fundInfoKV in fundInfoDict) {
                String[] fullCode = fundInfoKV.Value.fundCode.Split('.');
                if (fullCode.Length < 2) continue;
                queryResult = QuerySingleFundInfoByStockAPI(fullCode[1], fullCode[0]);
                
                //将基金的基本信息加载上
                PaseFundMarketPriceResult(fundInfoKV.Value, queryResult);

                //过滤掉场内停盘基金
                if (fundInfoKV.Value.currPrice == 1 && fundInfoKV.Value.dealAmount == 0 && fundInfoKV.Value.currPercentageIncrease == 0) {
                    continue;
                }

                float rate1 = 0;
                float rate2 = 0;

                //如果是指数基金，直接按指数涨幅*0.95计算
                if (fundInfoKV.Value.isIndexFund)
                {
                    String[] indexFullCode = fundInfoKV.Value.indexCode.Split('.');
                    if (fullCode.Length < 2) continue;
                    String originalResult = QuerySingleFundInfoByStockAPI(indexFullCode[1], indexFullCode[0]);

                    QueryResult indexQr = JSON.parse<QueryResult>(originalResult);

                    if (indexQr != null && indexQr.results != null && indexQr.results.Count > 0)
                    {
                        List<Object> resultList = indexQr.results[0];

                        rate1 = Convert.ToSingle(resultList[36]) * 0.95f;
                        rate2 = 0;
                    }

                }
                else
                {
                    //请求重仓股信息
                    if (fundInfoKV.Value.stockList == null || fundInfoKV.Value.stockList.Count == 0) continue;
                    String queryParam = "";
                    int geiCount = 0; //创业板股票数量，用于判断投资风格
                    foreach (var stockInfoKV in fundInfoKV.Value.stockList)
                    {
                        if (queryParam.Length > 6) queryParam += '|';
                        if (stockInfoKV.Key.StartsWith("6"))
                        {
                            queryParam = queryParam + "SH:";
                        }
                        else
                        {
                            if (stockInfoKV.Key.StartsWith("300"))
                            {
                                geiCount++;
                            }
                            queryParam += "SZ:";
                        }
                        queryParam += stockInfoKV.Key;
                    }

                    //请求十大重仓股实时股价
                    String heavyStockResult = QueryStockPriceByStockAPI(queryParam);


                    //解析和计算实时估值

                    QueryResult qr = JSON.parse<QueryResult>(heavyStockResult);
                    if (qr.results != null || qr.results.Count > 0)
                    {
                        for (int i = 0; i < qr.results.Count; i++)
                        {
                            rate1 += Convert.ToSingle(qr.results[i][12]) * fundInfoKV.Value.stockList[(String)qr.results[i][1]].stockAmount;
                        }
                    }

                    //计算实时估值
                    //先判断风格是大盘还是创业板，有7只及以上创业板的可认为该基金重仓创业板

                    if (geiCount > 6)
                    {
                        rate2 = fundInfoKV.Value.unHeavyStockPosition * geiIndexIncr;

                    }
                    else
                    {
                        rate2 = fundInfoKV.Value.unHeavyStockPosition * (sse50IndexIncr + geiIndexIncr) / 2;
                    }

                }

                fundInfoKV.Value.heavyIncrease = rate1;

                //实时估值等于昨日净值乘以今日估算增长率
                fundInfoKV.Value.currEstimateValue = fundInfoKV.Value.fundYesterDayValue *(1+ rate1 + rate2);

                //溢价率&折价率估算，场内价格-实时估值/实时估值
                fundInfoKV.Value.currEstimateValuePremiumRate = (fundInfoKV.Value.currPrice- fundInfoKV.Value.currEstimateValue) / fundInfoKV.Value.currEstimateValue;

                //买一静态溢价率（买一价 - 基金昨日净值）/ 基金昨日净值
                fundInfoKV.Value.buy1StaticPremium = (fundInfoKV.Value.buy1Price - fundInfoKV.Value.fundYesterDayValue) / fundInfoKV.Value.fundYesterDayValue;

                //买一动态溢价率（买一价 - 基金实时估值）/ 基金实时估值
                fundInfoKV.Value.buy1DynamicPremium = (fundInfoKV.Value.buy1Price - fundInfoKV.Value.currEstimateValue) / fundInfoKV.Value.currEstimateValue;

            }

        }

        /// <summary>
        /// 根据基金代码获取基金、现价、涨幅、买卖盘等初始结果,只支持查单个
        ///
        /// </summary>
        /// <param name="code">基金代码</param>
        /// <returns></returns>
        private String QuerySingleFundInfoByStockAPI(String market,String code) {
            String url = "http://trade.ebscn.com:8888/servlet/json?version=1&funcno=20003&stock_list=";
            String result = HttpClientHelper.RestfulGet(url + market+ ":" +code);
            return result;
        }

        /// <summary>
        /// 查询多个股票的股价信息，参数需要自行拼接:SH:510020,多个以竖线分割。
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private String QueryStockPriceByStockAPI(String list)
        {
            String url = "http://trade.ebscn.com:8888/servlet/json?version=1&funcno=20000&stock_list=";
            String result = HttpClientHelper.GetResponse(url + System.Web.HttpUtility.UrlDecode(list, System.Text.Encoding.UTF8), "UTF-8");

            return result;
        }

        /// <summary>
        /// 解析基金买卖盘结果，填充到对象中
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="originalResult"></param>
        private void PaseFundMarketPriceResult(FundInfo fi, String originalResult) {

            QueryResult queryResult = JSON.parse<QueryResult>(originalResult);

            if (queryResult != null && queryResult.results != null && queryResult.results.Count > 0) {
                List<Object> resultList = queryResult.results[0];
                fi.fundCode = (String)resultList[0];
                fi.currPrice = Convert.ToSingle(resultList[30]);
                fi.currPercentageIncrease = Convert.ToSingle(resultList[36]);
                fi.dealAmount = Convert.ToSingle(resultList[32]);
                //fi.fieldAmount = Convert.ToSingle(resultList[34]);
                fi.fundName = (String)resultList[1];
                fi.buy1Price = Convert.ToSingle(resultList[16]);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ParameterizedThreadStart(RefreshData));
            if ("股票型基金".Equals(fundStyleComboBox.SelectedItem))
            {
                th.Start(gStockFundInfoDict);
            }
            else if ("债券型基金".Equals(fundStyleComboBox.SelectedItem))
            {
                th.Start(gBondsFundInfoDict);
            }
            else if ("混合型基金".Equals(fundStyleComboBox.SelectedItem))
            {
                th.Start(gMixFundInfoDict);
            }
            else if ("国际(QDII)基金".Equals(fundStyleComboBox.SelectedItem))
            {
                th.Start(gQDIIFundInfoDict);
            }
            else {
                th.Start(gFundInfoDict);
            }
            

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSaver.DataGridViewToExcel(dataGridView1);
        }

        private void 保存当前估值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认保存昨日估值吗？点确定将覆盖现有估值文件", "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                //用户选择取消的操作
                return;
            }

            FileStream fs = new FileStream(yesterdayEstimateValueFileName, FileMode.Truncate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs); // 创建写入流

            foreach (var fundInfoKV in gFundInfoDict)
            {
                String value = fundInfoKV.Key + "|" + fundInfoKV.Value.currEstimateValue.ToString();
                sw.WriteLine(value);
            }

            sw.Close(); //关闭文件

            MessageBox.Show("保存完成");

        }
    }
}
