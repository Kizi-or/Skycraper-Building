using UnityEngine;

public class EscapeScript : MonoBehaviour
{
    public GameObject Canvas;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            ChangeStateOfMenu();
    }
    public void ChangeStateOfMenu()
    {
        if (Canvas.activeSelf)
            Canvas.SetActive(false);
        else
            Canvas.SetActive(true);
    }
}
