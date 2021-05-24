using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
// SteamVR_LaserPointer
using Valve.VR.Extras;

public class CastEventToUI : MonoBehaviour
{
    private SteamVR_LaserPointer laserPointer;

    void Awake()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
    }

    // Connect Event Function
    void OnEnable()
    {
        laserPointer.PointerIn      += this.OnPointerEnter;
        laserPointer.PointerOut     += this.OnPointerExit;
        laserPointer.PointerClick   += this.OnPointerClick;
    }

    // Disconnect Event Function
    void OnDisable()
    {
        laserPointer.PointerIn      -= this.OnPointerEnter;
        laserPointer.PointerOut     -= this.OnPointerExit;
        laserPointer.PointerClick   -= this.OnPointerClick;
    }

    void OnPointerEnter(object sender, PointerEventArgs e)
    {

    }

    void OnPointerExit(object sender, PointerEventArgs e)
    {

    }

    void OnPointerClick(object sender, PointerEventArgs e)
    {

    }

}
