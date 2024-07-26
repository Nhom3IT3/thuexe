using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace thuexe.Models;

[Table("tblQuanLy")]
public partial class TblQuanLy
{
    [Key]
    [Column("QL_ID")]
    public Guid QlId { get; set; }

    [Column("QL_Tendangnhap")]
    [StringLength(64)]
    public string QlTendangnhap { get; set; } = null!;

    [Column("QL_Matkhau")]
    [StringLength(256)]
    public string QlMatkhau { get; set; } = null!;

    [Column("QL_HoTen")]
    [StringLength(128)]
    public string QlHoTen { get; set; } = null!;

    [Column("QL_DiaChi")]
    [StringLength(200)]
    public string QlDiaChi { get; set; } = null!;

    [Column("QL_SoDT")]
    [StringLength(20)]
    [Unicode(false)]
    public string? QlSoDt { get; set; }

    [Column("QL_Email")]
    [StringLength(64)]
    [Unicode(false)]
    public string? QlEmail { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Ngaysua { get; set; }

    [StringLength(64)]
    public string NguoiSua { get; set; } = null!;

    public bool? Active { get; set; }

    [Column("jsondata")]
    public string? Jsondata { get; set; }

    [Column("PQ_ID")]
    public Guid? PqId { get; set; }

    [ForeignKey("PqId")]
    [InverseProperty("TblQuanLies")]
    public virtual TblPhanQuyen? Pq { get; set; }
}
