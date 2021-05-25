using System.Collections;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private LineRenderer line;

    private SteamVR_Action_Boolean trigger;
    private SteamVR_Action_Boolean teleport;

    // Line Max Distance
    public float maxDistance = 30.0f;

    // Line Color
    public Color color = Color.blue;
    public Color clickedColor = Color.green;

    // Raycast Variables
    private RaycastHit hit;
    private Transform tr;

    // Pointer Prefabs
    private GameObject pointerPrefab;

    // Pointer
    private GameObject pointer;
    // Duration Dark Screen
    public float fadeOutTime = 0.2f;
    
    void Start()
    {
        tr = GetComponent<Transform>();
        trigger = SteamVR_Actions.default_InteractUI;
        teleport = SteamVR_Actions.default_Teleport;

        // Resources Folder Loading
        pointerPrefab = Resources.Load<GameObject>("Pointer");
        // Create Pointer
        pointer = Instantiate<GameObject>(pointerPrefab);

        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource;
        CreateLine();
    }

    // LineRenderer Create
    void CreateLine()
    {
        line = this.gameObject.AddComponent<LineRenderer>();

        line.useWorldSpace = false;

        // Start , End Position Setting
        line.positionCount = 2; // Index 0, 1
        line.SetPosition(0, Vector3.zero);  // Index 0 (0, 0, 0)
        line.SetPosition(1, new Vector3(0, 0, maxDistance));  // Index 1 (0, 0, 30)

        // Line Width Setting
        line.startWidth = 0.03f;
        line.endWidth   = 0.005f;

        // Materials Setting
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = this.color;
    }

    void Update()
    {
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance))
        {
            line.SetPosition(1, new Vector3(0, 0, hit.distance));
            pointer.transform.position = hit.point + (hit.normal * 0.01f);
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
        else
        {
            line.SetPosition(1, new Vector3(0, 0, maxDistance));
            pointer.transform.position = tr.position + (tr.forward * maxDistance);
            pointer.transform.rotation = Quaternion.LookRotation(tr.forward);
        }

        // When Click Teleport 
        if (teleport.GetStateDown(hand) || Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance, 1<<8))
            {
                // Screen Dark
                SteamVR_Fade.Start(Color.black, 0);
                StartCoroutine(Teleport(hit.point));
            }
        }
    }

    IEnumerator Teleport(Vector3 pos)
    {
        tr.parent.position = pos;
        yield return new WaitForSeconds(fadeOutTime);
        SteamVR_Fade.Start(Color.clear, 0.3f);
    }

}
