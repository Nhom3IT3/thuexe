using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace thuexe.Models;

[Table("tblLog")]
public partial class TblLog
{
    [Key]
    [Column("LOG_ID")]
    public Guid LogId { get; set; }

    [Column("LOG_bang")]
    [StringLength(128)]
    public string LogBang { get; set; } = null!;

    [Column("LOG_BangID")]
    public Guid LogBangId { get; set; }

    [Column("LOG_hoatdong")]
    [StringLength(128)]
    public string LogHoatdong { get; set; } = null!;

    [StringLength(64)]
    public string NguoiTao { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Ngaythuchien { get; set; }

    [Column("jsondata")]
    public string? Jsondata { get; set; }
}
