using AeroSimFT.EFModels;
using AeroSimFT.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AeroSimFT.Data;

public partial class FlightSimContext : DbContext
{
    public FlightSimContext()
    {
    }

    public FlightSimContext(DbContextOptions<FlightSimContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcCategory> AcCategories { get; set; }

    public virtual DbSet<AcManufacturer> AcManufacturers { get; set; }

    public virtual DbSet<AircraftEngine> AircraftEngines { get; set; }

    public virtual DbSet<AircraftManufacturer> AircraftManufacturers { get; set; }

    public virtual DbSet<AircraftModel> AircraftModels { get; set; }

    public virtual DbSet<AircraftProperty> AircraftProperties { get; set; }

    public virtual DbSet<AircraftType> AircraftTypes { get; set; }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<AirportFrequency> AirportFrequencies { get; set; }

    public virtual DbSet<AirportType> AirportTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Navaid> Navaids { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Runway> Runways { get; set; }

    public virtual DbSet<XpAircraft> XpAircrafts { get; set; }

    public virtual DbSet<XpFlightPlan> XpFlightPlans { get; set; }

    public virtual DbSet<Flights> Flights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;user id=flightsimuser;password=YourPassword;port=3306;database=flight_sim");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcCategory>(entity =>
        {
            entity.HasKey(e => e.AcCatId).HasName("PRIMARY");

            entity.ToTable("ac_categories");

            entity.Property(e => e.AcCatId)
                .HasColumnType("int(11)")
                .HasColumnName("acCatId");
            entity.Property(e => e.AcCatName)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("acCatName");
            entity.Property(e => e.AcPcatId)
                .HasColumnType("int(11)")
                .HasColumnName("acPCatId");
        });

        modelBuilder.Entity<AcManufacturer>(entity =>
        {
            entity.HasKey(e => e.AcManId).HasName("PRIMARY");

            entity.ToTable("ac_manufacturers");

            entity.Property(e => e.AcManId)
                .HasColumnType("int(11)")
                .HasColumnName("acManId");
            entity.Property(e => e.AcManCountryId)
                .HasDefaultValueSql("'302613'")
                .HasColumnType("int(11)")
                .HasColumnName("acManCountryId");
            entity.Property(e => e.AcManPid)
                .HasColumnType("int(11)")
                .HasColumnName("acManPId");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<AircraftEngine>(entity =>
        {
            entity.HasKey(e => e.EngineId).HasName("PRIMARY");

            entity.ToTable("aircraft_engines");

            entity.HasIndex(e => e.ManufacturerId, "index2");

            entity.Property(e => e.EngineId)
                .HasColumnType("int(11)")
                .HasColumnName("engineId");
            entity.Property(e => e.EngineFamily)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("engineFamily");
            entity.Property(e => e.EngineName)
                .HasMaxLength(65)
                .HasColumnName("engineName");
            entity.Property(e => e.Guid)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("guid");
            entity.Property(e => e.ManufacturerId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("manufacturerId");
        });

        modelBuilder.Entity<AircraftManufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerGuid).HasName("PRIMARY");

            entity.ToTable("aircraft_manufacturers");

            entity.HasIndex(e => e.ManufacturerGuid, "index2");

            entity.Property(e => e.ManufacturerGuid).HasColumnName("manufacturerGuid");
            entity.Property(e => e.ManufacturerCountry)
                .HasMaxLength(4)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("manufacturerCountry");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(65)
                .HasColumnName("manufacturerName");
        });

        modelBuilder.Entity<AircraftModel>(entity =>
        {
            entity.HasKey(e => e.AircraftModelId).HasName("PRIMARY");

            entity.ToTable("aircraft_models");

            entity.HasIndex(e => e.AircraftType, "index2");

            entity.HasIndex(e => e.Manufacturer, "index3");

            entity.Property(e => e.AircraftModelId).HasColumnName("aircraftModelId");
            entity.Property(e => e.AircraftFamily)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("aircraftFamily");
            entity.Property(e => e.AircraftName)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("aircraftName");
            entity.Property(e => e.AircraftType)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("aircraftType");
            entity.Property(e => e.EngineCount)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("engineCount");
            entity.Property(e => e.EngineFamily)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("engineFamily");
            entity.Property(e => e.EngineModels)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("engineModels");
            entity.Property(e => e.Manufacturer)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("manufacturer");
            entity.Property(e => e.NativeName)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nativeName");
            entity.Property(e => e.PropertyValues)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("propertyValues");
            entity.Property(e => e.Tags)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("tags");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("url");

            entity.HasOne(d => d.AircraftTypeNavigation).WithMany(p => p.AircraftModels)
                .HasForeignKey(d => d.AircraftType)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_aircraft_type");

            entity.HasOne(d => d.ManufacturerNavigation).WithMany(p => p.AircraftModels)
                .HasForeignKey(d => d.Manufacturer)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_manufacturer_guid");
        });

        modelBuilder.Entity<AircraftProperty>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PRIMARY");

            entity.ToTable("aircraft_properties");

            entity.Property(e => e.PropertyId).HasColumnName("propertyId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("description");
            entity.Property(e => e.PropertyName)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("propertyName");
            entity.Property(e => e.PropertyType)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("propertyType");
            entity.Property(e => e.Unit)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("unit");
        });

