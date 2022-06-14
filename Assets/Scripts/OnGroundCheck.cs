using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundCheck : MonoBehaviour
{
    [SerializeField] bool _isOnGround=true;
    [SerializeField] float _maxDistance;
    public static bool IsOnGround;
    [SerializeField] Transform _raycast;

    private void Update()
    {
        CheckFootOnGround(_raycast);

        IsOnGround = _isOnGround;
        

        
    }

    void CheckFootOnGround(Transform rayCastTransform)
    {
        Ray Hitt = new Ray(rayCastTransform.position,rayCastTransform.TransformDirection(-rayCastTransform.up*_maxDistance));
        Debug.DrawRay(rayCastTransform.position, rayCastTransform.TransformDirection(-rayCastTransform.up * _maxDistance),Color.red);

        if (Physics.Raycast(Hitt,out RaycastHit hit,_maxDistance))
        {
            _isOnGround = true;
        }
        else
        {
            _isOnGround = false;
        }

    }






}
