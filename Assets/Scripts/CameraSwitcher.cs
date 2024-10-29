using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CameraSwitcher : MonoBehaviour
{
    public ARCameraManager cameraManager;
    public ARFaceManager faceManager;
    public ARPlaneManager planeManager;
    public FacePrefabSwitcher facePrefabSwitcher;
    public ARSession arSession;
    public GameObject filterButtons;

    private bool usingFrontCamera = false;

    public void SwitchCamera()
    {
        usingFrontCamera = !usingFrontCamera;
        cameraManager.requestedFacingDirection = usingFrontCamera 
            ? CameraFacingDirection.User 
            : CameraFacingDirection.World;
        
        faceManager.enabled = usingFrontCamera;
        planeManager.enabled = !usingFrontCamera;
        filterButtons.SetActive(usingFrontCamera);

        if (facePrefabSwitcher != null)
            facePrefabSwitcher.enabled = usingFrontCamera;

        if (arSession != null)
            arSession.Reset();
    }
}
