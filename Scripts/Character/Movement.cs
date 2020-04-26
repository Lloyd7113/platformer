using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    public SpriteRenderer renderer;
    public Sprite jumpingSprite;
    public Sprite normalSprite;
    public Sprite leftFacingSprite;
    public Sprite leftJumpingSprite;
    public Sprite rightWalk;
    public Sprite leftWalk;
    public Sprite centreWalk;
    public Sprite centreWalkLeft;
    public GameObject Camera;
    public float xOffset = 0f;

    AudioSource audioData;
    public float speed = 0.05f;
    public float jumpHeight = 4f;
    public float jumpSpeed = 0.15f;
    public bool jumping = false;
    public bool comingDown = true;
    public bool leftFacing = false;
    int walkIndex = 0;

    Vector3 jumpStart = new Vector3(0, 0, 0);

    public float xChange = 0f;
    public float yChange = 0f;
    Vector2 startScale = new Vector2();

    // Start is called before the first frame update
    void Start(){
        startScale = transform.localScale;
        Camera = GameObject.Find("Camera");
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){

        PlayerPrefs.SetString("Scene", SceneManager.GetActiveScene().name);

        Vector2 scale = transform.localScale;

        if (Input.GetKey(KeyCode.D)){
            walkIndex++;
            leftFacing = false;

            if (walkIndex == 30){
                walkIndex = 0;
                gameObject.GetComponent<SpriteRenderer>().sprite = rightWalk;
            }else if (walkIndex >= 20){
                gameObject.GetComponent<SpriteRenderer>().sprite = rightWalk;
            }else if (walkIndex >= 10){
                gameObject.GetComponent<SpriteRenderer>().sprite = centreWalk;
            }else if (walkIndex > 0){
                gameObject.GetComponent<SpriteRenderer>().sprite = rightWalk;
            }

            xChange += speed;
        }
        
        if (Input.GetKey(KeyCode.A)){
            walkIndex++;
            leftFacing = true;

            if (walkIndex == 30){
                walkIndex = 0;
                gameObject.GetComponent<SpriteRenderer>().sprite = leftWalk;
            }else if (walkIndex >= 20){
                gameObject.GetComponent<SpriteRenderer>().sprite = leftWalk;
            }else if (walkIndex >= 10){
                gameObject.GetComponent<SpriteRenderer>().sprite = centreWalkLeft;
            }else if (walkIndex > 0){
                gameObject.GetComponent<SpriteRenderer>().sprite = leftWalk;
            }

            xChange -= speed;
        }
        
        if (Input.GetKey(KeyCode.Space)){
            if (!jumping && !comingDown){
                jumpStart = transform.position;
                jumping = true;
                comingDown = true;
                audioData = GetComponent<AudioSource>();
                audioData.Play(0);

                if (leftFacing){
                    gameObject.GetComponent<SpriteRenderer>().sprite = leftJumpingSprite;
                }else{
                    gameObject.GetComponent<SpriteRenderer>().sprite = jumpingSprite;
                }

            }else{
               if (transform.position.y < jumpStart.y + jumpHeight && jumping){
                   if (leftFacing){
                        gameObject.GetComponent<SpriteRenderer>().sprite = leftJumpingSprite;
                    }else{
                        gameObject.GetComponent<SpriteRenderer>().sprite = jumpingSprite;
                    }
                   yChange += jumpSpeed;
                   Debug.Log(transform.position.y);
               }else{
                   jumping = false;
               }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)){
            jumping = false;
        }

        transform.position += new Vector3(xChange, yChange, 0);
        xOffset += xChange;

        xChange = 0f;
        yChange = 0f;

        if (xOffset > 1){
            Camera.transform.position += new Vector3(xChange, 0, 0);
        }

    }

    void OnCollisionEnter2D(Collision2D collision){
        comingDown = false;
        if (leftFacing){
            gameObject.GetComponent<SpriteRenderer>().sprite = leftFacingSprite;
        }else{
            gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
        }

        if (collision.gameObject.name == "death" || collision.gameObject.tag == "enemy"){
            SceneManager.LoadScene("Dead", LoadSceneMode.Single);
        }
        if (collision.gameObject.tag == "superjump"){
            jumpSpeed = 0.3f;
            jumpHeight = 8;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "portal1"){
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal2"){
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal3"){
            SceneManager.LoadScene("Level4", LoadSceneMode.Single);
        }else if (collision.gameObject.name == "portal4"){
            SceneManager.LoadScene("Level5", LoadSceneMode.Single);
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        comingDown = true;
    }
}
