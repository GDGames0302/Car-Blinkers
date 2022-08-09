using UnityEngine;

namespace GDGames.VehicleControls.Blinkers
{
    public class GD_BlinkersManager : MonoBehaviour
    {
        [SerializeField]
        GD_Blinkers blinkers;
        public GD_Blinkers GetBlinkers => blinkers;


        void Start()
        {
            blinkers = FindObjectOfType<GD_Blinkers>();
        }


        public void SetBlinkers(GD_Blinkers blinkers)
        {
            this.blinkers = blinkers;
        }


        public void TurnOnBlinkers(GD_BlinkersTypeObject blinkersTypeObject)
        {
            if (blinkersTypeObject.blinkersType == blinkers.GetCurrentBlinkersType)
            {
                blinkers.SetBlinkers(GD_BlinkersType.None);
            }
            else
            {
                blinkers.SetBlinkers(blinkersTypeObject.blinkersType);
            }
        }
    }
}