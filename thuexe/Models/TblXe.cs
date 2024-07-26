using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace thuexe.Models;

[Table("tblXe")]
public partial class TblXe
{
    [Key]
    [Column("X_ID")]
    public Guid XId { get; set; }

    [Column("X_Hangxe")]
    [StringLength(64)]
    public string XHangxe { get; set; } = null!;

    [Column("X_Tenxe")]
    [StringLength(128)]
    public string XTenxe { get; set; } = null!;

    [Column("X_BienSoxe")]
    [StringLength(32)]
    public string XBienSoxe { get; set; } = null!;

    [Column("X_Doixe")]
    [StringLength(32)]
    public string XDoixe { get; set; } = null!;

    [Column("X_Sohieuxe")]
    [StringLength(32)]
    public string XSohieuxe { get; set; } = null!;

    [Column("X_Giaxe", TypeName = "money")]
    public decimal XGiaxe { get; set; }

    [Column("X_TinhTrangxe")]
    [StringLength(256)]
    public string XTinhTrangxe { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Ngaysua { get; set; }

    [StringLength(64)]
    public string NguoiSua { get; set; } = null!;

    public bool? Active { get; set; }

    [Column("jsondata")]
    public string? Jsondata { get; set; }

    [Column("L_ID")]
    public Guid? LId { get; set; }

    [ForeignKey("LId")]
    [InverseProperty("TblXes")]
    public virtual TblLoaiXe? LIdNavigation { get; set; }
}
