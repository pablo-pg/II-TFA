using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public int actualSecene = 1;

    private string sceneName = "Scene";


    private void Awake() {
        LoadData();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    public void PlayButton() {
        SceneManager.LoadScene(actualSecene);
    }

    public void BackButton() {
        SceneManager.LoadScene(1);
    }

    public void ExitButton() {
        Application.Quit();
    }

    // Para saber en que escena estabamos
    private void SaveData(){
    }

    private void LoadData(){
        actualSecene = PlayerPrefs.GetInt(sceneName, 1);
    }
}
