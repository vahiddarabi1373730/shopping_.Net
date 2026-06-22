using Microsoft.EntityFrameworkCore;
using Shopping_Data_Layer.Context;
using Shopping_Data_Layer.Entities.Product;

namespace Shopping_Data_Layer.Data;

public static class Seeder
{
    private static  readonly DateTime Now = DateTime.Now;

    public static async Task AddProductSeedData(ShoppingContext context)
    {
        await context.Database.MigrateAsync();
        if (await context.Products.AnyAsync()) return;

        await context.Products.AddRangeAsync(Products);
        await context.SaveChangesAsync();
    }

    public static List<Product> Products = new List<Product>
    {
        new Product
        {
            ProductName = "گوشی A1",
            ShortDescription = "گوشی اقتصادی با باتری قوی",
            Description = "گوشی A1 مناسب استفاده روزمره با باتری 5000mAh و نمایشگر 6.5 اینچ.",
            ImageName = "/Images/1.jpg",
            Price = 6500000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-40),
            LastUpdateDate = Now.AddDays(-2)
        },
        new Product
        {
            ProductName = "گوشی A1 Pro",
            ShortDescription = "دوربین بهتر و حافظه بیشتر",
            Description = "نسخه Pro با دوربین ارتقا یافته و حافظه داخلی بالاتر برای کاربران پرمصرف.",
            ImageName = "/Images/1.jpg", 
            Price = 8900000,
            IsExists = true,
            IsSpecial = true,
            IsDelete = false,
            CreateDate = Now.AddDays(-38),
            LastUpdateDate = Now.AddDays(-1)
        },
        new Product
        {
            ProductName = "هدفون بی‌سیم B200",
            ShortDescription = "صدای شفاف و بیس مناسب",
            Description = "هدفون بی‌سیم با اتصال پایدار، مناسب ورزش و مکالمه روزانه.",
            ImageName = "/Images/1.jpg", 
            Price = 1250000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-35),
            LastUpdateDate = Now.AddDays(-3)
        },
        new Product
        {
            ProductName = "هدفون گردنی N10",
            ShortDescription = "سبک و راحت برای استفاده طولانی",
            Description = "هدفون گردنی با باتری مناسب و کنترل موسیقی روی بدنه.",
            ImageName = "/Images/1.jpg", 
            Price = 980000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-34),
            LastUpdateDate = Now.AddDays(-5)
        },
        new Product
        {
            ProductName = "لپ‌تاپ L14",
            ShortDescription = "مناسب برنامه‌نویسی و کار اداری",
            Description = "لپ‌تاپ 14 اینچ با SSD سریع و رم مناسب برای چندوظیفگی.",
            ImageName = "/Images/1.jpg", 
            Price = 28500000,
            IsExists = true,
            IsSpecial = true,
            IsDelete = false,
            CreateDate = Now.AddDays(-33),
            LastUpdateDate = Now.AddDays(-7)
        },
        new Product
        {
            ProductName = "لپ‌تاپ L15 Gaming",
            ShortDescription = "قدرت بالا برای بازی",
            Description = "مدل گیمینگ با کارت گرافیک مجزا و نمایشگر 144Hz.",
            ImageName = "/Images/1.jpg", 
            Price = 48900000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-31),
            LastUpdateDate = Now.AddDays(-6)
        },
        new Product
        {
            ProductName = "کیبورد مکانیکی K7",
            ShortDescription = "سوییچ نرم و بدنه مقاوم",
            Description = "کیبورد مکانیکی با نور پس‌زمینه، مناسب تایپ و بازی.",
            ImageName = "/Images/1.jpg", 
            Price = 1950000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-30),
            LastUpdateDate = Now.AddDays(-4)
        },
        new Product
        {
            ProductName = "ماوس بی‌سیم M3",
            ShortDescription = "ارگونومیک و دقیق",
            Description = "ماوس بی‌سیم با سنسور دقیق و مصرف کم باتری.",
            ImageName = "/Images/1.jpg", 
            Price = 620000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-29),
            LastUpdateDate = Now.AddDays(-8)
        },
        new Product
        {
            ProductName = "مانیتور 24 اینچ V24",
            ShortDescription = "Full HD با حاشیه کم",
            Description = "مانیتور 24 اینچ Full HD مناسب کار روزمره و تماشای فیلم.",
            ImageName = "/Images/1.jpg", 
            Price = 7600000,
            IsExists = true,
            IsSpecial = true,
            IsDelete = false,
            CreateDate = Now.AddDays(-28),
            LastUpdateDate = Now.AddDays(-9)
        },
        new Product
        {
            ProductName = "مانیتور 27 اینچ V27",
            ShortDescription = "اندازه بزرگ‌تر برای بهره‌وری",
            Description = "مانیتور 27 اینچ با کیفیت تصویر بهتر و زاویه دید مناسب.",
            ImageName = "/Images/1.jpg", 
            Price = 11200000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-27),
            LastUpdateDate = Now.AddDays(-10)
        },
        new Product
        {
            ProductName = "پاوربانک P10",
            ShortDescription = "10000mAh جمع‌وجور",
            Description = "پاوربانک 10000 میلی‌آمپر با شارژ سریع و دو خروجی USB.",
            ImageName = "/Images/1.jpg", 
            Price = 890000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-25),
            LastUpdateDate = Now.AddDays(-11)
        },
        new Product
        {
            ProductName = "پاوربانک P20 Fast",
            ShortDescription = "20000mAh با شارژ سریع",
            Description = "پاوربانک 20000mAh با PD و QC مناسب گوشی و تبلت.",
            ImageName = "/Images/1.jpg", 
            Price = 1650000,
            IsExists = true,
            IsSpecial = true,
            IsDelete = false,
            CreateDate = Now.AddDays(-24),
            LastUpdateDate = Now.AddDays(-12)
        },
        new Product
        {
            ProductName = "اسپیکر S1 Mini",
            ShortDescription = "کوچک اما پرقدرت",
            Description = "اسپیکر قابل حمل با صدای بلند و باتری مناسب.",
            ImageName = "/Images/1.jpg", 
            Price = 1100000,
            IsExists = false,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-23),
            LastUpdateDate = Now.AddDays(-13)
        },
        new Product
        {
            ProductName = "اسپیکر S5 Party",
            ShortDescription = "مناسب مهمانی",
            Description = "اسپیکر پرقدرت با نورپردازی و بیس قوی، مناسب فضای باز.",
            ImageName = "/Images/1.jpg", 
            Price = 5200000,
            IsExists = true,
            IsSpecial = true,
            IsDelete = false,
            CreateDate = Now.AddDays(-22),
            LastUpdateDate = Now.AddDays(-14)
        },
        new Product
        {
            ProductName = "هارد اکسترنال E1",
            ShortDescription = "پشتیبان‌گیری مطمئن",
            Description = "هارد اکسترنال با بدنه مقاوم و سرعت انتقال مناسب.",
            ImageName = "/Images/1.jpg", 
            Price = 3450000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-21),
            LastUpdateDate = Now.AddDays(-15)
        },
        new Product
        {
            ProductName = "SSD اکسترنال X500",
            ShortDescription = "سرعت بالا برای کار حرفه‌ای",
            Description = "SSD اکسترنال پرسرعت برای تدوین و انتقال فایل‌های حجیم.",
            ImageName = "/Images/1.jpg", 
            Price = 6900000,
            IsExists = true,
            IsSpecial = true,
            IsDelete = false,
            CreateDate = Now.AddDays(-20),
            LastUpdateDate = Now.AddDays(-16)
        },
        new Product
        {
            ProductName = "فلش 64GB U64",
            ShortDescription = "USB 3.0 با بدنه فلزی",
            Description = "فلش 64 گیگ با سرعت خوب برای استفاده روزمره.",
            ImageName = "/Images/1.jpg", 
            Price = 420000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-18),
            LastUpdateDate = Now.AddDays(-17)
        },
        new Product
        {
            ProductName = "مودم 4G R1",
            ShortDescription = "اتصال پایدار اینترنت",
            Description = "مودم 4G با پوشش وای‌فای مناسب خانه و محل کار.",
            ImageName = "/Images/1.jpg", 
            Price = 2100000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-16),
            LastUpdateDate = Now.AddDays(-7)
        },
        new Product
        {
            ProductName = "روتر WiFi 6 W6",
            ShortDescription = "سرعت و پوشش بهتر",
            Description = "روتر WiFi 6 مناسب تعداد دستگاه زیاد و خانه‌های بزرگ.",
            ImageName = "/Images/1.jpg", 
            Price = 3950000,
            IsExists = true,
            IsSpecial = true,
            IsDelete = false,
            CreateDate = Now.AddDays(-14),
            LastUpdateDate = Now.AddDays(-6)
        },
        new Product
        {
            ProductName = "دوربین تحت شبکه C2",
            ShortDescription = "امنیت خانه با دید در شب",
            Description = "دوربین تحت شبکه با دید در شب و اپ موبایل برای کنترل از راه دور.",
            ImageName = "/Images/1.jpg", 
            Price = 1750000,
            IsExists = true,
            IsSpecial = false,
            IsDelete = false,
            CreateDate = Now.AddDays(-12),
            LastUpdateDate = Now.AddDays(-5)
        }
    };
}