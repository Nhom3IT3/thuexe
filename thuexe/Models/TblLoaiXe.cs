using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace thuexe.Models;

[Table("tblLoaiXe")]
public partial class TblLoaiXe
{
    [Key]
    [Column("L_ID")]
    public Guid LId { get; set; }

    [Column("L_Tenphuogtien")]
    [StringLength(128)]
    public string LTenphuogtien { get; set; } = null!;

    [Column("L_TenLoaixe")]
    [StringLength(128)]
    public string LTenLoaixe { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Ngaysua { get; set; }

    [StringLength(64)]
    public string NguoiSua { get; set; } = null!;

    public bool? Active { get; set; }

    [Column("jsondata")]
    public string? Jsondata { get; set; }

    [InverseProperty("LIdNavigation")]
    public virtual ICollection<TblXe> TblXes { get; set; } = new List<TblXe>();
}
