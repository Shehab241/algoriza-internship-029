namespace Vezeta.API.Helpers
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            //string floderPath = "D:\\Courses\\Computer Science\\.Net\\Projects\\Company Management System\\Demo.PL\\wwwroot\\files\\";
            //string folderPath=Directory.GetCurrentDirectory()+ "\\wwwroot\\files\\" + folderName;
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            string filePath = Path.Combine(folderPath, fileName);

            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);

            return fileName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            if (File.Exists(filePath))
                File.Delete(filePath);


        }
    }
}
