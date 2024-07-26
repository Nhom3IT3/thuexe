using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace thuexe.Models;

[Table("tblKhachHang")]
public partial class TblKhachHang
{
    [Key]
    [Column("KH_ID")]
    public Guid KhId { get; set; }

    [Column("KH_HoTen")]
    [StringLength(128)]
    public string KhHoTen { get; set; } = null!;

    [Column("KH_DiaChi")]
    [StringLength(200)]
    public string KhDiaChi { get; set; } = null!;

    [Column("KH_SoDT")]
    [StringLength(20)]
    [Unicode(false)]
    public string KhSoDt { get; set; } = null!;

    [Column("KH_CCCD")]
    [StringLength(20)]
    [Unicode(false)]
    public string KhCccd { get; set; } = null!;

    [Column("KH_Tendangnhap")]
    [StringLength(100)]
    public string KhTendangnhap { get; set; } = null!;

    [Column("KH_Matkhau")]
    [StringLength(256)]
    public string KhMatkhau { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Ngaysua { get; set; }

    [StringLength(64)]
    public string NguoiSua { get; set; } = null!;

    public bool? Active { get; set; }

    [Column("jsondata")]
    public string? Jsondata { get; set; }

    [InverseProperty("Kh")]
    public virtual ICollection<TblDonThue> TblDonThues { get; set; } = new List<TblDonThue>();
}
