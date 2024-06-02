using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scores : MonoBehaviour
{
  
    public static scores Instance { get; private set; }
    public int TotalScore { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        TotalScore += score;
    }
}

