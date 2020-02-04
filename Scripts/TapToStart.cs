using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TapToStart : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] seed;
    public Image bag;
    public GameObject[] UI;
    public Sprite bagOpen;
    void Start()
    {
        Invoke("ShowUI", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUI()
    {
        foreach (GameObject x in UI) x.SetActive(true);
    }

    public void TapStart()
    {
        foreach (GameObject x in seed) x.SetActive(true);
        bag.GetComponent<Image>().sprite = bagOpen;
        Invoke("ChangeScene", 3f);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Stage");
    }
}
