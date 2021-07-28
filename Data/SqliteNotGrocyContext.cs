using NotGrocy;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NotGrocy.Models;

class SqliteNotGrocyContext : NotGrocyContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=not-grocy.db");
}