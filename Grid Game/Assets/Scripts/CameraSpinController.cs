using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpinController : MonoBehaviour
{
    public void SpinCamera()
    {
        //transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + 180f);
        transform.DORotate(new Vector3(0f, 0f, transform.rotation.eulerAngles.z + 180f), 2f).SetEase(Ease.InOutQuart);
    }
}
