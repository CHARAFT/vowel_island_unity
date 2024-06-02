using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOADER : MonoBehaviour
{
    // Start is called before the first frame updatepublic string sceneName; // Le nom de la scène de destination

   public string sceneName; // Le nom de la scène de destination

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName); // Charge la scène de destination
    }
}
