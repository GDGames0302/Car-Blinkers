using GDGames.VehicleControls.Blinkers;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GD_BlinkersImageColorAnimation : MonoBehaviour
{
    Image image;

    [SerializeField]
    Color animatedColor;
    Color initialColor;

    [SerializeField]
    GD_BlinkersType blinkersType;

    static GD_BlinkersManager blinkersManager;


    void Start()
    {
        image = GetComponent<Image>();
        initialColor = image.color;

        if (blinkersManager != null) return;
        blinkersManager = FindObjectOfType<GD_BlinkersManager>();
    }


    public void PlayAnimation()
    {
        StopAllCoroutines();
        image.color = initialColor;

        if (blinkersType == blinkersManager.GetBlinkers.GetCurrentBlinkersType)
        {          
            StartCoroutine(AnimateImage());
        }
    }


    IEnumerator AnimateImage()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(blinkersManager.GetBlinkers.GetBlinkerTime);

        while (true)
        {
            image.color = animatedColor;
            yield return waitForSeconds;
            image.color = initialColor;
            yield return waitForSeconds;
        }
    }
}