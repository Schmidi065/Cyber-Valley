using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour, IDataPersistence
{
    public Image healthbar;
    public float healthAmount = 100f;

    public void LoadData(GameData data)
    {
        this.healthAmount = data.health;
    }

    public void SaveData(ref GameData data)
    {
        data.health = this.healthAmount;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.L)) 
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown (KeyCode.O)) 
        {
            Heal(5);
        }
    }

    public void TakeDamage(float damage) 
    {
        healthAmount-=damage;  
        healthbar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthbar.fillAmount = healthAmount / 100f;
    }
}
