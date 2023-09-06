using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public static GameExit instance;
    public Canvas canvas;
    public bool isend;

    private void Awake()
    {
        instance = this;
    }
    public void GameEndClick()
    {
        canvas.gameObject.SetActive(true);
        isend = true;
    }

    public void GameEnd()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void EndCancel()
    {
        canvas.gameObject.SetActive(false);
        isend = false;
    }
}
