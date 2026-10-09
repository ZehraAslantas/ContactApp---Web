using ContactApp.Models;

namespace ContactApp.Repositories
{
    public static class DbSeeder
    {
        public static void Seed(ContactDbContext db)
        {
            if (db.Contacts.Any()) 
            {
                return;
            }
            var seed = new List<Contact>() //çekirdek veri listesi ekliyoruz.
            {
            new Contact(){FirstName="Ahmet",LastName="Yılmaz",Email="ahmet.yilmaz@example.com",Phone="+905551112233",Company="BTK Akademi",Title="Yazılım Geliştirme Uzmanı",Notes=".NET"},
            new Contact(){FirstName="Ayşe",LastName="Demir",Email="ayse.yilmaz@example.com",Phone="+905551122233",Company="BTK Akademi",Title="Yazılım Geliştirme Uzmanı",Notes=".NET"},
            new Contact(){FirstName="Mehmet",LastName="Kaya",Email="mehmet.yilmaz@example.com",Phone="+905551222233",Company="BTK Akademi",Title="Yazılım Geliştirme Uzmanı",Notes=".NET"},
            new Contact(){FirstName="Elif",LastName="Çetin",Email="elif.yilmaz@example.com",Phone="+905552222233",Company="BTK Akademi",Title="Yazılım Geliştirme Uzmanı",Notes=".NET"},
            new Contact(){FirstName="Can",LastName="Aydın",Email="can.yilmaz@example.com",Phone="+905551112133",Company="BTK Akademi",Title="Yazılım Geliştirme Uzmanı",Notes=".NET"},
            new Contact(){FirstName="Zeynep",LastName="Bulut",Email="zeynep.yilmaz@example.com",Phone="+905551112113",Company="BTK Akademi",Title="Yazılım Geliştirme Uzmanı",Notes=".NET"},
            new Contact(){FirstName="Emre",LastName="Arslan",Email="emre.yilmaz@example.com",Phone="+905551112123",Company="BTK Akademi",Title="Yazılım Geliştirme Uzmanı",Notes=".NET"},
            new Contact(){FirstName="Selin",LastName="Koç",Email="selin.yilmaz@example.com",Phone="+905551122133",Company="BTK Akademi",Title="Yazılım Geliştirme Uzmanı",Notes=".NET"}
            };
            db.Contacts.AddRange(seed); 
            db.SaveChanges();
        }
    }
}
