using System;
using System.IO;
using UnityEngine;

public static class FileUtilities
{

    static string GetPath() {
        string path = Path.GetFullPath("./") + "Save";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return path + "/";
    }

   public static void SaveFile(string fileName, string data)
   {
       StreamWriter sw = new StreamWriter(GetPath() + fileName);
       sw.Write(data);
       sw.Close();
   }

   public static string LoadFile(string fileName)
   {
       StreamReader sr = new StreamReader(GetPath() + fileName);
       string data = sr.ReadLine();
       sr.Close();
        return data;
   }
}