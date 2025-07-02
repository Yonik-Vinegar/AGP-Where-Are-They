using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CorridorAnimation : MonoBehaviour
{
    public GameObject PlayerPosition;
    public CinemachineVirtualCamera Camera;
    public Transform target;
    public GameObject Player;
    private Color asda;
    public bool IsforRobot;

    private void Start()
    {
         asda = new Color(0.3396226f, 0.08810965f, 0.08810965f, 1f);
         
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (IsforRobot == false)
            {
                CorridorAnim();
            }
        }

        if (other.gameObject.tag == "Robot")
        {
            if (IsforRobot == true)
            {
                NonCorridorAnimation();
            }
        }
    }

    private void CorridorAnim()
    {
        Player.transform.position = PlayerPosition.transform.position;
        RenderSettings.fogColor = Color.black;
        Camera.LookAt = target;
    }
                                
    private void NonCorridorAnimation()
    {
        Debug.Log("Noncorridor");
        RenderSettings.fogColor = asda;
        Camera.LookAt = null;
    }
}
