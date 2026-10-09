using ContactApp.Models;


namespace ContactApp.Services;

public class InMemoryContactRepository : IContactRepository
{
    private readonly List<Contact> _contacts;
    private int _nextId=1;
    public InMemoryContactRepository()
    {
        _contacts =new List<Contact>(); 
        var seed = new List<Contact>()
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
        foreach(var c in seed)
        {
            c.Id = _nextId++;
            
            _contacts.Add(c);
        }
    }
   
    public Contact Add(Contact contact)
    {
        contact.Id = _nextId++;
        _contacts.Add(contact);
        return contact;
    }

    public bool Delete(int id)
    {
        var existing = GetById(id);
        if (existing is null)
            return false;
        _contacts.Remove(existing);
        return true;
    }

    public IEnumerable<Contact> GetAll() =>
        _contacts
        .OrderBy(c => c.LastName)
        .ThenBy(c => c.FirstName);

    public Contact? GetById(int id) =>
        _contacts.FirstOrDefault(c  => c.Id.Equals(id));
    public bool Update(Contact contact)
    {
        var existing = GetById(contact.Id);
        if(existing is null)
            return false;
        existing.FirstName = contact.FirstName;
        existing.LastName = contact.LastName;
        existing.Email = contact.Email;
        existing.Phone = contact.Phone;
        existing.Company = contact.Company;
        existing.Title = contact.Title;
        existing.Notes = contact.Notes;
        return true;


    }
}
