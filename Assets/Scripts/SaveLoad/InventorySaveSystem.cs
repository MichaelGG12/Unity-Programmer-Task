using System.IO;
using UnityEngine;

public static class InventorySaveSystem
{
    private static string saveFilePath => Application.persistentDataPath + "/inventory.json";

    public static void Save(InventorySaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Successfully saved at: " + saveFilePath);
    }

    public static InventorySaveData Load()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.Log("No saved data found.");
            return null;
        }
        string json = File.ReadAllText(saveFilePath);
        return JsonUtility.FromJson<InventorySaveData>(json);
    }
}