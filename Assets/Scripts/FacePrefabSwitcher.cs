using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FacePrefabSwitcher : MonoBehaviour
{
    private ARFaceManager faceManager;
    public GameObject[] facePrefabs;

    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();
        faceManager.facePrefab = null;
    }

    public void SwitchFacePrefab(int index)
    {
        if (index >= 0 && index < facePrefabs.Length)
        {
            faceManager.facePrefab = facePrefabs[index];
            RestartFaceTracking();
        }
    }

    private void RestartFaceTracking()
    {
        foreach (var face in faceManager.trackables)
        {
            Destroy(face.gameObject);
        }

        faceManager.enabled = false;
        faceManager.enabled = true;
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
