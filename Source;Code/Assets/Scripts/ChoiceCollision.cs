using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceCollision : MonoBehaviour
{
    public Text textComp1;
    public Text textComp2;
    public Rigidbody2D RB;

     public string[] ChoiceLines;
    public float textSpeed ;
    private int index;
   // private int choiceIndex;
    public Button buttonPrefab;

    private bool correct;
    private int health = 100;
    public AudioSource audioCorrect;
    public AudioSource audioWrong;

  

    // Start is called before the first frame update
    void Start()
    {
      textComp1.text = string.Empty;
      textComp2.text = string.Empty;
      //audioCorrect = GetComponent<AudioSource> (); 
      //audioWrong = GetComponent<AudioSource> (); 
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0,-0.05f, 0);
        /*if(Input.GetMouseButtonDown(0)){
            if(textComp.text == ChoiceLines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComp.text = ChoiceLines[index];
        }
    } */
    }
    void OnCollisionEnter2D(Collider2D other)
    {
        
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.CompareTag("Option1")){
        //|| other.gameObject.tag == "Player" ){
        //(other.gameObject.name == "Option1" || other.gameObject.tag == "Player" ){
            Debug.Log("hit somethng");
            Debug.Log("Hit object 1");
            //audioCorrect.Play();
            correct = true;
            //If the GameObject's name matches the one you suggest, output this message in the console
            if(textComp1.text == ChoiceLines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComp1.text = ChoiceLines[index];
            }
            if(textComp2.text == ChoiceLines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComp2.text = ChoiceLines[index];
            }
        }
        else if(other.gameObject.CompareTag("Option")){
            Debug.Log("hit somethng");
            Debug.Log("Hit object 2");
            correct = false;
            if(textComp1.text == ChoiceLines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComp1.text = ChoiceLines[index];
            }
             if(textComp2.text == ChoiceLines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComp2.text = ChoiceLines[index];
            }
        } else{
            Debug.Log("Collision not working");
        }

            if(correct == true){
                Debug.Log(health);
            }else if (correct == false){
                health = health - 10;
                //audioWrong.Play();
                Debug.Log(health);
            }else{
                Debug.Log("Error: Correct test not working");
            }
        }
        
    /* void OnCollisonEnter2D(Collider2D other)
    {
        
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Option1" || other.gameObject.tag == "Player" ){
            Debug.Log("hit somethng");
            Debug.Log("Hit object 1");
            correct = true;
            //If the GameObject's name matches the one you suggest, output this message in the console
            if(textComp.text == ChoiceLines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComp.text = ChoiceLines[index];
            }
        }
        if(other.gameObject.tag != "Option1"){
            correct = false;
            Debug.Log("hit somethng");
            Debug.Log("Hit object 2");
            if(textComp.text == ChoiceLines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComp.text = ChoiceLines[index];
            }
        }

            if(correct == true){
                Debug.Log(health);
            }else if (correct == false){
                health = health - 10;
                Debug.Log(health);
            }else{
                Debug.Log("Error: Correct test not working");
            }
        } */
    
    void StartDialogue(){
       
        index = 0;
      //  choiceIndex = 0;
        StartCoroutine(TypeLine1());
        StartCoroutine(TypeLine2());
    }
    IEnumerator TypeLine1(){
         yield return new WaitForSecondsRealtime(0.4f);
    foreach (char c in ChoiceLines[index].ToCharArray())
    {
        textComp1.text += c;
        yield return new WaitForSeconds(textSpeed);
    }
    }
    IEnumerator TypeLine2(){
    foreach (char c in ChoiceLines[index+1].ToCharArray())
    {
        textComp2.text += c;
        yield return new WaitForSeconds(textSpeed);
    }
      
    }

    void NextLine(){
    if (index < ChoiceLines.Length - 1){
        index++;
        textComp1.text = string.Empty;
        StartCoroutine(TypeLine1());
        //StartCoroutine(TypeLine2());
        
    }else{
    //gameObject.SetActive(false);
   // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    /*ShowButton();
  Button choiceButton = Instantiate(buttonPrefab) as Button;
        Text choiceText = buttonPrefab.GetComponentInChildren<Text>();
            choiceText.text = ChoiceLines[choiceIndex];
            choiceButton.transform.SetParent(this.transform, false);
            Debug.Log(choiceText);
    }*/
    }
    if (index < ChoiceLines.Length - 1){
        index++;
        textComp2.text = string.Empty;
        StartCoroutine(TypeLine2());
    }else{
    
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

