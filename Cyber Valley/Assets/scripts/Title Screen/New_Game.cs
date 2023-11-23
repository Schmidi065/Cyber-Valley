using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_Game : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
