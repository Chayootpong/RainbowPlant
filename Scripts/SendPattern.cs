using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPattern : MonoBehaviour
{
    public static int[] pattern, seedCount;
    public static int dragLimit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
