using System.IO;
using UnityEngine;

public static class SaveDataController
{
    private const string CounterFileName = "counter.txt";
    private static readonly string _saveDataPath =Path.Combine(Application.persistentDataPath, CounterFileName);

    public static void SaveCounter(int count)
    {
        File.WriteAllText(_saveDataPath, count.ToString());
    }
    
    public static void DeleteCounter()
    {
        if (File.Exists(_saveDataPath))
        {
            File.Delete(_saveDataPath);
        }
    }

    public static int LoadCounter(int defaultValue)
    {
        if (File.Exists(_saveDataPath))
        {
            var content = File.ReadAllText(_saveDataPath);
            if (int.TryParse(content, out int value))
            {
                return value;
            }
        }

        return defaultValue;
    }
}