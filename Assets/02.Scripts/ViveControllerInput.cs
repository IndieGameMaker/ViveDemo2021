using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveControllerInput : MonoBehaviour
{
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources any       = SteamVR_Input_Sources.Any;

    //Action InteractUI
    private SteamVR_Action_Boolean trigger;
    //Action Trackpad Click
    private SteamVR_Action_Boolean trackPadClick;
    // Trackpad Touch
    private SteamVR_Action_Boolean trackPadTouch;
    // Trackpad Touch Position (Vector2)
    private SteamVR_Action_Vector2 trackPadPosition;

    // Grap
    private SteamVR_Action_Boolean grip = SteamVR_Input.GetBooleanAction("GrabGrip");
    //private SteamVR_Action_Boolean grip2 = SteamVR_Actions.default_GrabGrip;
    
    // Haptic
    private SteamVR_Action_Vibration haptic;

    // HeadSet Sensor
    private SteamVR_Action_Boolean headSet = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("HeadsetOnHead", true);

    void Awake()
    {
        trigger = SteamVR_Actions.default_InteractUI;
        trackPadClick = SteamVR_Actions.default_Teleport;
        trackPadTouch = SteamVR_Actions.default_TrackpadTouch;
        trackPadPosition = SteamVR_Actions.default_TrackpadPosition;
        grip = SteamVR_Input.GetBooleanAction("GrabGrip");
        haptic = SteamVR_Actions.default_Haptic;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetStateDown(any))
        {
            Debug.Log("Trigger Button Down");
        }    

        if (trackPadClick.GetStateUp(any))
        {
            Debug.Log("TrackPad Release");
        }

        if (trackPadTouch.GetState(any))
        {
            Vector2 pos = trackPadPosition.GetAxis(any);
            Debug.Log($"pos x={pos.x}, y={pos.y}");
        }

        if (grip.GetStateDown(rightHand))
        {
            haptic.Execute(0.2f, 0.5f, 200, 0.5f, rightHand);
        }

        if (headSet.GetStateDown(SteamVR_Input_Sources.Head))
        {
            Debug.Log("HeadSet On");
        }

        if (headSet.GetStateUp(SteamVR_Input_Sources.Head))
        {
            Debug.Log("HeadSet Off");
        }        
    }
}
