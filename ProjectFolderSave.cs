using System;
using System.IO;

public class ProjectFolderSave : Saver
{
    public override void Save(string fileName, string content)
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory;

        string fullPath = Path.Combine(projectPath, fileName);

        // Dosyaya yazma işlemi
        File.WriteAllText(fullPath, content);
        Console.WriteLine($"Sved til projeckt folder: {fullPath}");
    }
}