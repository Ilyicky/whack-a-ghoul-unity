using System;
using UnityEngine;

public class GhoulStates : MonoBehaviour
{
    private bool isAppearing = false;
    private bool isHit = false;
    private bool isDisappearing = false;

    public bool IsAppearing
    {
        get {return isAppearing;}
        set {isAppearing = value;}
    }

    public bool IsHit
    {
        get {return isHit;}
        set {isHit = value;}
    }
    public bool IsDisappearing
    {
        get {return isDisappearing;}
        set {isDisappearing = value;}
    }

    public Action ghoulHit;
    public Action ghoulDisappear;
    public Action ghoulAppear;
}
