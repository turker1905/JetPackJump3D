using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetPackController : MonoBehaviour
{
    [SerializeField] TrailRenderer _trail;
    [SerializeField] Slider _nitroSlider;
    [SerializeField] GameObject _sliderPanel;
    [SerializeField] Rigidbody _playerRigidBody;

    private void Update()
    {
        if (Input.GetMouseButton(0)&&PlayerController._jumpCount>=3)
        {
            _sliderPanel.SetActive(true);
            
            if (_nitroSlider.value > 0)
            {
                _trail.emitting = true;
                _playerRigidBody.AddForce(Vector3.up*5);
                _playerRigidBody.AddForce(Vector3.forward * 5);
                _nitroSlider.value -= 0.4f;
            }
            else
            {
                _trail.emitting = false;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            _trail.emitting = false;
        }
       
       

    }




}
