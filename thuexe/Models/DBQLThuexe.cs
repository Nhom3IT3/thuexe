using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace thuexe.Models;

public partial class DBQLThuexe : DbContext
{
    public DBQLThuexe()
    {
    }

    public DBQLThuexe(DbContextOptions<DBQLThuexe> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDonThue> TblDonThues { get; set; }

    public virtual DbSet<TblDtct> TblDtcts { get; set; }

    public virtual DbSet<TblKhachHang> TblKhachHangs { get; set; }

    public virtual DbSet<TblLoaiXe> TblLoaiXes { get; set; }

    public virtual DbSet<TblLog> TblLogs { get; set; }

    public virtual DbSet<TblPhanQuyen> TblPhanQuyens { get; set; }

    public virtual DbSet<TblQuanLy> TblQuanLies { get; set; }

    public virtual DbSet<TblThanhToan> TblThanhToans { get; set; }

    public virtual DbSet<TblXe> TblXes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDonThue>(entity =>
        {
            entity.HasKey(e => e.DtId).HasName("PK__tblDonTh__1493C7CB6EE27F33");

            entity.ToTable("tblDonThue", tb =>
                {
                    tb.HasTrigger("trgLogDonThue");
                    tb.HasTrigger("trgUpdateDonThue");
                });

            entity.Property(e => e.DtId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.DtThue).HasDefaultValue(0.10000000000000001);
            entity.Property(e => e.Ngaysua).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Kh).WithMany(p => p.TblDonThues).HasConstraintName("FK__tblDonThu__KH_ID__5629CD9C");
        });

        modelBuilder.Entity<TblDtct>(entity =>
        {
            entity.HasKey(e => e.CtId).HasName("PK__tblDTCT__DC4E3A73E8198816");

            entity.ToTable("tblDTCT", tb =>
                {
                    tb.HasTrigger("trgLogDTCT");
                    tb.HasTrigger("trgUpdateDTCT");
                });

            entity.Property(e => e.CtId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Ngaysua).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Dt).WithMany(p => p.TblDtcts).HasConstraintName("FK__tblDTCT__DT_ID__5BE2A6F2");
        });

        modelBuilder.Entity<TblKhachHang>(entity =>
        {
            entity.HasKey(e => e.KhId).HasName("PK__tblKhach__2415FB213346D81E");

            entity.ToTable("tblKhachHang", tb =>
                {
                    tb.HasTrigger("trgLogKhachHang");
                    tb.HasTrigger("trgUpdateKhachHang");
                });

            entity.Property(e => e.KhId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.KhCccd).IsFixedLength();
            entity.Property(e => e.KhSoDt).IsFixedLength();
            entity.Property(e => e.Ngaysua).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblLoaiXe>(entity =>
        {
            entity.HasKey(e => e.LId).HasName("PK__tblLoaiX__420BA09EA7AC358F");

            entity.ToTable("tblLoaiXe", tb =>
                {
                    tb.HasTrigger("trgLogLoaiXe");
                    tb.HasTrigger("trgUpdateLoaiXe");
                });

            entity.Property(e => e.LId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Ngaysua).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__tblLog__4364C8825E3C1254");

            entity.Property(e => e.LogId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Ngaythuchien).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblPhanQuyen>(entity =>
        {
            entity.HasKey(e => e.PqId).HasName("PK__tblPhanQ__50D8B4820D3AC448");

            entity.ToTable("tblPhanQuyen", tb =>
                {
                    tb.HasTrigger("trgLogPhanQuyen");
                    tb.HasTrigger("trgUpdatePhanQuyen");
                });

            entity.Property(e => e.PqId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Ngaysua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PqQuyen).IsFixedLength();
        });

        modelBuilder.Entity<TblQuanLy>(entity =>
        {
            entity.HasKey(e => e.QlId).HasName("PK__tblQuanL__8D2CF9ED46A840F5");

            entity.ToTable("tblQuanLy", tb =>
                {
                    tb.HasTrigger("trgLogQuanLy");
                    tb.HasTrigger("trgUpdateQuanLy");
                });

            entity.Property(e => e.QlId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Ngaysua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.QlSoDt).IsFixedLength();

            entity.HasOne(d => d.Pq).WithMany(p => p.TblQuanLies).HasConstraintName("FK__tblQuanLy__PQ_ID__4F7CD00D");
        });

        modelBuilder.Entity<TblThanhToan>(entity =>
        {
            entity.HasKey(e => e.TtId).HasName("PK__tblThanh__E9D60397E88386BC");

            entity.ToTable("tblThanhToan", tb =>
                {
                    tb.HasTrigger("trgLogThanhToan");
                    tb.HasTrigger("trgUpdateThanhToan");
                });

            entity.Property(e => e.TtId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Ngaysua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TtNgaytao).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Dt).WithMany(p => p.TblThanhToans).HasConstraintName("FK__tblThanhT__DT_ID__628FA481");
        });

        modelBuilder.Entity<TblXe>(entity =>
        {
            entity.HasKey(e => e.XId).HasName("PK__tblXe__BA93AA0C3EF423BB");

            entity.ToTable("tblXe", tb =>
                {
                    tb.HasTrigger("trgLogXe");
                    tb.HasTrigger("trgUpdateXe");
                });

            entity.Property(e => e.XId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Ngaysua).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.LIdNavigation).WithMany(p => p.TblXes).HasConstraintName("FK__tblXe__L_ID__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
