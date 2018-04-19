using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funds
{
    public class FundInfo
    {
        public String fundCode;//基金代码
        public String fundName;//基金简称
        public float currPrice;//当前价格
        public float currPercentageIncrease;//当前涨幅
        public double dealAmount;//成交量
        public double fieldAmount;//场内份额
        public double fieldNewAmout;//场内新增
        public float fundYesterDayValue;//昨日净值
        public Dictionary<String,StockInfo> stockList;//重仓股信息
        public float stockPosition;//股票总仓位
        public float buy1Price;//买一价格
        public float unHeavyStockPosition; //非重仓股仓位，公式为股票总仓位减去前十重仓股仓位
        public float currEstimateValue; //实时估价
        public float buy1StaticPremium; //买一静态溢价率
        public float buy1DynamicPremium; //买一动态溢价率
        public float buy1DynamicReduceAnnual; //买一动态折价率年化
        public float heavyIncrease; //重仓股涨幅
        public float currEstimateValuePremiumRate; //估值溢价率

        public String buyAndSaleStatus; //申赎状态
        public String fundStyle; //基金类型
    }

    public class StockInfo {
        public String stockCode;
        public float stockAmount;
    }
}
