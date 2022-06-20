using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    public void volverAJugar() {
        SceneManager.LoadScene("Level");
        JugadorController.velocidadAvance = 10;
    }

    public void dejarDeJugar() {
        Application.Quit();
    }
}
