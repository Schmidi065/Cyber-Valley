using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    private static UIManagerScript _instance;
    public static UIManagerScript Instance {  get { return _instance; } }

    // Start is called before the first frame update
    private void Awake()
    {
      if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    
}
