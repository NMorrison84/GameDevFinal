using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nathan Morrison cvw919
public class PlayerMotion : MonoBehaviour
{

    public float speed = 20;
    //public float movement = speed * Time.fixedDeltaTime;
     public Rigidbody2D RB; //Player physics
     float horizonatalInp;
     float verticalInp; 
    // Start is called before the first frame update
    // Update is called once per frame
    private void FixedUpdate(){
        horizonatalInp = Input.GetAxis("Horizontal");
        verticalInp = Input.GetAxis("Vertical");
        /*float movement = speed * Time.fixedDeltaTime;
        Vector2 verticalM = transform.up * verticalInp * movement * 3f;
        //M stands for movement
        Vector2 horizontalM = transform.right * horizonatalInp * movement * 3f;
        RB.MovePosition(RB.position + verticalM + horizontalM); */
        Vector3 Movement = new Vector3(horizonatalInp, verticalInp)* speed * Time.fixedDeltaTime;
        RB.MovePosition(transform.position + Movement);
       // Debug.Log(Movement);
    }

    private void Update()
    {
       
       //FixedUpdate();
       //Horizontal string automatically takes arrow keys and 'a' and 'd'. Easy :D

    }
    
}
