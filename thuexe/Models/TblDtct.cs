using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace thuexe.Models;

[Table("tblDTCT")]
public partial class TblDtct
{
    [Key]
    [Column("CT_id")]
    public Guid CtId { get; set; }

    [Column("CT_Soluong")]
    public int CtSoluong { get; set; }

    [Column("CT_Gia", TypeName = "money")]
    public decimal CtGia { get; set; }

    [Column("CT_ThanhTien", TypeName = "money")]
    public decimal CtThanhTien { get; set; }

    [Column("CT_GhiChu", TypeName = "text")]
    public string? CtGhiChu { get; set; }

    [Column("CT_TinhTrang")]
    [StringLength(256)]
    public string? CtTinhTrang { get; set; }

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
    [InverseProperty("TblDtcts")]
    public virtual TblDonThue? Dt { get; set; }
}
