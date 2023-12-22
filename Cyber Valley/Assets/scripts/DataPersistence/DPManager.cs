using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPManager : MonoBehaviour
{

    private GameData gameData;

    public static DPManager instance {get; private set;}

    private void awake()
    {
        if(instance != null) 
        {
            Debug.LogError("Es wurden mehr als ein DP Manager gefunden");
        }
        
        
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        if(this.gameData == null)
        {
            Debug.Log("Keine daten gefunden");
            NewGame();
        }
    }

    public void SaveGame()
    {

    }
}
