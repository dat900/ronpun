using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnalysisView.Models;

namespace AnalysisView.Controllers
{
    public class HomeController : Controller
    {     
        DW_WatchesEntities dW = new DW_WatchesEntities();
        public ActionResult Index()
        {
            
            var rs_date = (from s in dW.sales_fact
                           join t in dW.time_by_day on s.time_id equals t.time_id
                           orderby t.time_id descending
                           select new
                               {
                                   date = t.the_day,
                                   sotien = s.so_tien
                               }).Take(10);
            ViewBag._date = rs_date.Select(n=>n.date).ToArray();
            ViewBag.so_tien = rs_date.Select(n=>n.sotien).ToArray();
            return View();
        }
        public ActionResult Customer()
        {
            var rs = dW.khach_hang_sales.OrderByDescending(n=>n.so_tien).Take(10);
            ViewBag.tenkh = rs.Select(n => n.ten_kh).ToArray();
            ViewBag.so_tien = rs.Select(n=>n.so_tien).ToArray();
            return View();
        }
        public ActionResult Product()
        {
            var rs = dW.dong_ho_sales.OrderByDescending(n => n.so_tien);
            ViewBag.tendh = rs.Select(n => n.ten_dh).ToArray();
            ViewBag.so_tien = rs.Select(n => n.so_tien).ToArray();
            return View();
        }
        public ActionResult Top_Brand()
        {
            var rs_brand = from dhs in dW.dong_ho_sales
                           join dh in dW.dong_ho on dhs.masp equals dh.masp
                           group dhs by new { dh.thuong_hieu } into pg
                           select new 
                           {
                               pg.Key.thuong_hieu,
                               so_tien = pg.Sum(n=>n.so_tien)
                           };
            ViewBag.thuong_hieu = rs_brand.Select(n=>n.thuong_hieu);
            ViewBag.so_tien = rs_brand.Select(n =>n.so_tien);
            return View();
        }
        [HttpPost]
        public ActionResult Brand_Detail(string mathuonghieu)
        {
            if (mathuonghieu != null)
            {
                var rs_query = from s in dW.sales_fact
                               join d in dW.dong_ho on s.masp equals d.masp
                               where d.thuong_hieu == mathuonghieu
                               orderby s.so_tien descending
                               group s by new { d.ten_sp } into gp
                               select new
                               {
                                   tendh = gp.Key.ten_sp,
                                   so_tien = gp.Sum(n => n.so_tien)
                               };
                return Json(new {tendh = rs_query.Select(n=>n.tendh).ToArray(), so_tien = rs_query.Select(n=>n.so_tien).ToArray() }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        public ActionResult Sales()
        {
            var rs = from s in dW.sales_fact
                     join t in dW.time_by_day on s.time_id equals t.time_id
                     join d in dW.dong_ho on s.masp equals d.masp
                     orderby s.time_id ascending
                     select new Sales_fact_Cube {
                            ten_dh = d.ten_sp,
                            loai = d.loai,
                            thuonghieu = d.thuong_hieu,
                            soluong = s.so_luong,
                            sotien = s.so_tien,
                            _date = t.the_date,
                            _week = t.week_of_year,
                            _month = t.the_month,
                            _quarter = t.quater,
                            _year = t.the_year
                        };
            
            return View(rs.ToList());
        }
        public ActionResult Cus_Report()
        {
            var rp_data = (from kh_s in dW.khach_hang_sales
                          join k in dW.khach_hang on kh_s.makh equals k.makh
                          select new khach_hang_report
                          {
                              tenkh = kh_s.ten_kh,
                              diachi = k.dia_chi,
                              soluong = kh_s.so_luong,
                              sotien = kh_s.so_tien
                          });
            return View(rp_data.ToList());
        }
        public ActionResult Watches_Report()
        {
            var rp_watches_data = (from dh_s in dW.dong_ho_sales join d in dW.dong_ho on dh_s.masp equals d.masp
                                   select new dong_ho_report
                                   {
                                       tendh = dh_s.ten_dh,
                                       thuonghieu = d.thuong_hieu,
                                       soluong = dh_s.so_luong,
                                       sotien = dh_s.so_tien
                                   });
            return View(rp_watches_data.ToList());
        }
    }
}