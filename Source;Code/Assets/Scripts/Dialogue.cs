using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    static public int[] IsSceneLocked;
    
    public string[] DialogueLines;
     public string[] ChoiceLines;
    public float textSpeed ;
    private int index;
  //  private int choiceIndex;
    //public Button buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
      textComp.text = string.Empty;
        StartDialogue();
    //SetLock();
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
        if(Input.GetMouseButtonDown(0)){
            if(textComp.text == DialogueLines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComp.text = DialogueLines[index];
            }
        }
       /* if (GameObject.Find("Option1").transform.position == 200)
        {
                Destroy(GameObject);
        } */
    }
        void StartDialogue(){
       
        index = 0;
       // choiceIndex = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine(){
         yield return new WaitForSecondsRealtime(0.5f);
    foreach (char c in DialogueLines[index].ToCharArray())
    {
        textComp.text += c;
        yield return new WaitForSeconds(textSpeed);
    }
      
    }

    void NextLine(){
    if (index < DialogueLines.Length - 1){
        index++;
        textComp.text = string.Empty;
        StartCoroutine(TypeLine());
    }else{

            if(((SceneManager.GetActiveScene().buildIndex) + 1) != 17){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //if next not locked and not game over
            }
                gameObject.SetActive(false);
            /*ShowButton();
          Button choiceButton = Instantiate(buttonPrefab) as Button;
                Text choiceText = buttonPrefab.GetComponentInChildren<Text>();
                    choiceText.text = ChoiceLines[choiceIndex];
                    choiceButton.transform.SetParent(this.transform, false);
                    Debug.Log(choiceText);
            }*/
        }
    }
}
    /*void ShowButton(){
        Button choiceButton = Instantiate(buttonPrefab) as Button;
        Text choiceText = buttonPrefab.GetComponentInChildren<Text>();
            choiceText.text = ChoiceLines[choiceIndex];
            choiceButton.transform.SetParent(this.transform, false);
            Debug.Log(choiceText);
    }*/

