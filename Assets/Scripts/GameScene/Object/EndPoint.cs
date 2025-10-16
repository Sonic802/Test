using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0;
            //Ê¤Àû½çÃæ
            WinPanel.Instance.ShowMe();
        }
    }
}
