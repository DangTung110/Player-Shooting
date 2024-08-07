using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Menu[] menus;
    public void OpenMenu(string name)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == name) 
                menus[i].Open();
            else
                menus[i].Close();
        }
    }
    public void GameStart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game Scene");
    }
    public void MenuStart()
    {
        SceneManager.LoadScene("Menu Scene");
    }
}
