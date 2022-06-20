using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    public void volverAJugar() {
        SceneManager.LoadScene("Level");
    }

    public void dejarDeJugar() {
        Application.Quit();
    }
}
