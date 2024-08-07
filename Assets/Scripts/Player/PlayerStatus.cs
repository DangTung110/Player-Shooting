using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0f;
            Debug.Log("You Die!");
            GameManager.instance.SetStatusButtonOn();
        }
    }
}
