using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CorridorAnimation : MonoBehaviour
{
    public GameObject PlayerPosition;
    public CinemachineVirtualCamera Camera;
    public Transform target;
    public float FogDensityValue;
    public GameObject Player;
    private Color asda;

    private void Start()
    {
        Color asda = new Color(0.3396226f, 0.08810965f, 08810965f, 1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CorridorAnim();
        }

        if (other.gameObject.tag == "Robot")
        {
            NonCorridorAnimation();
        }
    }

    private void CorridorAnim()
    {
        Player.transform.position = PlayerPosition.transform.position;
        RenderSettings.fogColor = Color.black;
        RenderSettings.fogDensity = FogDensityValue;
        Camera.LookAt = target;
    }

    private void NonCorridorAnimation()
    {
        RenderSettings.fogColor = asda;
        RenderSettings.fogDensity = 0.1f;
        Camera.LookAt = null;
    }
}
