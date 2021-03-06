﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACN_ver_2.Models;

namespace DACN_ver_2.Controllers
{
    public class KinhdoanhController : Controller
    {
        DatabaseClassesDataContext data = new DatabaseClassesDataContext();
        // GET: Kinhdoanh
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kinhdoanh/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kinhdoanh/Create
        public ActionResult ThemPYC()
        {
            ViewData["nv"] = new SelectList(data.NHANVIENs.ToList().OrderBy(s=>s.TENNV).Where(s=>s.PHONGBAN.ID_PHONGBAN == 2), "ID_NHANVIEN", "TENNV");
            ViewData["kh"] = new SelectList(data.KHACHHANGs.ToList().OrderBy(s => s.TENKH), "ID_KH", "TENKH");
            ViewData["lts"] = new SelectList(data.LOAITAISANs.ToList().OrderBy(s => s.TEN), "ID_LOAITAISAN", "TEN");
            return View();
        }

        // POST: Kinhdoanh/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemPYC(FormCollection collection, PHIEUYEUCAU pyc)
        {
            //try
            //{
                //TODO: Add insert logic here
                var nv = collection["nv"];
                var lts = collection["lts"];
                var kh = collection["kh"];
                //no lỗi ngay đây. nếu chặn lại thì ko sao.
                pyc.ID_NHANVIEN = int.Parse(nv);
                pyc.ID_LOAITAISAN = int.Parse(lts);
                pyc.ID_KH = int.Parse(kh);
                pyc.NGAYTAO = DateTime.Now;
                pyc.TRANGTHAI = true;
                data.PHIEUYEUCAUs.InsertOnSubmit(pyc);
                data.SubmitChanges();
                return RedirectToAction("ThemPYC");
            //}
            //catch
            //{

            //    ViewData["nv"] = new SelectList(data.NHANVIENs.ToList().OrderBy(s => s.TENNV), "ID_NHANVIEN", "TENNV");
            //    ViewData["kh"] = new SelectList(data.KHACHHANGs.ToList().OrderBy(s => s.TENKH), "ID_KH", "TENKH");
            //    ViewData["lts"] = new SelectList(data.LOAITAISANs.ToList().OrderBy(s => s.TEN), "ID_LOAITAISAN", "TEN");
            //    return View();
            //}
        }


        //Chứng thư
        public ActionResult ThemCT()
        {
            return View();
        }

        // POST: Kinhdoanh/Create
        [HttpPost]
        public ActionResult ThemCT(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kinhdoanh/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kinhdoanh/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kinhdoanh/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kinhdoanh/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // danh sahv khach hang
        public ActionResult Danhsachkhachhang()
        {
            var danhsach = data.KHACHHANGs
                .ToList()
                .OrderBy(s => s.ID_KH);
            return View(danhsach);
        }

        public ActionResult Themkhachhang()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Themkhachhang(KHACHHANG kh)
        {
            try
            {
                // TODO: Add insert logic here
                kh.NGAYTAO = DateTime.Now;
                kh.TRANGTHAI = true;
                data.KHACHHANGs.InsertOnSubmit(kh);
                data.SubmitChanges();
                return RedirectToAction("Danhsachkhachhang");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Suakhachhang(int id)
        {
            var spb = data.KHACHHANGs.FirstOrDefault(s => s.ID_KH == id);
            return PartialView(spb);
        }
        [HttpPost]
        public ActionResult Suakhachhang(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                KHACHHANG pb = data.KHACHHANGs.FirstOrDefault(s => s.ID_KH == id);
                pb.NGAYSUA = DateTime.Now;
                UpdateModel(pb);
                data.SubmitChanges();
                return RedirectToAction("Danhsachkhachhang");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Xoakhachhang(int id)
        {
            var xpb = data.KHACHHANGs
                .FirstOrDefault(s => s.ID_KH == id);
            return PartialView(xpb);
        }

        // POST: asdas/Delete/5
        [HttpPost]
        public ActionResult Xoakhachhang(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                KHACHHANG pb = data.KHACHHANGs.FirstOrDefault(s => s.ID_KH == id);
                data.KHACHHANGs.DeleteOnSubmit(pb);
                data.SubmitChanges();
                return RedirectToAction("Danhsachkhachhang");
            }
            catch
            {
                return View();
            }
        }

    }
}
