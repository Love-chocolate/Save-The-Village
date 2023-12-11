using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCycles : MonoBehaviour
{
    private int _peasantsCount = 1;
    private int _wheatCount;
    private int _warriorsCount;
    private int _producedWheats;
    private int _producedWarriors;
    private int _producedPeasants;
    private int _survivedRaids;

    private bool _isPeasantTraining;
    private bool _isWarriorTraining;

    private bool _isEnemyAttacking;

    [SerializeField] private Button _menuButton;

    [SerializeField] private int _cyclesBeforeAttack = 3;
    [SerializeField] private int _enemyCount = 1;

    [SerializeField] private GameObject _winInfo;
    [SerializeField] private GameObject _loseInfo;

    [SerializeField] private Button _hirePeasantButton;
    [SerializeField] private Button _hireWarriorButton;

    [SerializeField] private Text _peasants;
    [SerializeField] private Text _warriors;
    [SerializeField] private Text _wheat;

    [SerializeField] private Text _winInfoProducedWheatsText;
    [SerializeField] private Text _winInfoProducedWarriorsText;
    [SerializeField] private Text _winInfoProducedPeasantsText;
    [SerializeField] private Text _winInfoSurvivedRaidsText;

    [SerializeField] private Text _loseInfoProducedWheatsText;
    [SerializeField] private Text _loseInfoProducedWarriorsText;
    [SerializeField] private Text _loseInfoProducedPeasantsText;
    [SerializeField] private Text _loseInfoSurvivedRaidsText;

    [SerializeField] private Image _wheatClock;
    [SerializeField] private Image _firstWheatClockPart;
    [SerializeField] private Image _secondWheatClockPart;

    [SerializeField] private Image _foodClock;
    [SerializeField] private Image _firstFoodClockPart;
    [SerializeField] private Image _secondFoodClockPart;

    [SerializeField] private Image _enemyClock;
    [SerializeField] private Image _firstEnemyClockPart;
    [SerializeField] private Image _secondEnemyClockPart;

    [SerializeField] private Image _peasantClock;
    [SerializeField] private Image _peasantClockPart;

    [SerializeField] private Image _warriorClock;
    [SerializeField] private Image _warriorClockPart;

    [SerializeField] private float _wheatCycleMaxTime;
    private float _wheatCycleCurrentTime;

    [SerializeField] private float _foodCycleMaxTime;
    private float _foodCycleCurrentTime;

    [SerializeField] private float _enemyCycleMaxTime;
    private float _enemyCycleCurrentTime;

    [SerializeField] private float _peasantTrainingMaxTime;
    private float _peasantTrainingCurrentTime;

    [SerializeField] private float _warriorTrainingMaxTime;
    private float _warriorTrainingnCurrentTime;

    private void Start()
    {
        _producedPeasants = 1;
        SetTime();
        UpdatePeasantCount();
        UpdateWarriorCount();
        UpdateWheatCount();
    }

    private void Update()
    {
        WheatCycleTime();
        Wheat—ollectionCycle();

        FoodCycleTime();
        FoodEatingCycle();
        
        EnemyCycleTime();
        EnemyAttackCycle();

        if(_isEnemyAttacking == true)
        {
            _enemyCycleCurrentTime = _enemyCycleMaxTime;
        }

        if (_isPeasantTraining)
        {
            HirePeasantCycleTime();
            PeasantTraining();
        }

        if (_isWarriorTraining)
        {
            HireWarriorCycleTime();
            WarriorTraining();
        }
    }

    private void Wheat—ollectionCycle()
    {
        _wheatClock.fillAmount = _wheatCycleCurrentTime / _wheatCycleMaxTime;
        _firstWheatClockPart.fillAmount = _wheatCycleCurrentTime / _wheatCycleMaxTime;
        _secondWheatClockPart.fillAmount = _wheatCycleCurrentTime / _wheatCycleMaxTime;
    }

    private void FoodEatingCycle()
    {
        _foodClock.fillAmount = _foodCycleCurrentTime / _foodCycleMaxTime;
        _firstFoodClockPart.fillAmount = _foodCycleCurrentTime / _foodCycleMaxTime;
        _secondFoodClockPart.fillAmount = _foodCycleCurrentTime / _foodCycleMaxTime;
    }

    private void EnemyAttackCycle()
    {
        _enemyClock.fillAmount = _enemyCycleCurrentTime / _enemyCycleMaxTime;
        _firstEnemyClockPart.fillAmount = _enemyCycleCurrentTime / _enemyCycleMaxTime;
        _secondEnemyClockPart.fillAmount = _enemyCycleCurrentTime / _enemyCycleMaxTime;
    }

    public void PeasantTraining()
    {
        _peasantClock.fillAmount = _peasantTrainingCurrentTime / _peasantTrainingMaxTime;
        _peasantClockPart.fillAmount = _peasantTrainingCurrentTime / _peasantTrainingMaxTime;
    }

    public void WarriorTraining()
    {
        _warriorClock.fillAmount = _warriorTrainingnCurrentTime / _warriorTrainingMaxTime;
        _warriorClockPart.fillAmount = _warriorTrainingnCurrentTime / _warriorTrainingMaxTime;
    }

    private void SetTime()
    {
        _wheatCycleCurrentTime = _wheatCycleMaxTime;
        _foodCycleCurrentTime = _foodCycleMaxTime;
        _enemyCycleCurrentTime = _enemyCycleMaxTime;
        _peasantTrainingCurrentTime = _peasantTrainingMaxTime;
        _warriorTrainingnCurrentTime = _warriorTrainingMaxTime;
    }

    private void WheatCycleTime()
    {
        _wheatCycleCurrentTime -= Time.deltaTime;

        if (_wheatCycleCurrentTime <= 0)
        {
            if(_cyclesBeforeAttack > 0)
            {
                _cyclesBeforeAttack--;
            }

            _producedWheats += _peasantsCount * 1;
            _wheatCount += _peasantsCount * 1;
            UpdateWheatCount();
            WheatSound._collectWheatSound.Play();

            _wheatCycleCurrentTime = _wheatCycleMaxTime;
        }
    }

    private void FoodCycleTime()
    {
        if(_warriorsCount > 0)
        {
            _foodCycleCurrentTime -= Time.deltaTime;

           

            if (_foodCycleCurrentTime <= 0)
            {
                _wheatCount -= _warriorsCount * 3;
                UpdateWheatCount();
                FoodSound._eatFoodSound.Play();

                _foodCycleCurrentTime = _foodCycleMaxTime;

            }
        }
    }

    private void EnemyCycleTime()
    {
        if(_cyclesBeforeAttack == 0)
        {
            _enemyCycleCurrentTime -= Time.deltaTime;

            if (_enemyCycleCurrentTime <= 0)
            {
                _isEnemyAttacking = true;
                StartCoroutine(EnemyAttack());
                BattleSound._battleSound.Play();

                _enemyCycleCurrentTime = _enemyCycleMaxTime;
            }
        }
    }

    private void HirePeasantCycleTime()
    {
        _peasantTrainingCurrentTime -= Time.deltaTime;

        _hirePeasantButton.interactable = false;

        if (_peasantTrainingCurrentTime <= 0)
        {
            if(_wheatCount == 0)
            {
                _hirePeasantButton.interactable = false;
            }
            else
            {
                _hirePeasantButton.interactable = true;
            }

            _isPeasantTraining = false;
            _producedPeasants++;
            _peasantsCount++;
            UpdatePeasantCount();
            PeasantSound._hirePeasantSound.Play();

            _peasantTrainingCurrentTime = _peasantTrainingMaxTime;
        }
    }

    private void HireWarriorCycleTime()
    {
        _warriorTrainingnCurrentTime -= Time.deltaTime;

        _hireWarriorButton.interactable = false;

        if (_warriorTrainingnCurrentTime <= 0)
        {
            if (_wheatCount == 0)
            {
                _hireWarriorButton.interactable = false;
            }
            else
            {
                _hireWarriorButton.interactable = true;
            }

            _isWarriorTraining = false;
            _hireWarriorButton.interactable = true;
            _producedWarriors++;
            _warriorsCount++;
            UpdateWarriorCount();
            WarriorSound._hireWarriorSound.Play();

            _warriorTrainingnCurrentTime = _warriorTrainingMaxTime;
        }
    }

    public void isPeasantButtonClicked()
    {
        if (_wheatCount < 2)
        {
            return;
        }
        else if (_wheatCount >= 2 && _isPeasantTraining == false)
        {
            _isPeasantTraining = true;
            _hirePeasantButton.interactable = false;
            _wheatCount -= 2;
            UpdateWheatCount();
        }
    }

    public void isWarriorButtonClicked()
    {
        if (_wheatCount < 5)
        {
            return;
        }
        else if (_wheatCount >= 5 && _isWarriorTraining == false)
        {
            _isWarriorTraining = true;
            _hireWarriorButton.interactable = false;
            _wheatCount -= 5;
            UpdateWheatCount();
        }
    }

    private void UpdateWheatCount()
    {
        if(_wheatCount < 0)
        {
            _wheatCount = 0;
        }

        if (_wheatCount < 2)
        {
            _hirePeasantButton.interactable = false;
        }
        else
        {
            _hirePeasantButton.interactable = true;
        }

        if (_wheatCount < 5)
        {
            _hireWarriorButton.interactable = false;
        }
        else
        {
            _hireWarriorButton.interactable = true;
        }

        _wheat.text = "œ¯ÂÌËˆ‡: " + _wheatCount;


    }

    private void UpdateWarriorCount()
    {
        _warriors.text = "¬ÓËÌ˚: " + _warriorsCount;

        if (_warriorsCount <= 0)
        {
            _foodCycleCurrentTime = _foodCycleMaxTime;
        }

        LoseInfo();
    }

    private void UpdatePeasantCount()
    {
        _peasants.text = " ÂÒÚ¸ˇÌÂ: " + _peasantsCount;
        WinInfo();
    }

    private void WinInfo()
    {
        if(_peasantsCount == 200)
        {
            Time.timeScale = 0;
            _winInfoSurvivedRaidsText.text = _survivedRaids.ToString();
            _winInfoProducedWheatsText.text = _producedWheats.ToString();
            _winInfoProducedPeasantsText.text = _producedPeasants.ToString();
            _winInfoProducedWarriorsText.text = _producedWarriors.ToString();
            _winInfo.SetActive(true);
            _menuButton.interactable = false;
        }
        
    }

    private void LoseInfo()
    {
        if (_warriorsCount < 0)
        {
            Time.timeScale = 0;
            _loseInfoSurvivedRaidsText.text = _survivedRaids.ToString();
            _loseInfoProducedWheatsText.text = _producedWheats.ToString();
            _loseInfoProducedPeasantsText.text = _producedPeasants.ToString();
            _loseInfoProducedWarriorsText.text = _producedWarriors.ToString();
            _loseInfo.SetActive(true);
            _menuButton.interactable = false;
        }
    }

    private IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(3);
        _warriorsCount = _warriorsCount - _enemyCount;
        UpdateWarriorCount();

        if (_warriorsCount >= 0)
        {
            _survivedRaids++;
        }

        _enemyCount *= 2;

        _isEnemyAttacking = false;
    }

    private IEnumerator WaitToNextAttack()
    {
        yield return new WaitForSeconds(3);
    }

}
