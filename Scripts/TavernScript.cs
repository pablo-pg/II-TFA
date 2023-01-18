using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernScript : MonoBehaviour
{
    public GameObject ball;
    SphereCollider ballCollider;  // Para no volar al mirar hacia abajo
    public Transform cam;

    bool holdingBall = false;
    Rigidbody ballRB;

    // Para coger la bola
    bool isPickableBall = false;
    public TavernCanvasController canvasScript;
    public LayerMask pickableLayer;
    RaycastHit hit;


    private string sceneName = "Scene";

    // Start is called before the first frame update
    void Start()
    {
        ballRB = ball.GetComponent<Rigidbody>();
        ballCollider = ball.GetComponent<SphereCollider>();
        ballRB.useGravity = false;
        canvasScript.hideCursor(false);
        //canvasScript.EnableSlider(false);
        ballCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBall == false) {
            if(Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, pickableLayer)) {
                if (isPickableBall == false) {
                    isPickableBall = true;
                    canvasScript.changePickableBallColor(true);
                }
                if (isPickableBall && Input.GetKeyDown(KeyCode.E)) {
                    SceneManager.LoadScene(2);
                }
            } else if(isPickableBall) {
                isPickableBall = false;
                canvasScript.changePickableBallColor(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
    }

    // Para saber en que escena estabamos
    private void SaveData(){
        PlayerPrefs.SetInt(sceneName, 1);
    }

    private void OnDestroy() {
        SaveData();
    }
}
