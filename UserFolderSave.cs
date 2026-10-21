using System;
using System.IO;

public class UserFolderSave : Saver
{
    public override void Save(string fileName, string content)
    {
        string userPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        string fullPath = Path.Combine(userPath, fileName);

        File.WriteAllText(fullPath, content);
        Console.WriteLine($"[User Folder] gemt: {fullPath}");
    }
}