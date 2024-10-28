using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.Gameplay.AudioPuzzle
{

    [RequireComponent(typeof(LineRenderer))]
    public class GameWave : MonoBehaviour
    {
        public int pointsCount = 100;
        public float amplitude = 1f;
        public float frequency = 1f;
        public float waveLength = 1f;

        private LineRenderer lineRenderer;

        [SerializeField] private Vector3 startPosition;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = pointsCount;

            startPosition = transform.position;

            DrawSineWave();
        }

        void Update()
        {
            DrawSineWave();
        }

        public void DrawSineWave()
        {
            for (int i = 0; i < pointsCount; i++)
            {
                float x = startPosition.x + i * waveLength / pointsCount;
                float y = amplitude * Mathf.Sin(frequency * x);
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
