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
    
    public partial class khach_hang_sales
    {
        public int makh { get; set; }
        public string ten_kh { get; set; }
        public int so_luong { get; set; }
        public decimal so_tien { get; set; }
    
        public virtual khach_hang khach_hang { get; set; }
    }
}
