using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _StartCam1, _gamCam2;

    private void Awake()
    {
        _StartCam1.SetActive(true);
        _gamCam2.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _StartCam1.SetActive(false);
            _gamCam2.SetActive(true);
        }
    }

}