        modelBuilder.Entity<AircraftType>(entity =>
        {
            entity.HasKey(e => e.AircraftTypeId).HasName("PRIMARY");

            entity.ToTable("aircraft_types");

            entity.HasIndex(e => e.Manufacturer, "index2");

            entity.HasIndex(e => e.AircraftFamily, "index3");

            entity.HasIndex(e => e.IcaoCode, "index4");

            entity.Property(e => e.AircraftTypeId).HasColumnName("aircraftTypeId");
            entity.Property(e => e.AircraftFamily)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("aircraftFamily");
            entity.Property(e => e.AircratfTypeName)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("aircratfTypeName");
            entity.Property(e => e.EngineCount)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("engineCount");
            entity.Property(e => e.EngineFamily)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("engineFamily");
            entity.Property(e => e.EngineModels)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("engineModels");
            entity.Property(e => e.IataCode)
                .HasMaxLength(6)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("iataCode");
            entity.Property(e => e.IcaoCode)
                .HasMaxLength(6)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("icaoCode");
            entity.Property(e => e.Manufacturer)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("manufacturer");
            entity.Property(e => e.NativeName)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("nativeName");
            entity.Property(e => e.PropertyValues)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("propertyValues");
            entity.Property(e => e.Tags)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("tags");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("url");

            entity.HasOne(d => d.ManufacturerNavigation).WithMany(p => p.AircraftTypes)
                .HasForeignKey(d => d.Manufacturer)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_manu_Id");
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.AirportId).HasName("PRIMARY");

            entity.ToTable("airports");

            entity.HasIndex(e => e.CountryId, "FK_country_id_idx");

            entity.HasIndex(e => e.RegionId, "FK_region_idc");

            entity.HasIndex(e => e.TypeId, "FQ_type_id_idx");

            entity.HasIndex(e => e.Ident, "index2");

            entity.Property(e => e.AirportId)
                .HasColumnType("int(11)")
                .HasColumnName("airportId");
            entity.Property(e => e.AirportName)
                .HasMaxLength(150)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("airportName");
            entity.Property(e => e.Continent)
                .HasMaxLength(2)
                .HasDefaultValueSql("'NULL'")
                .IsFixedLength()
                .HasColumnName("continent");
            entity.Property(e => e.CountryId)
                .HasColumnType("int(11)")
                .HasColumnName("countryId");
            entity.Property(e => e.ElevationFt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("elevation_ft");
            entity.Property(e => e.GpsCode)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("gps_code");
            entity.Property(e => e.HomeLink)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("home_link");
            entity.Property(e => e.IataCode)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("iata_code");
            entity.Property(e => e.Ident)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("ident");
            entity.Property(e => e.Keywords)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("keywords");
            entity.Property(e => e.LatitudeDeg)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("latitude_deg");
            entity.Property(e => e.LocalCode)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("local_code");
            entity.Property(e => e.LongitudeDeg)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("longitude_deg");
            entity.Property(e => e.Municipality)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("municipality");
            entity.Property(e => e.RegionId)
                .HasColumnType("int(11)")
                .HasColumnName("regionId");
            entity.Property(e => e.ScheduledService)
                .HasMaxLength(25)
                .HasDefaultValueSql("'''no'''")
                .HasColumnName("scheduled_service");
            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("typeId");
            entity.Property(e => e.WikipediaLink)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("wikipedia_link");

            entity.HasOne(d => d.Country).WithMany(p => p.Airports)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_country_idc");

            entity.HasOne(d => d.Region).WithMany(p => p.Airports)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_region_idc");

            entity.HasOne(d => d.Type).WithMany(p => p.Airports)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_type_idc");
        });

        modelBuilder.Entity<AirportFrequency>(entity =>
        {
            entity.HasKey(e => e.FreqId).HasName("PRIMARY");

            entity.ToTable("airport_frequencies");

            entity.HasIndex(e => e.AirportId, "FK_airport_idf");

            entity.Property(e => e.FreqId)
                .HasColumnType("int(11)")
                .HasColumnName("freqId");
            entity.Property(e => e.AirportId)
                .HasColumnType("int(11)")
                .HasColumnName("airportId");
            entity.Property(e => e.AirportIdent)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("airport_ident");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FrequencyMhz)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("frequency_mhz");
            entity.Property(e => e.Type)
                .HasMaxLength(150)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("type");

            entity.HasOne(d => d.Airport).WithMany(p => p.AirportFrequencies)
                .HasForeignKey(d => d.AirportId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_airport_idf");
        });

