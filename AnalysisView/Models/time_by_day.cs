//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnalysisView.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class time_by_day
    {
        public time_by_day()
        {
            this.sales_fact = new HashSet<sales_fact>();
        }
    
        public int time_id { get; set; }
        public Nullable<System.DateTime> the_date { get; set; }
        public string the_day { get; set; }
        public Nullable<int> the_month { get; set; }
        public Nullable<int> the_year { get; set; }
        public Nullable<int> day_of_month { get; set; }
        public Nullable<int> week_of_year { get; set; }
        public Nullable<int> month_of_year { get; set; }
        public Nullable<int> quater { get; set; }
        public Nullable<int> day_of_week { get; set; }
    
        public virtual day day { get; set; }
        public virtual ICollection<sales_fact> sales_fact { get; set; }
    }
}
