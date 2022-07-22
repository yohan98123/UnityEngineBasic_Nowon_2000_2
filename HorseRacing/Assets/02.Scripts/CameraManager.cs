using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera PlayerFollowingCam;

    private void Awake()
    {
        mainCam.enabled = true;
        PlayerFollowingCam.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            SwitchCam();
    }

    private void SwitchCam()
    {
      
       mainCam.enabled = !mainCam.enabled;
       PlayerFollowingCam.enabled = !PlayerFollowingCam.enabled;
    }
}