        modelBuilder.Entity<AirportType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("airport_types");

            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("typeId");
            entity.Property(e => e.AirportTypeTitle)
                .HasMaxLength(25)
                .HasColumnName("airportTypeTitle");
            entity.Property(e => e.OrigTypeName)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("origTypeName");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("countries");

            entity.HasIndex(e => e.Code, "index2");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(8)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("code");
            entity.Property(e => e.Continent)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("continent");
            entity.Property(e => e.Keywords)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("keywords");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("name");
            entity.Property(e => e.WikipediaLink)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("wikipedia_link");
        });

        modelBuilder.Entity<Navaid>(entity =>
        {
            entity.HasKey(e => e.NavaidId).HasName("PRIMARY");

            entity.ToTable("navaids");

            entity.Property(e => e.NavaidId)
                .HasColumnType("int(11)")
                .HasColumnName("navaidId");
            entity.Property(e => e.AssociatedAirport)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("associated_airport");
            entity.Property(e => e.DmeChannel)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("dme_channel");
            entity.Property(e => e.DmeElevationFt)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("dme_elevation_ft");
            entity.Property(e => e.DmeFrequencyKhz)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("dme_frequency_khz");
            entity.Property(e => e.DmeLatitudeDeg)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("dme_latitude_deg");
            entity.Property(e => e.DmeLongitudeDeg)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("dme_longitude_deg");
            entity.Property(e => e.ElevationFt)
                .HasMaxLength(150)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("elevation_ft");
            entity.Property(e => e.Filename)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("filename");
            entity.Property(e => e.FrequencyKhz)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("frequency_khz");
            entity.Property(e => e.Ident)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("ident");
            entity.Property(e => e.IsoCountry)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("iso_country");
            entity.Property(e => e.LatitudeDeg)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("latitude_deg");
            entity.Property(e => e.LongitudeDeg)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("longitude_deg");
            entity.Property(e => e.MagneticVariationDeg)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("magnetic_variation_deg");
            entity.Property(e => e.NavaidName)
                .HasMaxLength(150)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("navaidName");
            entity.Property(e => e.NavaidType)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("navaidType");
            entity.Property(e => e.Power)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("power");
            entity.Property(e => e.SlavedVariationDeg)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("slaved_variation_deg");
            entity.Property(e => e.UsageType)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("usageType");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PRIMARY");

            entity.ToTable("regions");

            entity.HasIndex(e => e.RegionCode, "index2");

            entity.HasIndex(e => e.IsoCountry, "index3");

            entity.Property(e => e.RegionId)
                .HasColumnType("int(11)")
                .HasColumnName("regionId");
            entity.Property(e => e.Continent)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("continent");
            entity.Property(e => e.IsoCountry)
                .HasMaxLength(2)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("iso_country");
            entity.Property(e => e.Keywords)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("keywords");
            entity.Property(e => e.LocalCode)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("local_code");
            entity.Property(e => e.RegionCode)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("regionCode");
            entity.Property(e => e.RegionName)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("regionName");
            entity.Property(e => e.WikipediaLink)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("wikipedia_link");
        });

        modelBuilder.Entity<Runway>(entity =>
        {
            entity.HasKey(e => e.RunwayId).HasName("PRIMARY");

            entity.ToTable("runways");

            entity.HasIndex(e => e.AirportId, "FK_airport_idr_idx");

            entity.Property(e => e.RunwayId)
                .HasColumnType("int(11)")
                .HasColumnName("runwayId");
            entity.Property(e => e.AirportId)
                .HasColumnType("int(11)")
                .HasColumnName("airportId");
            entity.Property(e => e.Closed)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("closed");
            entity.Property(e => e.HeDisplacedThresholdFt)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("he_displaced_threshold_ft");
            entity.Property(e => e.HeElevationFt)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("he_elevation_ft");
            entity.Property(e => e.HeHeadingDegT)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("he_heading_degT");
            entity.Property(e => e.HeIdent)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("he_ident");
            entity.Property(e => e.HeLatitudeDeg)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("he_latitude_deg");
            entity.Property(e => e.HeLongitudeDeg)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("he_longitude_deg");
            entity.Property(e => e.LeDisplacedThresholdFt)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("le_displaced_threshold_ft");
            entity.Property(e => e.LeElevationFt)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("le_elevation_ft");
            entity.Property(e => e.LeHeadingDegT)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("le_heading_degT");
            entity.Property(e => e.LeIdent)
                .HasMaxLength(150)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("le_ident");
            entity.Property(e => e.LeLatitudeDeg)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("le_latitude_deg");
            entity.Property(e => e.LeLongitudeDeg)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("le_longitude_deg");
            entity.Property(e => e.LengthFt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("length_ft");
            entity.Property(e => e.Lighted)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("lighted");
            entity.Property(e => e.Surface)
                .HasMaxLength(150)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("surface");
            entity.Property(e => e.WidthFt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("width_ft");

            entity.HasOne(d => d.Airport).WithMany(p => p.Runways)
                .HasForeignKey(d => d.AirportId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_airport_idr1");
        });

        modelBuilder.Entity<XpAircraft>(entity =>
        {
            entity.HasKey(e => e.AcId).HasName("PRIMARY");

            entity.ToTable("xp_aircraft");

            entity.HasIndex(e => e.AcGuid, "index2");

            entity.Property(e => e.AcId)
                .HasColumnType("int(11)")
                .HasColumnName("acId");
            entity.Property(e => e.AcGuid).HasColumnName("acGuid");
            entity.Property(e => e.AcName)
                .HasMaxLength(45)
                .HasColumnName("acName");
            entity.Property(e => e.AcType)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("acType");
            entity.Property(e => e.EmptyOpWeight)
                .HasColumnType("int(11)")
                .HasColumnName("emptyOpWeight");
            entity.Property(e => e.FinalApproachSpeed)
                .HasColumnType("int(11)")
                .HasColumnName("finalApproachSpeed");
            entity.Property(e => e.FuelType)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("fuelType");
            entity.Property(e => e.LandingSpeed)
                .HasColumnType("int(11)")
                .HasColumnName("landingSpeed");
            entity.Property(e => e.LongRangeCruise)
                .HasColumnType("int(11)")
                .HasColumnName("longRangeCruise");
            entity.Property(e => e.MaxCruise)
                .HasColumnType("int(11)")
                .HasColumnName("maxCruise");
            entity.Property(e => e.MaxLandingWeight)
                .HasColumnType("int(11)")
                .HasColumnName("maxLandingWeight");
            entity.Property(e => e.MaxPass)
                .HasColumnType("int(11)")
                .HasColumnName("maxPass");
            entity.Property(e => e.MaxTakeoffWeight)
                .HasColumnType("int(11)")
                .HasColumnName("maxTakeoffWeight");
            entity.Property(e => e.MinLandingDist)
                .HasColumnType("int(11)")
                .HasColumnName("minLandingDist");
            entity.Property(e => e.MinTakeoffDist)
                .HasColumnType("int(11)")
                .HasColumnName("minTakeoffDist");
            entity.Property(e => e.RotateSpeed)
                .HasColumnType("int(11)")
                .HasColumnName("rotateSpeed");
            entity.Property(e => e.ServiceCeiling)
                .HasColumnType("int(11)")
                .HasColumnName("serviceCeiling");
            entity.Property(e => e.ServiceRange)
                .HasColumnType("int(11)")
                .HasColumnName("serviceRange");
            entity.Property(e => e.StallSpeed)
                .HasColumnType("int(11)")
                .HasColumnName("stallSpeed");
        });

        modelBuilder.Entity<XpFlightPlan>(entity =>
        {
            entity.HasKey(e => e.FpId).HasName("PRIMARY");

            entity.ToTable("xp_flight_plans");

            entity.Property(e => e.FpId)
                .HasColumnType("int(11)")
                .HasColumnName("fpId");
            entity.Property(e => e.AircraftId)
                .HasColumnType("int(11)")
                .HasColumnName("aircraftId");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("dateCreated");
            entity.Property(e => e.DateFlown)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("dateFlown");
            entity.Property(e => e.DepartAirport)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("departAirport");
            entity.Property(e => e.DepartCity)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("departCity");
            entity.Property(e => e.DepartCountry)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("departCountry");
            entity.Property(e => e.DepartIdent)
                .HasMaxLength(8)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("departIdent");
            entity.Property(e => e.DepartRegion)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("departRegion");
            entity.Property(e => e.DestAirport)
                .HasMaxLength(65)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("destAirport");
            entity.Property(e => e.DestCity)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("destCity");
            entity.Property(e => e.DestCountry)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("destCountry");
            entity.Property(e => e.DestIdent)
                .HasMaxLength(8)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("destIdent");
            entity.Property(e => e.DestRegion)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("destRegion");
            entity.Property(e => e.DistanceNm)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(6)")
                .HasColumnName("distanceNM");
            entity.Property(e => e.EstFlightTime)
                .HasMaxLength(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("estFlightTime");
            entity.Property(e => e.PlaneCrash).HasColumnName("planeCrash");
        });

        modelBuilder.Entity<Flights>().HasNoKey();
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
