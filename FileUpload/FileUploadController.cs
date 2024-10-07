using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;

public class FileUploadController : Controller
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    [HttpGet]
    public ActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Upload(HttpPostedFileBase file, DateTime expiryDate)
    {
        if (file != null && file.ContentLength > 0)
        {
            byte[] fileData;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }

            var fileUpload = new FileUpload
            {
                FileName = Path.GetFileName(file.FileName),
                FileData = fileData,
                UserName = User.Identity.Name, // Assuming you're using ASP.NET Identity
                UploadDate = DateTime.Now,
                ExpiryDate = expiryDate
            };

            SaveFileToDatabase(fileUpload);
            return RedirectToAction("Upload");
        }
        return View();
    }

    private void SaveFileToDatabase(FileUpload fileUpload)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO FileUploads (FileName, FileData, UserName, UploadDate, ExpiryDate) VALUES (@FileName, @FileData, @UserName, @UploadDate, @ExpiryDate)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FileName", fileUpload.FileName);
                command.Parameters.AddWithValue("@FileData", fileUpload.FileData);
                command.Parameters.AddWithValue("@UserName", fileUpload.UserName);
                command.Parameters.AddWithValue("@UploadDate", fileUpload.UploadDate);
                command.Parameters.AddWithValue("@ExpiryDate", fileUpload.ExpiryDate);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }