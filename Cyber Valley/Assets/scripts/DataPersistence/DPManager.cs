using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DPManager : MonoBehaviour
{
    public static DPManager instance { get; private set; }

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one DPManager in scene.");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        Debug.LogError("Saved Health level " + gameData.health);
    }

    public void LoadGame()
    {
        if (this.gameData == null)
        {
            Debug.LogError("No Data was found. Set back to default initialization");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.LogError("Loaded Health level " + gameData.health);
    }

    public void ApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}



