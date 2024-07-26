using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace thuexe.Models;

[Table("tblDonThue")]
public partial class TblDonThue
{
    [Key]
    [Column("DT_id")]
    public Guid DtId { get; set; }

    [Column("DT_NgayThue", TypeName = "datetime")]
    public DateTime DtNgayThue { get; set; }

    [Column("DT_Thoigianthue")]
    [StringLength(64)]
    public string? DtThoigianthue { get; set; }

    [Column("DT_Ngaytra", TypeName = "datetime")]
    public DateTime DtNgaytra { get; set; }

    [Column("DT_TongTien", TypeName = "money")]
    public decimal DtTongTien { get; set; }

    [Column("DT_Chietkhau")]
    public double DtChietkhau { get; set; }

    [Column("DT_Thue")]
    public double? DtThue { get; set; }

    [Column("DT_AnhCCCD")]
    [StringLength(64)]
    public string DtAnhCccd { get; set; } = null!;

    [Column("DT_TienCoc", TypeName = "money")]
    public decimal DtTienCoc { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Ngaysua { get; set; }

    [StringLength(64)]
    public string NguoiSua { get; set; } = null!;

    public bool? Active { get; set; }

    [Column("jsondata")]
    public string? Jsondata { get; set; }

    [Column("KH_ID")]
    public Guid? KhId { get; set; }

    [ForeignKey("KhId")]
    [InverseProperty("TblDonThues")]
    public virtual TblKhachHang? Kh { get; set; }

    [InverseProperty("Dt")]
    public virtual ICollection<TblDtct> TblDtcts { get; set; } = new List<TblDtct>();

    [InverseProperty("Dt")]
    public virtual ICollection<TblThanhToan> TblThanhToans { get; set; } = new List<TblThanhToan>();
}
