using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnalysisView.Models
{
    public class Sales_fact_Cube
    {
        public string ten_dh { set; get; }
        public string loai { get; set; }
        public string thuonghieu { set; get; }
        public int soluong { set; get; }
        public decimal sotien { set; get; }
        public DateTime? _date { set; get; }
        public int? _week { get; set; }
        public int? _month { get; set; }
        public int? _quarter { set; get; }
        public int? _year { get; set; }
    }
}