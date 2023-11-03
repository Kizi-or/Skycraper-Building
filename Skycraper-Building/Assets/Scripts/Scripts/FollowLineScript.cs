using UnityEngine;

public class FollowLineScript : MonoBehaviour
{
    GameObject _endOfLine;
    void Start()
    {
        _endOfLine = GameObject.Find("SpawnHook");
    }
    void Update()
    {
        Following();
    }
    void Following()
    {
        transform.position = new Vector3(_endOfLine.transform.position.x, _endOfLine.transform.position.y, _endOfLine.transform.position.z);
    }
}
