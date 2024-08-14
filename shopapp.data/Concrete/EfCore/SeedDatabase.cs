using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategories);
                }
            }
            context.SaveChanges();
        }

        private static Category[] Categories = {
            new Category(){Name="Phone",Url="phone"},
            new Category(){Name="Computer",Url="computer"},
            new Category(){Name="Tablet",Url="tablet"},
            new Category(){Name="Computer Parts",Url="computer-parts"},
            new Category(){Name="TV & Audio & Video",Url="tv-audio"},
            new Category(){Name="Home & Kitchen",Url="home-appliances"},
            new Category(){Name="Personal Care",Url="personal-care"},
            new Category(){Name="Photo & Camera",Url="photo-camera"},
            new Category(){Name="Office & Stationery",Url="office-stationery"},
            new Category(){Name="Game & Hobby",Url="game-hobby"},
            new Category(){Name="Cooling & Heating",Url="cooling-heating"},
            new Category(){Name="Accessories",Url="accessories"}

        };

        private static Product[] Products = {

            new Product(){
                Name="Lenovo LOQ 12.Nesil Core i5 12450H-RTX3050 6Gb-8Gb-512Gb Ssd-15.6-W11",
                Url="lenovo-loq",
                Price=29999,
                ImageUrl="pc.png",
                Description="İşlemci Markası:Intel\nİşlemci Nesli:12. Nesil\nİşlemci Teknolojisi:Core i5\nİşlemci Numarası:12450H\nİşlemci Hızı:Turbo Boost 4.4 GHz\nRam (Sistem Belleği):8 GB\nRam Tipi:DDR5\nRam Hafıza Bus Hızı:4800 MHz",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="Asus Rog Zephyrus M16 13.Nesil Core i9 13900H-RTX4090 16Gb-32Gb-2Tb-16inc-W11",
                Url="asusrog-m16",
                Price=169145,
                ImageUrl="pc1.png",
                Description="İşlemci Markası:Intelİşlemci Nesli:13. Nesilİşlemci Teknolojisi:Core i9İşlemci Numarası:13900Hİşlemci Hızı:Turbo Boost 5.4 GHzRam (Sistem Belleği):32 GB (2x16GB)Ram Tipi:DDR5Ram Hafıza Bus Hızı:4800 MHz",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="iPhone 13 128 Gb Akıllı Telefon Mavi",
                Url="iphone-13",
                Price=38799,
                ImageUrl="tlp.png",
                Description="İşletim Sistemi Türü:iOSPil Gücü:3227 mAhKamera Çözünürlük:12 MPİşlemci Hızı:PaylaşılmıyorSuya Dayanıklılık:VarEkran Boyu Aralığı:6.1 inch – 6.5 inchİşlemci Türü:Appleİşlemci Türü:A15 bionic",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="iPhone 15 Pro Max 1 Tb Akıllı Telefon Mavi Titanium",
                Url="iphone-15pro",
                Price=96999,
                ImageUrl="tlp1.png",
                Description="Dahili Hafıza:1TBEkran Boyutu:6,7Mobil Ram Boyutu (GB):8 GBEkran Boyutu Aralığı:6 inç ve Üzeriİşletim Sistemi Türü:iOSPil Gücü:4442 mAhYüz Tanıma:VarKamera Çözünürlük:48 mp +12 mp + 12",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="Samsung Galaxy Tab S9 Ultra 12Gb 512Gb 14.6''Android Tablet SM-X910NZEETUR",
                Url="samsung-tabs9",
                Price=28999,
                ImageUrl="tab.png",
                Description="Ekran Boyutu:14.6 inchDisk Kapasitesi:512 GBÇözünürlük (Piksel):2960 x 1848Ram (Sistem Belleği):12 GBEkran Özellikleri:Dynamic AMOLED 2XEkran Özellikleri:DokunmatikAğırlık:732 gr.Kamera Çözünürlük:13 MP",
                IsApproved=true,
                IsHome=true},
            
            new Product(){
                Name="iPad Pro 6.Nesil 1TB WIFI 12.9''Liquid Retina XDR Ekran iPadOS Tablet UzayGrisi",
                Url="ipad-pro6",
                Price=69799,
                ImageUrl="tab1.png",
                Description="Ekran Boyutu:12.9 inchDisk Kapasitesi:1 TBÇözünürlük (Piksel):2732 x 2048Ram (Sistem Belleği):16 GBEkran Özellikleri:Liquid Retina XDR EkranEkran Özellikleri:IPSAğırlık:682 grKamera Çözünürlük:12 MP",
                IsApproved=true,
                IsHome=true},
            
            new Product(){
                Name="COOLER MASTER HAF 700 EVO 3x120mm ARGB -2x200mm FANLI FULL TOWER SİYAH KASA",
                Url="cooler-haf700",
                Price=18845,
                ImageUrl="pcpa.png",
                Description="Menşei:ÇinGaranti:24Arka fanlar kurulmuş:2x 120 mmMaksimum PSU uzunluğu:20 cmHDD/SSD açılır kafes:VarAmbalaj genişliği:399 mmÖn fanlar kurulmuş:2x 200 mmAğırlık:24,3 kg",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="MSI MEG X670E GODLIKE AMD X670 Soket AM5 DDR5 6600MHz(OC) M.2 Anakart",
                Url="msi-megx670e",
                Price=60003,
                ImageUrl="pcpa1.png",
                Description="Anakart Markası:MSISoket Tipi:Soket AM5Anakart Chipseti:AMD® X670Anakart Yapı:ATXRam Tipi:DDR5Ram Tipi:DDR5Maks. Ram Desteği:128GBRam Slot Sayısı:4",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="LG OLED65CS3 65inc 164 cm 4K OLED evo Sihirli Kumanda Uyumlu webOS Smart TV,Uydu Alıcılı",
                Url="lg-oled65cs3",
                Price=73999,
                ImageUrl="tv.png",
                Description="Ekran Boyutu:65 inchÇözünürlük (Piksel):3840 x 2160Monitör Tipi:OLEDÇözünürlük:4K Ultra HDArayüz:WebOSTarama Hızı:120 HzHoparlör Gücü:40 WEkran Boyu (cm):165",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="SAMSUNG UE 75CU7100 75inc 189 cm 4K UHD Smart TV,Uydu Alıcılı",
                Url="samsung-ue75cu7100",
                Price=38319,
                ImageUrl="tv1.png",
                Description="Ekran Boyutu:75 inchÇözünürlük (Piksel):3840 x 2160Monitör Tipi:LEDÇözünürlük:4K Ultra HDArayüz:TizenTarama Hızı:50 HzHoparlör Gücü:20 WEkran Boyu (cm):189",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="PHILIPS EP5447/90 5400 SERİSİ TAM OTOMATİK ESPRESSO MAKİNESİ",
                Url="philips-ep5447",
                Price=23.999,
                ImageUrl="kitc.png",
                Description="Garanti:24Menşei:ÇinGenişlik:246 mmAC girdi frekansı:50 HzAyarlanabilir sıcaklık:VarÜrün tipi:Espresso makinesiPaket başına miktar:1 adetLatte macchiato yapımı:Var",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="BRAUN 9577 CC 9 PRO ISLAK VE KURU TIRAŞ MAKİNESİ, SMARTCARE MERKEZİ, POWERCASE",
                Url="braun-9577",
                Price=6000,
                ImageUrl="pers.png",
                Description="Başlık Sayısı:1Güç Kaynağı Tipi:ŞarjlıŞarj Süresi:60 dakikaŞarjlı K.Süresi(Yaklaşık):60 dakikaPil Tipi:Li-IonSakal ve Yüz Şekil.Aparat:YokVücut Tıraş Başlığı:YokSaç Kesme Başlığı:Yok",
                IsApproved=true,
                IsHome=true},
            
            new Product(){
                Name="Canon Eos R50 RF S 18-45 IS STM Vlogger Kit Vlog Fotoğraf Makinesi",
                Url="Canon-eos",
                Price=31449,
                ImageUrl="photo.png",
                Description="iyi telefon",
                IsApproved=true,
                IsHome=true},
            
            new Product(){
                Name="EPSON ECOTANK L14150 FOTOKOPİ,TARAYICI,A3 Wi-Fi MÜREKKEPTANKLI YAZICI",
                Url="epson-ecotank",
                Price=19999,
                ImageUrl="office.png",
                Description="Siyah Baskı Hızı:17 Sayfa/DakikaRenkli Baskı Hızı:9 sayfa/dakikaDubleks Baskı:OtomatikKartuş/Toner Kapasitesi:6.500 SAYFA SİYAH, 5.500 SAYFA RENKLİKağıt Türleri:A3+, A3, A4, A5, A6, B4, B5, B6, C4 (zarf), C6 (zarf), DL (zarf), No. 10 (zarf), Mektup, Legal, 10 x 15 cm, 13 x 18 cm, 20 x 25 cmFaks Özelliği:VarEthernet:Varİlk Baskı Süresi:5 sn",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="Sony Playstation 5 Slim Oyun Konsolu",
                Url="sony-ps3slim",
                Price=27999,
                ImageUrl="game.png",
                Description="Ağırlık:2.1KGAğırlık:4,2 kgAğırlık:4,5 kgDisk Kapasitesi:1 TB SSDİşlemci Markası:AMDİşlemci Markası:AMD®İşlemci Teknolojisi:x86-64 AMD “Jaguar”, 8 coreİşlemci Hızı:3.5 GHz",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="LG PC12SQ DUALCOOL+ Duvar Tipi Inverter 12.000 Btu A++ Klima",
                Url="lg-pc12sq",
                Price=23699,
                ImageUrl="cool.png",
                Description="Güç (Watt):1,080 WNem Alma Modu:VarIsı Kademesi:7Renk:BeyazIsıtma Kap.(Max-Btu/h):17.414Nemlendirme tipi:-Güvenlik:Aşırı Isınmaya Karşı Motor EmniyetiAğırlık:8,7 kg",
                IsApproved=true,
                IsHome=true},

            new Product(){
                Name="APPLE AIRPODS MAX - UZAY GRİSİ",
                Url="apple-airpodsmax",
                Price=24599,
                ImageUrl="acce.png",
                Description="Gürültü Engelleme:VarAğırlık:384,8 g3,5 mm konektörleri:YokMenşei:ÇinGaranti:24Ürün tipi:KulaklıkRenk adı:Space GreyGürültü azaltma türü:Aktif",
                IsApproved=true,
                IsHome=true},
                        };

        private static ProductCategory[] ProductCategories={
            new ProductCategory(){Product=Products[0],Category=Categories[1]},
            new ProductCategory(){Product=Products[1],Category=Categories[1]},
            new ProductCategory(){Product=Products[2],Category=Categories[0]},
            new ProductCategory(){Product=Products[3],Category=Categories[0]},
            new ProductCategory(){Product=Products[4],Category=Categories[2]},
            new ProductCategory(){Product=Products[5],Category=Categories[2]},
            new ProductCategory(){Product=Products[6],Category=Categories[3]},
            new ProductCategory(){Product=Products[7],Category=Categories[3]},
            new ProductCategory(){Product=Products[8],Category=Categories[4]},
            new ProductCategory(){Product=Products[9],Category=Categories[4]},
            new ProductCategory(){Product=Products[10],Category=Categories[5]},
            new ProductCategory(){Product=Products[11],Category=Categories[6]},
            new ProductCategory(){Product=Products[12],Category=Categories[7]},
            new ProductCategory(){Product=Products[13],Category=Categories[8]},
            new ProductCategory(){Product=Products[14],Category=Categories[9]},
            new ProductCategory(){Product=Products[15],Category=Categories[10]},
            new ProductCategory(){Product=Products[16],Category=Categories[11]},
        };
    }
}