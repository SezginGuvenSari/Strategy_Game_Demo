using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    #region References

    private Camera _cam;

    #endregion


    #region OnEnable && OnDisable

    private void OnEnable()
    {
        GameEvents.OnGetCameraSettings += SetCameraPosition;
        GameEvents.OnGetCameraSettings += SetCamSize;
    }
    private void OnDisable()
    {
        GameEvents.OnGetCameraSettings -= SetCameraPosition;
        GameEvents.OnGetCameraSettings -= SetCamSize;
    }

    #endregion

    private void Start() => _cam = GetComponent<Camera>();

    private void SetCameraPosition(int width, int height, float tileSize )
    {
        _cam.transform.position = new Vector3((float)(width * tileSize) / 2 - tileSize / 2,
            (float)(height * tileSize) / 2 - tileSize / 2, -10f);
    }
    private void SetCamSize(int width, int height, float tileSize) => _cam.GetComponent<Camera>().orthographicSize = (width * tileSize) / 2;
}
