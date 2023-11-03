using UnityEngine;

public class EndResultScript : MonoBehaviour
{
    public static EndResultScript Instance;
    public double Result;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            Result = 0.0f;
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
