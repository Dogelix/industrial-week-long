using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class PlayerManager : MonoBehaviour
{
    private GameObject[] _players = new GameObject[4];

    public void AddPlayerToManager(GamePad.Index playerNum, GameObject playerObj)
    {
        switch (playerNum)
        {
            case GamePad.Index.One:
                _players[0] = playerObj;
                break;
            case GamePad.Index.Two:
                _players[1] = playerObj;
                break;
            case GamePad.Index.Three:
                _players[2] = playerObj;
                break;
            case GamePad.Index.Four:
                _players[3] = playerObj;
                break;
        }
    }
}
