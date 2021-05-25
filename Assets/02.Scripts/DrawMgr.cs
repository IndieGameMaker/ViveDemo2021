using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DrawMgr : MonoBehaviour
{
    private SteamVR_Input_Sources rightHand;
    private SteamVR_Action_Boolean trigger;
    private SteamVR_Action_Pose pose;

    public float lineWidth = 0.01f;
    public Color lineColor = Color.white;

    private LineRenderer line;

    void Start()
    {
        rightHand = SteamVR_Input_Sources.RightHand;        
        trigger   = SteamVR_Actions.default_InteractUI;
        pose      = SteamVR_Actions.default_Pose;
    }

    void Update()
    {
        if (trigger.GetStateDown(rightHand))
        {
            CreateLineObject();
        }

        if (trigger.GetState(rightHand))
        {
            Vector3 position = pose.GetLocalPosition(rightHand);
            ++line.positionCount;
            line.SetPosition(line.positionCount-1, position);
        }     
    }

    void CreateLineObject()
    {
        GameObject lineObject = new GameObject("Line");
        line = lineObject.AddComponent<LineRenderer>();

        Material mt = new Material(Shader.Find("Unlit/Color"));
        mt.color = lineColor;

        line.material = mt;
        line.useWorldSpace = false;

        line.numCapVertices = 20;
        line.numCornerVertices = 20;

        line.widthMultiplier = 0.1f;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        line.positionCount = 1;

        Vector3 position = pose.GetLocalPosition(rightHand);
        line.SetPosition(0, position);
    }
}
