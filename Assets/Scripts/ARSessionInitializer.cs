using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionInitializer : MonoBehaviour
{
    private ARSession arSession;
    public GameObject initialPanel; 

    void Start()
    {
        arSession = FindObjectOfType<ARSession>();
        arSession.enabled = false;
        if (initialPanel != null)
        {
            initialPanel.SetActive(true); 
        }
    }

    public void StartARSession()
    {
        arSession.enabled = true;
        if (initialPanel != null)
        {
            initialPanel.SetActive(false); 
        }
    }
}
