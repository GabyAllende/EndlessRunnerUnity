using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PavimentoManager : MonoBehaviour
{
    public GameObject[] pavimentosPrehechos;
    public float zSpawn = 0; //posicion en z de cada pavimento
    public float tamanoPavimento = 30;
    public int numPav = 7;
    public Transform transformJugador;
    private List<GameObject> pavActivas = new List<GameObject>();

    void Start()
    {
        
        for (int i = 0; i<numPav; i++) {
            if (i == 0)
            {
                aparecerPavimento(0);
            }
            else {
                aparecerPavimento(Random.Range(1, pavimentosPrehechos.Length));
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ZSPAWN"+zSpawn);
        Debug.Log("Pos Player> "+ transformJugador.position.z);
        Debug.Log("MAYOR A " + (zSpawn - (numPav * tamanoPavimento)));
        if (transformJugador.position.z - 35 > zSpawn - (numPav * tamanoPavimento)) {
            aparecerPavimento(Random.Range(1, pavimentosPrehechos.Length));
            borrarPav();
            JugadorController.velocidadAvance++;
            Debug.Log("ENTRAAAAAA");
        }
        
    }
    public void aparecerPavimento(int pavIndex) {
        GameObject pavActual = Instantiate(pavimentosPrehechos[pavIndex], transform.forward * zSpawn, transform.rotation);
        pavActivas.Add(pavActual);  
        zSpawn += tamanoPavimento;
    }
    private void borrarPav() {
        Destroy(pavActivas[0]);
        pavActivas.RemoveAt(0);
    }
}
