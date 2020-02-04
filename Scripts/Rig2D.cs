using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rig2D : MonoBehaviour
{
    Rigidbody2D rg;
    public float x, y, speed;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.AddForce(new Vector2(x, y) * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
