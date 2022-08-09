using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GDGames.VehicleControls.Blinkers
{
    public class GD_Blinkers : MonoBehaviour
    {
        [SerializeField]
        float blinkerTime = 0.3f;
        public float GetBlinkerTime => blinkerTime;

        [Space]

        [SerializeField]
        Blinker[] blinkers;

        [Space]

        GD_BlinkersType currentBlinkersType = GD_BlinkersType.None;
        public GD_BlinkersType GetCurrentBlinkersType => currentBlinkersType;

        [HideInInspector]
        public UnityEvent BlinkersSetEvent;

        int currentBlinkersIndex;
        WaitForSeconds waitForSeconds = new WaitForSeconds(0);


        void Start()
        {
            waitForSeconds = new WaitForSeconds(blinkerTime);
        }


        public void SetBlinkers(GD_BlinkersType blinkersType)
        {
            blinkers[currentBlinkersIndex].TurnOffEvent?.Invoke();
            blinkers[currentBlinkersIndex].BlinkOffEvent?.Invoke();
            StopAllCoroutines();

            currentBlinkersType = blinkersType;
            for (int i = 0; i < blinkers.Length; i++)
            {
                if (blinkers[i].blinkersType == currentBlinkersType)
                {
                    currentBlinkersIndex = i;
                    blinkers[currentBlinkersIndex].TurnOnEvent?.Invoke();
                    StartCoroutine(BlinkCurrentBlinkers());
                    break;
                }
            }
        }


        IEnumerator BlinkCurrentBlinkers()
        {
            while (true)
            {
                blinkers[currentBlinkersIndex].BlinkOnEvent?.Invoke();
                yield return waitForSeconds;
                blinkers[currentBlinkersIndex].BlinkOffEvent?.Invoke();
                yield return waitForSeconds;
            }
        }



        [System.Serializable]
        public class Blinker
        {
            public GD_BlinkersType blinkersType;

            [Space]

            public UnityEvent TurnOnEvent;
            public UnityEvent TurnOffEvent;

            [Space]

            public UnityEvent BlinkOnEvent;
            public UnityEvent BlinkOffEvent;
        }
    }
}