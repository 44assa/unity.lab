using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    public GameObject _go;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void StartButton()
    {
        _rb.useGravity = true;
        _go.SetActive(true);
    }

    public void StopButton()
    {
        _rb.useGravity = false;
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    public void ChangeColorButton()
    {
        _rb.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}