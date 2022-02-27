﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class NhapKhoController : Controller
    {
        DatabaseEntities db = new DatabaseEntities();
        // GET: NhapKho
        public ActionResult Index(int page, string s, string fDate, string tDate)
        {
            DateTime fromDate = fDate != null && fDate.Length > 0 ? Convert.ToDateTime(fDate) : DateTime.Now;
            DateTime toDate = tDate != null && tDate.Length > 0 ? Convert.ToDateTime(tDate) : DateTime.Now;
            //lấy danh sách
            IOrderedQueryable dataSet = db.TDONHANGs.Where(x =>
                ((s != null && s.Length > 0 && x.NAME.Contains(s)) || s == null || s.Length == 0)
                && (x.NGAY >= fromDate && x.NGAY <= toDate)
                && x.LOAI == 1
            ).OrderBy(x => x.NAME);

            //tính toán phân trang
            IQueryable<TDONHANG> temp = dataSet as IQueryable<TDONHANG>;
            ViewBag.totalItem = temp.ToList().Count;
            ViewBag.numberOfPage = Math.Ceiling((double)ViewBag.totalItem / Contant.pageSize);
            ViewBag.currentPage = page;
            ViewBag.s = s;
            ViewBag.fDate = fromDate.ToString("yyyy-MM-dd");
            ViewBag.tDate = toDate.ToString("yyyy-MM-dd");
            List<TDONHANG> lst = temp.Skip((page - 1) * Contant.pageSize).Take(Contant.pageSize).ToList();
            return View(lst);
        }

        public ActionResult Delete(string id)
        {
            string error = "";
            try
            {
                db.TDONHANGCHITIETs.RemoveRange(db.TDONHANGCHITIETs.Where(x => x.TDONHANGID == id).ToList());
                TDONHANG entry = db.TDONHANGs.Where(x => x.ID == id).FirstOrDefault();
                db.TDONHANGs.Remove(entry);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Content(error);
        }

        string dateToString(DateTime? tmp)
        {
            DateTime time = Convert.ToDateTime(tmp);
            return time.Year + "-" + (time.Month.ToString().Length == 1 ? "0" : "") + time.Month + "-" + (time.Day.ToString().Length == 1 ? "0" : "") + time.Day;
        }

        [HttpGet]
        public ActionResult AddOrUpdate(string id)
        {
            TDONHANG dhRow = db.TDONHANGs.Where(x => x.ID == id).FirstOrDefault();
            string error = "";
            try
            {
                if (dhRow == null)
                {
                    dhRow = new TDONHANG();
                    dhRow.ID = Guid.NewGuid().ToString();
                    dhRow.NGAY = DateTime.Now;
                    dhRow.NAME = "Tự động";
                }
                ViewBag.NGAY = dateToString(dhRow.NGAY);
                ViewBag.nhaCcs = db.DNHACUNGCAPs.OrderBy(x => x.NAME).ToList();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return View(dhRow);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(string id, string json)
        {
            TDONHANG dhRow = db.TDONHANGs.Where(x => x.ID == id).FirstOrDefault();
            string error = "";
            try
            {
                //if (dhRow == null)
                //{
                //    dhRow = new TDONHANG();
                //    dhRow.ID = Guid.NewGuid().ToString();
                //    dhRow.NGAY = DateTime.Now;
                //    dhRow.NAME = "Tự động";
                //}
                //ViewBag.NGAY = dateToString(dhRow.NGAY);
                //ViewBag.nhaCcs = db.DNHACUNGCAPs.OrderBy(x => x.NAME).ToList();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Content(error);
        }

        string GenCodeHD(string startStr, int loai)
        {
            string code = "", temp = "";
            //lấy số thứ tự
            List<string> lst = db.Database.SqlQuery<string>("SELECT CODE FROM TDONHANG WHERE CODE LIKE '" + startStr + "%'").ToList();
            int max = 0;
            foreach (string item in lst)
            {
                int value = 0;
                //temp = item.Replace(nhomHang.CODE, "");
                value = Convert.ToInt32(temp);
                max = value > max ? value : max;
            }
            max = max + 1;
            int maxLen = 6;
            temp = "";
            while (temp.Length + max.ToString().Length < maxLen)
            {
                temp += "0";
            }
            temp += max.ToString();
            code += temp;
            return code;
        }
    }
}