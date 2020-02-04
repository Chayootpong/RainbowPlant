using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject block, backpack;
    public GameObject[] fieldBox;
    public Sprite[] pics;
    public static int dragLimit;
    public int[] seedCount;

    GameObject selectedBlock, blocked;
    bool isBlock = false, isStacked = false;
    Stack<int> list = new Stack<int>(); 
    
    void Start()
    {
        seedCount = SendPattern.seedCount;
        dragLimit = SendPattern.dragLimit;

        for (int i = 0; i < 25; i++)
        {
            if (SendPattern.pattern[i] == 1)
            {
                fieldBox[i].GetComponent<SpriteRenderer>().sprite = pics[0];
                fieldBox[i].tag = "FieldBox";
            }

            else
            {
                fieldBox[i].GetComponent<SpriteRenderer>().sprite = pics[1];
                fieldBox[i].tag = "UnFieldBox";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isPlanted = backpack.GetComponent<TogglePhase>().isPlanted;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.touches.Length >= 1)
        {
            if (hit.collider != null && hit.collider.gameObject.tag == "FieldBox" && !isPlanted)
            {
                if (selectedBlock == hit.collider.gameObject && !isBlock && !isStacked)
                {
                    //Now size = 0.95X
                    blocked = Instantiate(block, new Vector2(hit.collider.gameObject.transform.position.x + 0.95f,
                            hit.collider.gameObject.transform.position.y - 0.475f), hit.collider.gameObject.transform.rotation);
                    CheckStack(int.Parse(selectedBlock.gameObject.name));
                    fieldBox[int.Parse(hit.collider.gameObject.name)].GetComponent<Animator>().enabled = true; //RAINBOW!!!
                    isBlock = true;
                }
                else if (selectedBlock != hit.collider.gameObject)
                {
                    Destroy(blocked);
                    isBlock = false;
                }
                selectedBlock = hit.collider.gameObject;
            }
            else if (hit.collider != null && hit.collider.gameObject.tag == "UnFieldBox" && !isPlanted)
            {
                isStacked = true;
            }
            else if (hit.collider != null && hit.collider.gameObject.tag == "UnFieldBox" && isPlanted)
            {
                fieldBox[int.Parse(hit.collider.gameObject.name)].GetComponent<SpriteRenderer>().sprite = pics[0];
                fieldBox[int.Parse(hit.collider.gameObject.name)].tag = "FieldBox";
            }
        }
        else
        {
            CheckFieldBox();
            list = new Stack<int>();
            isBlock = isStacked = false;
            Destroy(blocked);
        }
    }

    public void CheckStack(int boxid)
    {       
        if (!list.Contains(boxid) && !isStacked)
        {
            list.Push(boxid);
        }
        else
        {
            int temp = list.Pop();

            //DE-RAINBOW!!!
            fieldBox[temp].GetComponent<Animator>().enabled = false;
            fieldBox[temp].GetComponent<SpriteRenderer>().sprite = pics[0];

            if (list.Peek() != boxid) //When stacked plant
            {
                list.Push(temp);
                isStacked = true;
            }
            else isStacked = false;
        }

        ShowStack();
    }

    public void ShowStack()
    {
        string st = "";

        foreach (int a in list) st += a + " ";
        Debug.Log(st + " " + isStacked);
    }

    public void CheckFieldBox()
    {
        if (list.Count > 1)
        {
            foreach (int a in list)
            {
                //DE-RAINBOW!!!
                fieldBox[a].GetComponent<Animator>().enabled = false;
                fieldBox[a].GetComponent<SpriteRenderer>().sprite = pics[1];
                fieldBox[a].tag = "UnFieldBox";
            }            
        }
        
        else
        {
            foreach (int a in list)
            {
                //DE-RAINBOW!!!
                fieldBox[a].GetComponent<Animator>().enabled = false;
                fieldBox[a].GetComponent<SpriteRenderer>().sprite = pics[0];
            }
        }
    }
}
