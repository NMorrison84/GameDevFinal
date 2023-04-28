using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SirenBattle : MonoBehaviour
{
   // public TextMeshProUGUI HealthText;
     public TextMeshProUGUI DialogueText;
      public TextMeshProUGUI ProgressText;
     public string[] DialogueLines;
     
     public Sprite[] KeyArray;
     public GameObject MashText;

     public GameObject KeyGO;
     public GameObject ProgressTextGO;

    static public int health = 100;
    // private int index;
     public float textSpeed ;
     public SpriteRenderer keySprite;
     bool isResisted;

     public float delay = 1f;
     bool press;
     float mash;
bool started;
static int key;
int mashSuccess = 0;
    
    // Start is called before the first frame update
    void Start()
    {
      KeyGO.SetActive(false);
      MashText.SetActive(false);
      ProgressText.text = string.Empty;
      ProgressTextGO.SetActive(false);
      
     // HealthText.text = "Health: " + health;  
      mash = delay;
      //index = 0;
      StartCoroutine(TypeLine());
 
    }
void RandomizeKey(){
key = (Random.Range(0, 3));
//Debug.Log(key);
}
void MashBattle(){
    started = true;
}
     // end of function
    // Update is called once per frame
    void Update()
    {
        if (started == true){
        RandomizeKey();
    started = true;
   // while(started){
    mash -= Time.deltaTime;
    //}
    Debug.Log("key" + key);
//while(mash < 10f){
    switch(key) 
{
  case 0:
     keySprite.sprite = KeyArray[0];
     KeyGO.SetActive(true);
     MashText.SetActive(true);
     ProgressTextGO.SetActive(true);
     ProgressText.text = mash + " /10";
     if(Input.GetKeyDown(KeyCode.Q)){
        mash += 0.7f;
        ProgressText.text = mash + " /10";
        Debug.Log("Mash" + mash);
     }
    break;
  case 1:
    keySprite.sprite = KeyArray[1];
     KeyGO.SetActive(true);
     MashText.SetActive(true);
     ProgressTextGO.SetActive(true);
     ProgressText.text = mash + " /10";
    if(Input.GetKeyDown(KeyCode.V)){
        mash += 0.7f;
        ProgressText.text = mash + " /10";
        Debug.Log("Mash" + mash);
     }
    break;
  case 2:
    keySprite.sprite = KeyArray[2];
     KeyGO.SetActive(true);
     MashText.SetActive(true);
     ProgressTextGO.SetActive(true);
     ProgressText.text = mash + " /10";
    if(Input.GetKeyDown(KeyCode.Z)){
        mash += 0.7f;
        ProgressText.text = mash + " /10";
        Debug.Log("Mash" + mash);
     }
    break;
  default:
    Debug.Log(key);
    Debug.Log("Switch statement not working");
    break;
  
}
if(mash <=0f){
    SceneManager.LoadScene(14);
    //break;
}
if (mash >= 10f){
    foreach (char c in  DialogueLines[2].ToCharArray())
    {
        DialogueText.text += c;
    }
    mashSuccess++;
    started = false;
    if (mashSuccess >= 3){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}else{
    
    TypeLine();
            } //end of else
        } //end of if
    //} //end of while
    started = false;
}
    }
    IEnumerator TypeLine(){
         yield return new WaitForSecondsRealtime(0.5f);
        foreach (char c in  DialogueLines[0].ToCharArray())
    {
        DialogueText.text += c;
        yield return new WaitForSeconds(textSpeed);
    }
    yield return new WaitForSecondsRealtime(Random.Range(0f, 3f));
    foreach (char c in  DialogueLines[1].ToCharArray());
    MashBattle();
    }
}
