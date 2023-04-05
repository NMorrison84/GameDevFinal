using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleDialogue : MonoBehaviour
{
    public Text ChoiceText1;
    public Text ChoiceText2;
    public TextMeshProUGUI DialogueText;

    public TextMeshProUGUI HealthBox;
    //public TextMeshPro DialogueText;
    public Rigidbody2D RB;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject player;
     public string[] DialogueLines;
     public string[] ChoiceLines1;
     public string[] ChoiceLines2;
    public float textSpeed ;

    public Vector3 position1;
    public Vector3 position2;
    public float positionPicker;


    private int index;
   // private int choiceIndex;
   // public Button buttonPrefab;

    private bool correct;
    static public int health = 100;
    public AudioSource audioCorrect;
    public AudioSource audioWrong;


    Dialogue dialogue;
  

    // Start is called before the first frame update
    void Start()
    {
      ChoiceText1.text = string.Empty;
      ChoiceText2.text = string.Empty;
      DialogueText.text = string.Empty;
      HealthBox.text = "Health: " + health;
      //audioCorrect = GetComponent<AudioSource> (); 
      //audioWrong = GetComponent<AudioSource> (); 
        RandomizeChoices();
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        choice1.transform.Translate(0,-0.025f, 0);
        choice2.transform.Translate(0,-0.025f, 0);
        if(ChoiceLines1[index].Length >= 10){
            ChoiceText1.fontSize = 12;
        } else{
            ChoiceText1.fontSize = 16;
        }
if(ChoiceLines2[index].Length >= 10){
            ChoiceText2.fontSize = 12;
        } else{
            ChoiceText2.fontSize = 16;
        }
        /*if(Input.GetMouseButtonDown(0)){
            if(textComp.text == ChoiceLines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComp.text = ChoiceLines[index];
        }
    } */
    }

    void RandomizeChoices(){ 
//Should randomize position so that the correct choice is not always in the same spot
    position1 = new Vector3(-10, 4, 0);
    position2 = new Vector3(14, 4, 0);
    positionPicker = Random.Range(0f, 10f);
    Debug.Log(positionPicker); // 0 to 3.99
    if (positionPicker <= 5f){
        choice1.transform.position = position1;
        choice2.transform.position = position2;
    } else if (positionPicker > 5f){
        choice1.transform.position = position2;
        choice2.transform.position = position1;
    }else{
      Debug.Log("RandomChoices not working");  
    }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       // IEnumerator Collision(){
        correct = true;
        
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.CompareTag("Option1")){
        //(other.gameObject.name == "Option1" || other.gameObject.tag == "Player" ){
            Debug.Log("hit somethng");
            Debug.Log("Hit object 1");
            //audioCorrect.Play();
            correct = true;
            //If the GameObject's name matches the one you suggest, output this message in the console
            //Destroy(gameObject);
            if(ChoiceText1.text == ChoiceLines1[index]){
                NextLine();
            }else{
                Debug.Log("Text not working");
                StopAllCoroutines();
                ChoiceText1.text = ChoiceLines1[index];
            }
            
            choice1.SetActive(false);
            choice2.SetActive(false);
            //yield return new WaitForSecondsRealtime(0.8f);
             RandomizeChoices();
             choice1.SetActive(true);
            choice2.SetActive(true);
        }    
        else if(other.gameObject.CompareTag("Option")){
            Debug.Log("hit somethng");
            Debug.Log("Hit object 2");
            correct = false;
           DialogueText.text = "No, that's wrong!";
            choice1.SetActive(false);
            choice2.SetActive(false);
            RandomizeChoices();
            choice1.SetActive(true);
            choice2.SetActive(true);
            
            //Destroy(gameObject);
        } else{
            Debug.Log("Collision not working");
        }
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(0, -9, 0);
            if(correct == true){
                Debug.Log(health);
                HealthBox.text = "Health: " + health;
            }else if (correct == false){
                health = health - 10;
                //audioWrong.Play();
                Debug.Log(health);
                HealthBox.text = "Health: " + health;
            }else{
                Debug.Log("Error: Correct test not working");
            }

            if (health <= 0){
                Debug.Log("GAME OVER");
                Debug.Log(health);
                HealthBox.text = "Health: " + health;
            }
        //}
        }
        
     /*void OnCollisonEnter2D(Collider2D other)
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
        }*/
    
    void StartDialogue(){
       
        index = 0;
      //  choiceIndex = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine(){
         yield return new WaitForSecondsRealtime(0.5f);
    foreach (char c in ChoiceLines1[index].ToCharArray())
    {
        ChoiceText1.text += c;
        yield return new WaitForSeconds(textSpeed);
    }
    foreach (char c in ChoiceLines2[index].ToCharArray())
    {
        ChoiceText2.text += c;
        yield return new WaitForSeconds(textSpeed);
    }
      foreach (char c in DialogueLines[index].ToCharArray())
    {
        DialogueText.text += c;
        yield return new WaitForSeconds(textSpeed);
    }
    }

    void NextLine(){
    if (index < ChoiceLines1.Length - 1){
        index++;
        ChoiceText1.text = string.Empty;
        ChoiceText2.text = string.Empty;
        DialogueText.text = string.Empty;
        StartCoroutine(TypeLine());
    }else if(index >= DialogueLines.Length - 1){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   else{
    Debug.Log("NextLine not working");
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

