using UnityEngine;
using System.Collections;
using Vuforia;

public class WebCamSetUP : MonoBehaviour
{
    private Image.PIXEL_FORMAT pixelFormat = Image.PIXEL_FORMAT.GRAYSCALE;
    private bool registeredFormat = false;

    void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            registeredFormat = false;
        }
    }
    
    void Update()
    {
        if (!registeredFormat)
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
            
			/*
			pixelFormat = Image.PIXEL_FORMAT.GRAYSCALE;

            CameraDevice.Instance.Stop();
            CameraDevice.Instance.SetFrameFormat(this.pixelFormat, false);
            CameraDevice.Instance.SetFrameFormat(this.pixelFormat, true);
            CameraDevice.Instance.Start();*

           // registeredFormat = CameraDevice.Instance.SetFrameFormat(pixelFormat, true);

 /*           CameraDevice.Instance.SetFrameFormat(pixelFormat, false);
            registeredFormat = CameraDevice.Instance.SetFrameFormat(pixelFormat, true);
            if (!registeredFormat)
            {
                pixelFormat = Image.PIXEL_FORMAT.YUV;
                registeredFormat = CameraDevice.Instance.SetFrameFormat(pixelFormat, true);
            }
            if (!registeredFormat)
            {
                pixelFormat = Image.PIXEL_FORMAT.RGB565;
                registeredFormat = CameraDevice.Instance.SetFrameFormat(pixelFormat, true);
            }
            if (!registeredFormat)
            {
                pixelFormat = Image.PIXEL_FORMAT.RGB888;
                registeredFormat = CameraDevice.Instance.SetFrameFormat(pixelFormat, true);
            }
            if (!registeredFormat)
            {
                pixelFormat = Image.PIXEL_FORMAT.RGBA8888;
                registeredFormat = CameraDevice.Instance.SetFrameFormat(pixelFormat, true);
            }
            if (!registeredFormat)
            {
                pixelFormat = Image.PIXEL_FORMAT.GRAYSCALE;
                registeredFormat = CameraDevice.Instance.SetFrameFormat(pixelFormat, true);
            }
            if (!registeredFormat)
            {
                pixelFormat = Image.PIXEL_FORMAT.UNKNOWN_FORMAT;
            }*/
            registeredFormat = true;
        }
    }

    public bool GetFormat(ref Image.PIXEL_FORMAT format)
    {
        if (!registeredFormat)
            return false;
        format = pixelFormat;
        return true;
    }
}
