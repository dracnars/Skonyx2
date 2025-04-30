using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject blockingCollider; // À assigner dans l'inspector
    public Vector2 moveAmount = new Vector2(0f, 0f); // Déplacement de la caméra (en unités du monde)
    public float zoomChange = 0f; // Changement de zoom (0 si pas de changement)

    private bool isOpen = false;
    private bool hasSlidCamera = false;

    public void Open()
    {
        if (blockingCollider != null)
        {
            blockingCollider.SetActive(false);
            isOpen = true;
        }
    }

    public void OnPlayerPassed()
    {
        if (!isOpen) return;

        CameraController camController = Camera.main.GetComponent<CameraController>();
        if (camController == null) return;

        if (!hasSlidCamera)
        {
            camController.SlideAndZoom(moveAmount, zoomChange);
            hasSlidCamera = true;
        }
        else
        {
            camController.SlideAndZoom(-moveAmount, -zoomChange);
            hasSlidCamera = false;
        }
    }
}
