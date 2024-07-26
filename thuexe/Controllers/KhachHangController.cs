using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using thuexe.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace thuexe.Controllers
{
    public class SearchRequest
    {
        public string SearchTerm { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly DBQLThuexe _context;

        public KhachHangController(DBQLThuexe context)
        {
            _context = context;
        }

        // Lấy danh sách khách hàng
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetList()
        {
            var khachHangs = await _context.TblKhachHangs.ToListAsync();
            return Ok(new { data = khachHangs });
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> GetSearch([FromBody] SearchRequest request)
        {
            if (string.IsNullOrEmpty(request.SearchTerm))
            {
                return BadRequest("Search term is required.");
            }

            var khachHangs = await _context.TblKhachHangs
                .Where(kh => kh.KhHoTen.Contains(request.SearchTerm) ||
                              kh.KhDiaChi.Contains(request.SearchTerm) ||
                              kh.KhSoDt.Contains(request.SearchTerm) ||
                              kh.KhCccd.Contains(request.SearchTerm) ||
                              kh.KhTendangnhap.Contains(request.SearchTerm))
                .ToListAsync();

            return Ok(new { data = khachHangs });
        }


        // Thêm mới khách hàng
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> AddFunction(string ten, string dc, string tel, string cccd, string login, string mk)
        {
            TblKhachHang khachHang = new TblKhachHang();
            khachHang.KhId = Guid.NewGuid();
            khachHang.KhHoTen = ten;
            khachHang.KhDiaChi = dc;
            khachHang.KhSoDt = tel;
            khachHang.KhCccd = cccd;
            khachHang.KhMatkhau = mk;
            khachHang.KhTendangnhap = login;
            khachHang.NguoiSua = ten;
            try
            {
                khachHang.KhId = Guid.NewGuid();

                _context.TblKhachHangs.Add(khachHang);
                await _context.SaveChangesAsync();

                return Ok(new { data = khachHang });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Đã xảy ra lỗi khi thêm khách hàng: {ex.Message}" });
            }
        }

        // Sửa khách hàng
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> EditFunction(Guid khId, string ten, string dc, string tel, string cccd, string login, string mk)
        {
            if (khId == Guid.Empty)
            {
                return BadRequest(new { message = "ID khách hàng không hợp lệ." });
            }

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(dc) || string.IsNullOrEmpty(tel) || string.IsNullOrEmpty(cccd) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(mk))
            {
                return BadRequest(new { message = "Tất cả các trường là bắt buộc." });
            }

            var existingKhachHang = await _context.TblKhachHangs.FindAsync(khId);
            if (existingKhachHang == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng." });
            }

            existingKhachHang.KhHoTen = ten;
            existingKhachHang.KhDiaChi = dc;
            existingKhachHang.KhSoDt = tel;
            existingKhachHang.KhCccd = cccd;
            existingKhachHang.KhTendangnhap = login;
            existingKhachHang.KhMatkhau = mk;
            existingKhachHang.NguoiSua = "admin";

            try
            {
                _context.TblKhachHangs.Update(existingKhachHang);
                await _context.SaveChangesAsync();
                return Ok(new { data = existingKhachHang });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Đã xảy ra lỗi khi cập nhật khách hàng: {ex.Message}" });
            }
        }

        // Xóa khách hàng
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteFunction(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new { message = "ID khách hàng không hợp lệ." });
            }

            var khachHang = await _context.TblKhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound(new { message = "Không tìm thấy khách hàng." });
            }

            try
            {
                _context.TblKhachHangs.Remove(khachHang);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Xóa thành công.", data = khachHang });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Đã xảy ra lỗi khi xóa khách hàng: {ex.Message}" });
            }
        }
    }
}
