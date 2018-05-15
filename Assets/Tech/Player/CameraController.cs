using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class CameraController : MonoBehaviour
{
    public struct ViewSizes
    {
        public float x, y, h, w;

        public ViewSizes(float _x, float _y, float _h, float _w)
        {
            x = _x;
            y = _y;
            h = _h;
            w = _w;
        }
    }

    private Camera cam;

    ViewSizes _onePlayer = new ViewSizes(0, 0, 1, 1);
    ViewSizes _player1 = new ViewSizes(0, 0.5f, 0.5f, 0.5f);
    ViewSizes _player2 = new ViewSizes(0.5f, 0.5f, 0.5f, 0.5f);
    ViewSizes _player3 = new ViewSizes(0, 0, 0.5f, 0.5f);
    ViewSizes _player4 = new ViewSizes(0.5f, 0, 0.5f, 0.5f);

    // Use this for initialization
    void Start()
    {
        cam = gameObject.GetComponentInChildren<Camera>();
    }

    public void SetUpCameraSize(GamePad.Index pNumber, bool fullScreen)
    {
        if (!fullScreen)
        { 
            switch (pNumber)
            {
                case GamePad.Index.One:
                    cam.rect = new Rect(_player1.x, _player1.y, _player1.h, _player1.w);
                    break;
                case GamePad.Index.Two:
                    cam.rect = new Rect(_player2.x, _player2.y, _player2.h, _player2.w);
                    break;
                case GamePad.Index.Three:
                    cam.rect = new Rect(_player3.x, _player3.y, _player3.h, _player3.w);
                    break;
                case GamePad.Index.Four:
                    cam.rect = new Rect(_player4.x, _player4.y, _player4.h, _player4.w);
                    break;
            }
        }
        else
        {
            cam.rect = new Rect(_onePlayer.x, _onePlayer.y, _onePlayer.h, _onePlayer.w);
        }
    }
}
