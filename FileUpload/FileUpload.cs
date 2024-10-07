// Models/ApplicationUser.cs
using Microsoft.AspNet.Identity.EntityFramework;

public class ApplicationUser : IdentityUser
{
    // Additional profile data can be added here
}

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Remember Me")]
    public bool RememberMe { get; set; }
}

public class FileUpload
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public byte[] FileData { get; set; }
    public string UserName { get; set; }
    public DateTime UploadDate { get; set; }
    public DateTime ExpiryDate { get; set; }
}