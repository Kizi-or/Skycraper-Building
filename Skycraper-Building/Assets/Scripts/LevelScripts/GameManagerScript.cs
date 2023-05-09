using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private int blocks = 0;
    public GameObject block;
    public GameObject pivotLine;
    void Start()
    {
        pivotLine = GameObject.Find("SpawnPivot");
        Instantiate(block, pivotLine.transform.position, block.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
}
