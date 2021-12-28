using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vuforia
{
    public class CameraSetting : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var vuforia = VuforiaARController.Instance;
            vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
            vuforia.RegisterOnPauseCallback(OnPause);
        }

        // Update is called once per frame
        void Update()
        {

        }
         private void OnVuforiaStarted()
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_MACRO);
        }
        private void OnPause(bool isPause)
        {

        }

        public void FocusModeClick()
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
        }

        //public void SwitchCameraDirection(CameraDevice.CameraDirection direction)
        //{
        //    CameraDevice.Instance.Stop();
        //    CameraDevice.Instance.Deinit();

        //    CameraDevice.Instance.Init(direction);
        //    CameraDevice.Instance.Start();
        //}

        public void FlashTourch(bool ON)
        {
            CameraDevice.Instance.SetFlashTorchMode(ON);
        }
    }
}

