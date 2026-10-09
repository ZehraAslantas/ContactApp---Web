using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models;

public class Contact
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Ad zorunludur.")] 
    [StringLength(50,ErrorMessage ="Ad en fazla 50 karakter olabilir")]
    [Display(Name ="Ad")]
    public String FirstName { get; set; }=String.Empty; 

    [Required(ErrorMessage = "Soyad zorunludur.")]
    [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir")]
    [Display(Name = "Soyad")]
    public String LastName { get; set; }= string.Empty;

    [EmailAddress(ErrorMessage ="Geçerli bir e-posta giriniz")]
    [StringLength(100, ErrorMessage ="E-posta en fazla 100 karakter uzunluğunda olabilir.")]
    public string? Email { get; set; }

    [Phone(ErrorMessage ="Geçerli bir telefon giriniz.")]
    [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir.")]
    public string? Phone { get; set; }

    [StringLength(100, ErrorMessage = "Şirket adı en fazla 100 karakter olabilir.")]
    [Display(Name ="Şirket")]
    public string? Company { get; set; }

    [StringLength(50, ErrorMessage = "Ünvan en fazla 50 karakter olabilir.")]
    [Display(Name = "Ünvan")]
    public string? Title { get; set; }


    [StringLength(500, ErrorMessage = "Notlar en fazla 500 karakter içerebilir.")]
    [Display(Name = "Notlar")]
    public string? Notes { get; set; }
}
