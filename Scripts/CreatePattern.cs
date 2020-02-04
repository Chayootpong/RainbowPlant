using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatePattern : MonoBehaviour
{
    public int[] cropPattern, seedCount;
    public int dragLimit;
    public GameObject loading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void sendPattern()
    {
        SendPattern.pattern = cropPattern;
        SendPattern.seedCount = this.seedCount;
        loading.SetActive(true);
        Invoke("LoadingScene", 2f);
    }

    public void LoadingScene()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
