using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private bool isHooked;
    private Rigidbody blockRB;
    public GameObject pivotSpawn;
    void Start()
    {
        pivotSpawn = GameObject.Find("SpawnPivot");
        blockRB = GetComponent<Rigidbody>();
        isHooked = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHooked)
        {
            transform.position = new Vector3(pivotSpawn.transform.position.x, pivotSpawn.transform.position.y - 0.5f, pivotSpawn.transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isHooked = false;
            blockRB.useGravity = true;
        }
    }
}
