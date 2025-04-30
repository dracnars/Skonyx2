using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float slideDuration = 1f;
    public float zoomDuration = 1f;

    private Coroutine slideCoroutine;
    private Coroutine zoomCoroutine;

    public void Slide(Vector2 movement)
    {
        if (slideCoroutine != null) StopCoroutine(slideCoroutine);
        slideCoroutine = StartCoroutine(SlideCoroutine(movement));
    }

    private IEnumerator SlideCoroutine(Vector2 movement)
    {
        Vector3 start = transform.position;
        Vector3 end = start + (Vector3)movement;
        float elapsed = 0f;

        while (elapsed < slideDuration)
        {
            transform.position = Vector3.Lerp(start, end, elapsed / slideDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = end;
    }

    public void Zoom(float targetSize)
    {
        if (zoomCoroutine != null) StopCoroutine(zoomCoroutine);
        zoomCoroutine = StartCoroutine(ZoomCoroutine(targetSize));
    }

    private IEnumerator ZoomCoroutine(float targetSize)
    {
        Camera cam = Camera.main;
        if (cam == null) yield break;

        float startSize = cam.orthographicSize;
        float elapsed = 0f;

        while (elapsed < zoomDuration)
        {
            cam.orthographicSize = Mathf.Lerp(startSize, targetSize, elapsed / zoomDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cam.orthographicSize = targetSize;
    }

    public void SlideAndZoom(Vector2 movement, float zoomChange)
    {
        if (movement != Vector2.zero)
            Slide(movement);

        if (zoomChange != 0f)
        {
            Camera cam = Camera.main;
            if (cam != null)
            {
                float targetSize = cam.orthographicSize + zoomChange;
                Zoom(targetSize);
            }
        }
    }
}
