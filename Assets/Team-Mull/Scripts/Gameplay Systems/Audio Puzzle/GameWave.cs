using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.AudioPuzzle
{

    [RequireComponent(typeof(LineRenderer))]
    public class GameWave : MonoBehaviour
    {
        public int pointsCount = 100;
        [SerializeField] private float amplitude = 1f;
        [SerializeField] private float frequency = 1f;
        public float waveLength = 1f;

        private LineRenderer lineRenderer;

        [SerializeField] private Vector3 startPosition;
        [SerializeField] private Vector3 lastPosition;

        public float Amplitude => amplitude;
        public float Frequency => frequency;

        [SerializeField]
        [Tooltip("Check this if its going to be an answer/reference wave")]
        private bool isReference = false;

        private float timeOffset;

        private float waveSpeed = 1f;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = pointsCount;

            startPosition = transform.position;

            DrawSineWave();
        }

        void Update()
        {
            //Do not spam update if its a reference wave
            //if (isReference)
            //{
            //    timeOffset += Time.deltaTime;
            //}
            //else
            //{
            //    timeOffset = 0f;
            //}

            //startPosition.x += waveSpeed * Time.deltaTime;

            DrawSineWave();
        }

        public void DrawSineWave()
        {
            for (int i = 0; i < pointsCount; i++)
            {
                float x = startPosition.x + i * waveLength / pointsCount;
                float y = startPosition.y + amplitude * Mathf.Sin(frequency * x);

                //if (isReference)
                //{
                //    if(x - timeOffset < startPosition.x)
                //    {
                //        x = lastPosition.x - timeOffset;
                //    }
                //    else
                //    {
                //        x -= timeOffset;
                //    }
                //}

                lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            }
        }

        public void SetAmplitude(float _amplitude)
        {
            amplitude = _amplitude;
        }

        public void SetFrequency(float _frequency)
        {
            frequency = _frequency;
        }

        public void OnUpdateMeasurement(AudioMeasurements _type, float _amount)
        {
            switch(_type)
            {
                case AudioMeasurements.FREQUENCY:
                    SetFrequency(_amount);
                    break;

                case AudioMeasurements.AMPLITUDE:
                    SetAmplitude(_amount);
                    break;
            }
        }
    }
}
