using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private Button _hirePeasantButton;
    [SerializeField] private Button _hireWarriorButton;
    public void OpenMenu()
    {
        _menu.SetActive(true);
        _hirePeasantButton.interactable = false;
        _hireWarriorButton.interactable = false;
        Time.timeScale = 0;
    }
}
