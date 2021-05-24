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
        
    }

    // Disconnect Event Function
    void OnDisable()
    {

    }

    void OnPointerEnter()
    {

    }

    void OnPointerExit()
    {

    }

    void OnPointerClick()
    {
        
    }

}
