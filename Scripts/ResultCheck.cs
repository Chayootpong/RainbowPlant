using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCheck : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] result;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TouchPoint.dragLimit == 0 && GameObject.FindGameObjectWithTag("FieldBox")) result[0].SetActive(true);
        else result[1].SetActive(true);
    }
}
