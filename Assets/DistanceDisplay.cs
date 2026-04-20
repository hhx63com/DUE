using UnityEngine;
using UnityEngine.UI;

public class DistanceDisplay : MonoBehaviour
{
    public PlayerController playerController;
    public Text distanceText;
    
    void Update()
    {
        if (playerController != null && distanceText != null)
        {
            float distance = playerController.GetTotalDistance();
            distanceText.text = "Total Distance: " + distance.ToString("F2") + " units";
        }
    }
}