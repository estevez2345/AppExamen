using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppCelulares.Entidades;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public DbSet<AppCelulares.Entidades.Celular> Celulares { get; set; } = default!;

    public DbSet<AppCelulares.Entidades.Modelo> Modelos { get; set; } = default!;

}
