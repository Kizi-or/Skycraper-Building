using TMPro;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        ScoreText.text = "Score\n" + EndResultScript.Instance.Result;
    }
}
