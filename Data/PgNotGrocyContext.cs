using NotGrocy;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NotGrocy.Models;
class PgNotGrocyContext : NotGrocyContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Data Source=not-grocy.db");
}