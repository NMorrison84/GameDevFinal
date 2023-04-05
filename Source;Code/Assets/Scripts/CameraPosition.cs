using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform player;
    Vector3 behind; //camera moves behind player
    // Start is called before the first frame update
   private void Start()
    {
        behind = transform.position - player.position;
    }

    // Update is called once per frame
  /* private void Update()
    {
        Vector3 cameraM;
        cameraM = player.position + behind;
        cameraM.x = 0;
        transform.position = cameraM;
    }*/
}

