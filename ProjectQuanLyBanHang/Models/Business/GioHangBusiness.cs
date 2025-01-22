using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AngleSharp.Html;

namespace ProjectQuanLyBanHang.Models.Business
{
    public class GioHangBusiness
    {
        QuanLyBanHangDbContext db = new QuanLyBanHangDbContext();

        public void ThemGioHang(int taiKhoanId)
        {
            GioHang gh = new GioHang()
            {
                TaiKhoanId = taiKhoanId,
            };
            db.gioHangs.Add(gh);
            db.SaveChanges();
        }

        public void ThemSanPhamVaoGio(int taiKhoanId, int sanPhamId, bool giamSoLuong = false, bool tangSoLuong = false)
        {
            GioHang gh = db.gioHangs.Where(o => o.TaiKhoanId == taiKhoanId).FirstOrDefault();
            SanPhamChiTiet spct = db.sanPhamChiTiets.Where(o => o.SanPhamChiTietId == sanPhamId).FirstOrDefault();
            if (gh == null)
            {
                ThemGioHang(taiKhoanId);
                gh = db.gioHangs.Where(o => o.TaiKhoanId == taiKhoanId).FirstOrDefault();
            }
            GioHangChiTiet ghct = db.gioHangChiTiets.Where(o => o.SanPhamChiTietId == sanPhamId).FirstOrDefault();
            if (ghct != null)
            {
                if (tangSoLuong == true)
                {
                    ghct.SoLuong = ghct.SoLuong + 1;
                }
                else if (giamSoLuong == true)
                {
                    ghct.SoLuong = ghct.SoLuong - 1;
                }
                ghct.ThanhTien = (int)(ghct.SoLuong * spct.GiaTien);
                db.Entry(ghct).State = EntityState.Modified;
            }
            else
            {
                ghct = new GioHangChiTiet()
                {
                    GioHangId = gh.GioHangId,
                    SanPhamChiTietId = sanPhamId,
                    SoLuong = 1,
                    ThanhTien = spct.GiaTien
                };
                db.gioHangChiTiets.Add(ghct);
            }
            db.SaveChanges();
        }

        public void SuaGioHang(int sanPhamId, int taiKhoanId, int soLuong)
        {

        }
    }
}