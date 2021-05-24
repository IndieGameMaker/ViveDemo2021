using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private LineRenderer line;

    private SteamVR_Action_Boolean trigger;

    // Line Max Distance
    public float maxDistance = 30.0f;

    // Line Color
    public Color color = Color.blue;
    public Color clickedColor = Color.green;
    
    void Start()
    {
        trigger = SteamVR_Actions.default_InteractUI;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
