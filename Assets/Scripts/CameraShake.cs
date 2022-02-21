    using UnityEngine;
    using Cinemachine;
     
    //Sources
    //Cinemachine boilerplate: https://forum.unity.com/threads/how-to-simulate-head-bob-with-cinemachine-without-a-noise.519203/
    //Bobbing info: https://codyburleson.com/blog/unity-recipes-head-bob-or-breathe
    public class CameraShake : CinemachineExtension
    {
        [Tooltip("Amplitude of the shake")]
        public float m_Range = 10f;
        public float period = 5f;
     
        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                Vector3 shakeAmount = GetOffset();
                //Debug.Log("Offset:" + shakeAmount.ToString());
                state.PositionCorrection += shakeAmount;
            }
        }
     
        Vector3 GetOffset()
        {
            float theta = Time.timeSinceLevelLoad / period;
            float distance = m_Range * Mathf.Sin(theta);
            return Vector3.up * distance;
        }
    }
     
