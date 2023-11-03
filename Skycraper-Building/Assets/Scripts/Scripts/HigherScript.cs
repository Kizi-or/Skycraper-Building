using UnityEngine;

public class HigherScript : MonoBehaviour
{
    const float SmoothSpeed = 0.125f;
    Vector3 _targetPosition;

    void FixedUpdate()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, _targetPosition, SmoothSpeed);
        transform.position = smoothedPosition;
    }

    public void Higher(GameObject planeBlock,float xOffset, float yOffset, float zOffset)
    {
        _targetPosition = new Vector3(planeBlock.transform.position.x + xOffset,planeBlock.transform.position.y + yOffset, planeBlock.transform.position.z + zOffset);
    }
    public void Higher(float xOffset, float yOffset, float zOffset)
    {
        _targetPosition = new Vector3(xOffset,yOffset,zOffset);
    }
}
