using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InUse : MonoBehaviour
{
    private bool _free = true;

    public bool Free
    {
        get
        {
            return _free;
        }
        set
        {
            _free = value;
        }
    }
}
