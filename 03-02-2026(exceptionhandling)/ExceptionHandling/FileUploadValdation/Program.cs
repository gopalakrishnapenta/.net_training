using System;

class FileUpload
{
    static void Main()
    {
        string fileName = "report.pdf";
        int fileSize = 8; // MB
        int maxSize = 5;  // MB

        try
        {
            // 1. Validate file extension
            if (!fileName.EndsWith(".pdf") && !fileName.EndsWith(".docx"))
            {
                throw new NotSupportedException("Invalid file type. Only PDF and DOCX files are allowed.");
            }

            // 2. Validate file size
            if (fileSize > maxSize)
            {
                throw new ArgumentOutOfRangeException(
                    "fileSize", "File size exceeds the maximum allowed limit."
                );
            }

            Console.WriteLine("File uploaded successfully.");
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine("Upload error: " + ex.Message);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Upload error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}
