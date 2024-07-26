using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace thuexe.Models;

[Table("tblPhanQuyen")]
public partial class TblPhanQuyen
{
    [Key]
    [Column("PQ_ID")]
    public Guid PqId { get; set; }

    [Column("PQ_HoTen")]
    [StringLength(128)]
    public string PqHoTen { get; set; } = null!;

    [Column("PQ_Quyen")]
    [StringLength(6)]
    [Unicode(false)]
    public string? PqQuyen { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Ngaysua { get; set; }

    [StringLength(64)]
    public string NguoiSua { get; set; } = null!;

    public bool? Active { get; set; }

    [Column("jsondata")]
    public string? Jsondata { get; set; }

    [InverseProperty("Pq")]
    public virtual ICollection<TblQuanLy> TblQuanLies { get; set; } = new List<TblQuanLy>();
}
