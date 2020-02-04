using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePhase : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPlanted = false;
    public Sprite[] pics;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {
        isPlanted = !isPlanted;
        if (isPlanted) gameObject.GetComponent<SpriteRenderer>().sprite = pics[0];
        else gameObject.GetComponent<SpriteRenderer>().sprite = pics[1];
    }
}
