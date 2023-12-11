using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartOrMuteMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    private Text _buttonText;
    
    void Start()
    {
        _buttonText = GetComponentInChildren<Text>();
        _buttonText.text = "Выключить звук";
    }

    public void StartOrMuteSound()
    {
        if(_backgroundMusic.isPlaying)
        {
            _backgroundMusic.Pause();
            BattleSound._battleSound.volume = 0;
            WheatSound._collectWheatSound.volume = 0;
            FoodSound._eatFoodSound.volume = 0;
            PeasantSound._hirePeasantSound.volume = 0;
            WarriorSound._hireWarriorSound.volume = 0;
            ClickSound.click.volume = 0;
            _buttonText.text = "Включить звук";
        }
        else
        {
            _backgroundMusic.Play();
            BattleSound._battleSound.volume = 1;
            WheatSound._collectWheatSound.volume = 1;
            FoodSound._eatFoodSound.volume = 1;
            PeasantSound._hirePeasantSound.volume = 0.3f;
            WarriorSound._hireWarriorSound.volume = 0.3f;
            ClickSound.click.volume = 1;
            _buttonText.text = "Выключить звук";
        }

    }
}
