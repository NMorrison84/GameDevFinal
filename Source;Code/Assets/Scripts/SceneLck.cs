using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLck : MonoBehaviour
{
     public string[] IsSceneLocked;
    // Start is called before the first frame update
    void Start()
    {
         for(int i = 0; i < IsSceneLocked.Length; i++){
            IsSceneLocked[i] = "0";
        }
        IsSceneLocked[15] = "1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
