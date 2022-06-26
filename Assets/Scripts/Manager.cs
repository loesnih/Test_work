using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject pochatokText;
    [SerializeField] Text cashCoins;
    [SerializeField] GameObject FX_full;

    [SerializeField] UnityEvent events;
    [SerializeField] GameObject turel;
    
    void Update()
    {
        
        cashCoins.text = player.Cash.ToString();

        if (player.count == player.MaxCount)
        {
            pochatokText.SetActive(true);
            FX_full.SetActive(true);
        }
        if (player.count < player.MaxCount)
        {
            FX_full.SetActive(false);
            pochatokText.SetActive(false);
        }
    }

    public void LetsGo()
    {
        events.Invoke();
        player.Cash += 15;
    }

    public void TurelInstance()
    {
        if (player.Cash < 1000)
        {
            return;
        }
        player.Cash -= 1000;
        
        Instantiate(turel,player.transform.position,player.transform.rotation);
    }
    public void Version1_0()
    {
        SceneManager.LoadScene(0);
    }
    public void Version1_1()
    {
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

}
