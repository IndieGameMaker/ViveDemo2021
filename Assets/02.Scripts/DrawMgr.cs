using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DrawMgr : MonoBehaviour
{
    private SteamVR_Input_Sources rightHand;
    private SteamVR_Action_Boolean trigger;
    private SteamVR_Action_Pose pose;

    void Start()
    {
        rightHand = SteamVR_Input_Sources.RightHand;        
        trigger   = SteamVR_Actions.default_InteractUI;
        pose      = SteamVR_Actions.default_Pose;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
