using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace thuexe.Models;

[Table("tblThanhToan")]
public partial class TblThanhToan
{
    [Key]
    [Column("TT_ID")]
    public Guid TtId { get; set; }

    [Column("TT_SoTien", TypeName = "money")]
    public decimal TtSoTien { get; set; }

    [Column("TT_Ngaytao", TypeName = "datetime")]
    public DateTime? TtNgaytao { get; set; }

    [Column("TT_PTThanhToan")]
    [StringLength(64)]
    [Unicode(false)]
    public string TtPtthanhToan { get; set; } = null!;

    [Column("TT_Ghichu")]
    [StringLength(256)]
    public string TtGhichu { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Ngaysua { get; set; }

    [StringLength(64)]
    public string NguoiSua { get; set; } = null!;

    public bool? Active { get; set; }

    [Column("jsondata")]
    public string? Jsondata { get; set; }

    [Column("DT_ID")]
    public Guid? DtId { get; set; }

    [ForeignKey("DtId")]
    [InverseProperty("TblThanhToans")]
    public virtual TblDonThue? Dt { get; set; }
}
