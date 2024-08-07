using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject quitB, replayB;
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        MouseManager.instance.MouseOff();
        quitB.SetActive(false);
        replayB.SetActive(false);
    }
    public void SetStatusButtonOn()
    {
        MouseManager.instance.MouseOn();
        quitB.SetActive(true);
        replayB.SetActive(true);
    }
}
