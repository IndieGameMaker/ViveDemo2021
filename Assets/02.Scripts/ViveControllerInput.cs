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
    private SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    //Action Trackpad Click
    private SteamVR_Action_Boolean trackPadClick = SteamVR_Actions.default_Teleport;
    // Trackpad Touch
    private SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_TrackpadTouch;
    // Trackpad Touch Position (Vector2)
    private SteamVR_Action_Vector2 trackPadPosition = SteamVR_Actions.default_TrackpadPosition;

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
    }
}
