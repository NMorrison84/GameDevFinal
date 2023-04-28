using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;
    private List<Transform>pieces;
    private int completed = 0;
private bool shuffling = false;
    private int emptyLocation;
    private int size;
    // Start is called before the first frame update
    private void CreateGamePieces(float gap){
        float width = 1 / (float) size;
        for (int row = 0; row < size; row++){
            for (int col = 0; col < size; col++){
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);
                piece.localPosition = new Vector3((-1 + (2 *width*col)+width), (+1 + (2*width*row)+width), 0);
                piece.localScale = ((2* width) - gap) * Vector3.one;
                piece.name = $"{(row * size) + col}";
                if((row == size - 1) && (col ==size - 1)){
                    emptyLocation = (size * size) -1;
                    piece.gameObject.SetActive(false);
                } else{
                    float gap1 = gap / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv  = new Vector2[4];
                    uv[0] = new Vector2((width * col)+ gap1, (1- ((width * (row +1)) - gap1)));
                    uv[1] = new Vector2((width * (col + 1)- gap1), (1- ((width * (row +1)) - gap1)));
                    uv[2] = new Vector2((width * col)+ gap1, (1- ((width * (row)) + gap1)));
                    uv[3] = new Vector2((width * (col + 1)- gap1), (1- ((width * (row)) + gap1)));
                    mesh.uv = uv;
                }
            }
        }
    }
    void Start()
    {
        pieces = new List<Transform>();
        size = 2; //size by size grid
        CreateGamePieces(0.01f);
        completed = 0;
        if(!shuffling && CheckCompletion()){
            shuffling = true;
            StartCoroutine(WaitShuffle(1f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit){
                for (int i = 0; i <pieces.Count; i++){
                    if(pieces[i] == hit.transform){
                        if(SwapIfValid(i, -size, size)) { break;}
                        if(SwapIfValid(i, +size, size)) { break;}
                        if(SwapIfValid(i, -1, 0)) { break;}
                        if(SwapIfValid(i, +1, size-1)) { break;}
                    }
                }
            }
            if(CheckCompletion() && completed == 1){
                Debug.Log("completed");
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }

    private bool SwapIfValid(int i, int offset, int colCheck){
        if (((i % size) != colCheck) && ((i + offset) == emptyLocation)){
            (pieces[i], pieces[i+offset]) = (pieces[i + offset] , pieces[i]);
            (pieces[i].localPosition, pieces[i+offset].localPosition) = (pieces[i + offset].localPosition , pieces[i].localPosition);
            emptyLocation = i;
            return true;
        }
        return false;
        }
    
    private bool CheckCompletion(){
        for (int i =0; i<pieces.Count; i++){
            if(pieces[i].name != $"{i}"){
                return false;
            }
        }
        completed = 1;
        return true;
        //completed = 1;
    }
private IEnumerator WaitShuffle(float dur){
    yield return new WaitForSeconds(dur);
    Shuffle();
    shuffling = false;
}
private void Shuffle(){
    int count = 0;
    int last = 0;
    while (count < (size*size*size)){
        int rnd = Random.Range(0, size * size);
        if(rnd == last){continue;}
        last = emptyLocation;
        if(SwapIfValid(rnd, -size, size)){
            count++;
        } else if(SwapIfValid(rnd, +size, size)){
            count++;
        }else if(SwapIfValid(rnd, -1, 0)){
            count++;
        }else if(SwapIfValid(rnd, +1, size - 1)){
            count++;
    }else{
        Debug.Log("Shuffle not working");
    }
}
}

}