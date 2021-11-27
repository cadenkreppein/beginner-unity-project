using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] Text textObject;
    int totalCoinsInLevel;
    int coinCount;
    string baseText;
    
    // Start is called before the first frame update
    void Start()
    {
        totalCoinsInLevel = GameObject.Find("Collectibles").transform.childCount;
        Debug.Log("Total coins in level is: " + totalCoinsInLevel);
        coinCount = 0;
        baseText = "Coins: ";
        textObject.text = baseText + coinCount;
    }

    // Update is called once per frame
    void Update()
    {
        textObject.text = baseText + coinCount;
    }

    public void IncrementCounter()
    {
        coinCount++;
        if (coinCount >= totalCoinsInLevel)
        {
            SceneManager.LoadScene(1);
        }
    }
}
