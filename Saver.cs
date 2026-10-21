using System;
using System.IO;


public class Saver	
{
	protected string savePath;

    public Saver()
    {

    }

    public Saver(string savePath)
	{
		this.savePath = savePath;
	}

    public virtual void Save(string fileName, string content)
    {
        System.IO.File.WriteAllText(savePath, content);
    }
    public void Save()
    {
        
    }
}
