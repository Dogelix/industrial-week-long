using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class IGUIController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _healthSprites;
    [SerializeField]
    private Sprite[] _towerSprites;
    [SerializeField]
    private Sprite[] _lapNumbers;
    [SerializeField]
    private Sprite[] _positionNumbers;

    [SerializeField]
    private Image[] _inventoryImages;
    [SerializeField]
    private Image _currentLap;
    [SerializeField]
    private Image _posistionNumber;
    [SerializeField]
    private Image _healthImag;

    public void SetHealth(int health)
    {
        switch (health)
        {
            case 8:
                _healthImag.sprite = _healthSprites[0];
                break;
            case 7:
                _healthImag.sprite = _healthSprites[1];
                break;
            case 6:
                _healthImag.sprite = _healthSprites[2];
                break;
            case 5:
                _healthImag.sprite = _healthSprites[3];
                break;
            case 4:
                _healthImag.sprite = _healthSprites[4];
                break;
            case 3:
                _healthImag.sprite = _healthSprites[5];
                break;
            case 2:
                _healthImag.sprite = _healthSprites[6];
                break;
            case 1:
                _healthImag.sprite = _healthSprites[7];
                break;
            default:
                break;
        }
    }

    public void SetLap(int lap)
    {
        if (lap == 1)
        {
            lap++;
        }
        _currentLap.sprite = _lapNumbers[lap - 1];
    }

    public void SetPosition(int pos)
    {
        if (pos == 1)
        {
            pos++;
        }
        _posistionNumber.sprite = _positionNumbers[pos - 1];
    }

    public void SetInventoryImages(ETower tower, int inventoryLoc)
    {
        switch (tower)
        {
            case ETower.Freeze:
                _inventoryImages[inventoryLoc].sprite = _towerSprites[0];
                break;
            case ETower.StandardCannon:
                _inventoryImages[inventoryLoc].sprite = _towerSprites[1];
                break;
            case ETower.StaticCannon:
                _inventoryImages[inventoryLoc].sprite = _towerSprites[2];
                break;
            case ETower.Reverse:
                _inventoryImages[inventoryLoc].sprite = _towerSprites[3];
                break;
            case ETower.NULL:
                _inventoryImages[inventoryLoc].sprite = _towerSprites[4];
                break;
        }
    }
}
