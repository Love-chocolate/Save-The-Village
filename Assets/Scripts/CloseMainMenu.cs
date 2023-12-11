using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private Button _hirePeasantButton;
    [SerializeField] private Button _hireWarriorButton;

    public void CloseMenu()
    {
        _menu.SetActive(false);
        _hirePeasantButton.interactable = true;
        _hireWarriorButton.interactable = true;
        Time.timeScale = 1;
    }
}
