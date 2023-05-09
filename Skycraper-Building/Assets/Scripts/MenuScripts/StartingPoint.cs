using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingPoint : MonoBehaviour
{
    public void MainScene()
    {
        SceneManager.LoadScene(3);
    }
}
