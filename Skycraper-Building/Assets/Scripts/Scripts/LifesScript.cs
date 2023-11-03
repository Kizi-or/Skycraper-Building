using UnityEngine;

public class LifesScript : MonoBehaviour
{
    public GameObject[] Hearts;
    int _lifes = 3;

    public void LoseHeart()
    {
        _lifes--;
        Destroy(Hearts[_lifes].gameObject);
    }
}
