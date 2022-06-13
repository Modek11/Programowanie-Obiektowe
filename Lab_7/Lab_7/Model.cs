using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class WypozyczalniaContext : DbContext
{
    public DbSet<KlasyPojazdow> KlasyPojazdow { get; set; }
    public DbSet<Samochody> Samochody { get; set; }
    public DbSet<Uzytkownicy> Uzytkownicy { get; set; }
    public DbSet<Wypozyczone> Wypozyczone { get; set; }

    public string ConnectionString { get; }

    public WypozyczalniaContext(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(this.ConnectionString);
    }
}

public class KlasyPojazdow
{
    public int Id { get; set; }
    public string Klasa { get; set; }
    public short LataPrawaJazdy { get; set; }
}

public class Samochody
{
    public int Id { get; set; }
    public int Id_KlasaPojazdu { get; set; }
    public string Marka { get; set; }
    public string Model { get; set; }
    public string Generacja { get; set; }
    public short Rocznik { get; set; }
    public short MocKM { get; set; }
    public decimal CenaDoba { get; set; }
    public decimal CenaDlugoTerm { get; set; }
}

public class Uzytkownicy
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pesel { get; set; }
    public int NrTelefonu { get; set; }
    public string Email { get; set; }
    public string Haslo { get; set; }
    public short LataPrawaJazdy { get; set; }
    public bool CzyPracownik { get; set; }
}

[Keyless]
public class Wypozyczone
{
    public List<Samochody> Samochody { get; } = new();
    public List<Uzytkownicy> Uzytkownicy { get; } = new();
    public DateTime? DataOdbioru { get; set; }
    public DateTime? DataZwrotu { get; set; }
}
