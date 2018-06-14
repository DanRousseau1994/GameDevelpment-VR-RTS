using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayManager : MonoBehaviour
{
    private void Start()
    {
        OVRManager.tiledMultiResLevel = OVRManager.TiledMultiResLevel.LMSHigh;
        OVRManager.display.displayFrequency = 10.0f;
    }
}