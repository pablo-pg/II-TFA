using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThowBall : MonoBehaviour
{
    public GameObject ball;
    SphereCollider ballCollider;  // Para no volar al mirar hacia abajo
    public Transform cam;
    public float ballDistance = 2f;

    public float ballForceMin = 150f;
    public float ballForceMax = 500f;
    public float ballForce;
    public float totalTimer = 2f;  // Tiempo maximo cargando
    float currentTime  =  0.0f;

    bool holdingBall = true;
    Rigidbody ballRB;

    // Para coger la bola
    bool isPickableBall = false;
    public CanvasController canvasScript;
    public LayerMask pickableLayer;
    RaycastHit hit;

    TrailRenderer ballTrail;

    private string sceneName = "Scene";

    // Start is called before the first frame update
    void Start()
    {
        ballRB = ball.GetComponent<Rigidbody>();
        ballCollider = ball.GetComponent<SphereCollider>();
        ballTrail = ball.GetComponent<TrailRenderer>();
        ballTrail.enabled = false;
        ballRB.useGravity = false;
        canvasScript.hideCursor(true);
        canvasScript.EnableSlider(false);
        ballCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if  (holdingBall == true) {
            if (Input.GetMouseButtonDown(0)) {
                currentTime = 0.0f;
                canvasScript.EnableSlider(true);
                canvasScript.SetValueBar(0);
            }
            if (Input.GetMouseButton(0)) {
                currentTime += Time.deltaTime;
                ballForce = Mathf.Lerp(ballForceMin, ballForceMax, currentTime / totalTimer);
                canvasScript.SetValueBar(currentTime / totalTimer);
            }
            if (Input.GetMouseButtonUp(0)) {
                holdingBall = false;
                ballCollider.enabled = true;
                ballRB.useGravity = true;
                ballRB.AddForce(cam.forward * ballForce); 
                canvasScript.hideCursor(false);
                canvasScript.EnableSlider(false);
                ballTrail.enabled = true;
            }
        } else {
            if(Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, pickableLayer)) {
                if (isPickableBall == false) {
                    isPickableBall = true;
                    canvasScript.changePickableBallColor(true);
                }
                if (isPickableBall && Input.GetKeyDown(KeyCode.E)) {
                    holdingBall = true;
                    ballCollider.enabled = false;
                    ballRB.useGravity = false;
                    ballRB.velocity =  Vector3.zero;
                    ballRB.angularVelocity =  Vector3.zero;
                    ball.transform.localRotation = Quaternion.identity;

                    canvasScript.changePickableBallColor(true);
                    canvasScript.hideCursor(true);
                    ballTrail.enabled = false;
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

    private void LateUpdate() {
        if  (holdingBall == true) {
            ball.transform.position = cam.position + cam.forward * ballDistance;
        }
    }


    // Para saber en que escena estabamos
    private void SaveData(){
        PlayerPrefs.SetInt(sceneName, 2);
    }

    private void OnDestroy() {
        SaveData();
    }

}
