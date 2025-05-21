using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform player;
    public Transform startPoint;
    public Transform endPoint;
    public Slider progressSlider;

    void Update()
    {
        float totalDistance = Vector3.Distance(startPoint.position, endPoint.position);
        float currentDistance = Vector3.Distance(startPoint.position, player.position);
        float progress = Mathf.Clamp01(currentDistance / totalDistance);
        progressSlider.value = progress;
    }
}
