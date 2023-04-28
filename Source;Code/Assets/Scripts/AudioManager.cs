using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null){
            Destroy (gameObject);

        }else{
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
