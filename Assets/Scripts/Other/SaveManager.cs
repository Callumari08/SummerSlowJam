using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [System.Serializable]
    public struct SaveInfo
    {
        public float currentMoneyAmount;
        public int currentNpcNumber;
        public int currentSavedDay;
        public bool rentCurrentlyPaid;
    }

    public SaveInfo saveInfo;

    string path;

    void Start()
    {
        path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "Save.json";
    }

    public void Save()
    {
        saveInfo.currentMoneyAmount = Money.Current;
        saveInfo.currentNpcNumber = WorkInfo.NPC_number;
        saveInfo.currentSavedDay = TimeManager.currentDay;
        saveInfo.rentCurrentlyPaid = Rent.rentPaid;

        string savePath = path;
        string json = JsonUtility.ToJson(saveInfo);
        
        Debug.Log(json);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void Load()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();
        
        SaveInfo newSaveInfo = JsonUtility.FromJson<SaveInfo>(json);

        Money.Current = newSaveInfo.currentMoneyAmount;
        WorkInfo.NPC_number = newSaveInfo.currentNpcNumber;
        TimeManager.currentDay = newSaveInfo.currentSavedDay;
        Rent.rentPaid = newSaveInfo.rentCurrentlyPaid;
    }
}
