using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using robotistan.Domain.Models;

namespace robotistan.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<User> User { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            builder.Entity<Category>().Property(p => p.UstKategoriId).IsRequired();

            builder.Entity<Category>().HasData
            (
               // new Category { UstKategoriId=1, Id = 0, Name ="Arduino"},
                new Category { UstKategoriId = 1, Id = 1, Name = "Arduino Modelleri" }, 
                new Category { UstKategoriId = 1, Id = 2, Name = "Arduino Shield" },
                new Category { UstKategoriId = 1, Id =3, Name="Arduino Setleri"}
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p=> p.Fiyat).IsRequired();
            builder.Entity<Product>().Property(p => p.Marka).IsRequired();
            builder.Entity<Product>().Property(p => p.Aciklama).HasMaxLength(350);
            builder.Entity<Product>().Property(p => p.UrunResmi).IsRequired();




            _ = builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 1,
                    Name = "Arduino R3 Uno Klon",
                    QuantityInPackage = 1,
                    CategoryId = 1,
                    Fiyat = 25.02,
                    Marka = "China",
                    Aciklama = "USB Kablo Hediyeli - (USB Chip CH340)",
                    UrunResmi = ""
                },
                new Product
                {
                    Id = 2,
                    Name = "Arduino Nano Klon",
                    QuantityInPackage = 2,
                    CategoryId = 1,
                    Fiyat = 23.18,
                    Marka = "China",
                    Aciklama = "USB Kablo Hediyeli - (USB Chip CH340)",
                    UrunResmi = ""
                },
                new Product
                {
                    Id = 3,
                    Name = "Arduino MEGA 2560 R3 Klon",
                    QuantityInPackage = 1,
                    Fiyat = 65.59,
                    Marka = "China",
                    Aciklama = "USB Kablo Hediyeli - (USB Chip CH340)",
                    CategoryId = 1,
                    UrunResmi = ""
                },
                new Product
                {
                    Id = 4,
                    Name = "Arduino Motor Sürücü Shield",
                    QuantityInPackage = 1,
                    CategoryId = 2,
                    Fiyat = 19.47,
                    Marka = "China",
                    Aciklama = "4 DC motoru veya 2 step motoru (unipolar veya bipolar) bunlara ek olarakda 2 servo motoru kontrol etmenize imkan saðlar.",
                    UrunResmi = ""
                },
                new Product
                {
                    Id = 5,
                    Name = "Mini Breadboardlu Arduino UNO R3 Proto Shield Kiti",
                    QuantityInPackage = 2,
                    CategoryId = 2,
                    Fiyat = 15.66,
                    Marka = "China",
                    Aciklama = "Devrelerin Arduino ile beraber kullanýlmasýna imkan saðlar. ",
                    UrunResmi = ""
                },
                new Product
                {
                    Id = 6,
                    Name = "Arduino Uno Sensör Shield",
                    QuantityInPackage = 1,
                    Fiyat = 15.82,
                    Marka = "China",
                    Aciklama = "Arduino UNO R3 modeli için tasarlanmýþtýr ",
                    CategoryId = 2,
                    UrunResmi = ""
                }
                );

            builder.Entity<Sepet>().ToTable("Sepet");
            builder.Entity<Sepet>().HasKey(p => p.Id);
            builder.Entity<Sepet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Sepet>().Property(p => p.SepetKullanici).IsRequired();
            builder.Entity<Sepet>().HasData
            (
                 new Sepet
                 {
                    Id = 1,
                    SepetKullanici = "Ali Ýhsan Varol",
                 
                 },
                 new Sepet
                 {
                      Id = 2,
                      SepetKullanici = "Veli Okumuþ",

                 }
            );



            builder.Entity<Siparis>().ToTable("Sepet");
            builder.Entity<Siparis>().HasKey(p => p.Id);
            builder.Entity<Siparis>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Siparis>().Property(p => p.UrunFiyati).IsRequired();
            builder.Entity<Siparis>().Property(p => p.SepetToplamTutar).IsRequired();
            builder.Entity<Siparis>().Property(p => p.SiparisNo).IsRequired();
            builder.Entity<Siparis>().Property(p => p.SepetUser).IsRequired();
            builder.Entity<Siparis>().HasData
            (
                 new Siparis
                 {
                     Id = 1,
                     UrunFiyati = 15.82,
                     SepetToplamTutar = 15.82,
                     SiparisNo = 1,
                     SepetUser ="veliiii",
                     
                 },
                new Siparis
                {
                    Id = 2,
                    UrunFiyati = 15.66,
                    SepetToplamTutar = 15.66,
                    SiparisNo = 2,
                    SepetUser= "A.Ý.Varol",
                }
             );
            builder.Entity<Slider>().ToTable("Slider");
            builder.Entity<Slider>().HasKey(p => p.Id);
            builder.Entity<Slider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Slider>().Property(p => p.SliderAciklama).IsRequired().HasMaxLength(30);
            builder.Entity<Slider>().Property(p => p.Resim).IsRequired();
            builder.Entity<Slider>().Property(p => p.SliderLink).IsRequired();

            builder.Entity<Slider>().HasData
            (
              
                new Slider { Id = 1, SliderAciklama = "Tüm Arduino Modelleri Burada" ,Resim="",SliderLink=""},
                new Slider { Id = 2, SliderAciklama = "Arduino Alan Herkese Arduino uyumlu Shield'ler %10 Ýndirimli! ", Resim = "", SliderLink =""}
            );
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Adi).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Soyadi).IsRequired();
            builder.Entity<User>().Property(p => p.KullaniciAdi).IsRequired();
            builder.Entity<User>().Property(p => p.Email).IsRequired();
            builder.Entity<User>().Property(p => p.Sifre).IsRequired();
            builder.Entity<User>().Property(p => p.Telefon).IsRequired();

            builder.Entity<User>().HasData
            (

                new User { Id = 1, Adi = "Ali Ýhsan", Soyadi = "Varol", KullaniciAdi = "A.Ý.Varol", Email="aliihsanvarol@gmail.com", Sifre=1234, Telefon=05345674333 },
                new User { Id = 2, Adi = "Veli", Soyadi = "Okumuþ", KullaniciAdi = "veliiiii", Email = "veliokumus77@gmail.com", Sifre = 4567, Telefon = 05425784124 }
            );








        }
    }
}