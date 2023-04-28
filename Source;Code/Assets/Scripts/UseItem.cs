using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseItem : MonoBehaviour

{
    public GameObject[] Items;
    static public bool hasItem;
    static public int[] IsSceneLocked;
    
    Vector3 ZeroOutCenter = new Vector3(0,2,0);
    // Start is called before the first frame update
    void Start()
    {
        hasItem = true;
        // SetLock();
    }
/*void SetLock(){
    for(int i = 0; i < IsSceneLocked.Length; i++){
            IsSceneLocked[i] = 0;
        }
        IsSceneLocked[16] = 1;
}*/
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)){
            if(hasItem){
                Items[0].transform.position = ZeroOutCenter;
                Wait(6f);
             //IsSceneLocked[16]= 0; //unlocks scne eafter item use
                  //if(IsSceneLocked[(SceneManager.GetActiveScene().buildIndex) + 1] != 1){
                  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
                  hasItem = false;
               // }
                } //For now we jut have one item with one function. Later this can be changed for more
            }
            }

 private IEnumerator Wait(float dur){
    yield return new WaitForSeconds(dur);
}
    }
