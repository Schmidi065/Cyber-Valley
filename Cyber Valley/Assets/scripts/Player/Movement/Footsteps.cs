using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject footstep;

    void Start()
    {
        footstep.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("w") || Input.GetKeyDown("s") || Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {
            footstep.SetActive(true);
        }

        if (Input.GetKeyUp("w") || Input.GetKeyUp("s") || Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            footstep.SetActive(false);
        }
    }
}