using UnityEngine;

public class StartingBlockScript : MonoBehaviour, IPushHigher
{
    public GameObject NextBlock;

    void OnCollisionEnter(Collision collision)
    {
        NextBlock = collision.gameObject;
    }
    public GameObject PushMechanismHigher()
    {
        return NextBlock;
    }
}
