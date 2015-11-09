using UnityEngine;
using System.Collections;
using System;

public class Main : MonoBehaviour {
    int nLosas, punt;
    float tiempoJuego;
    Vector3 posLosa;
    public GameObject botoncillo;
    public GameObject ob1, ob2, par1, par2;

    // Use this for initialization
    void Start () {
        botoncillo = GameObject.Find("Boton");
        botoncillo.SetActive(false);
        Time.timeScale = 1;
        tiempoJuego = Time.realtimeSinceStartup;
        nLosas = 0;
        punt = 0;
        posLosa = new Vector3(2f, 0f, 2f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (nLosas < 40)
        {
            generarLosa();
            generarCubo();
        }

        GameObject.Find("Main Camera").transform.position = new Vector3(GameObject.Find("Bola").transform.position.x - 8,
                                                                        GameObject.Find("Bola").transform.position.y + 8,
                                                                        GameObject.Find("Bola").transform.position.z - 8);



        /*
        if (punt >= 1)
        {
            Vector3 v = new Vector3(0.2f, 0.2f, 0.2f);
            GameObject.Find("Main Camera").transform.Rotate(v);
        }*/
    }

    public void decrementarLosa()
    {
        nLosas--;
    }

    public void incrementarPuntuacion()
    {
        punt++;
        if (punt % 5 == 0)
        {
            GameObject ob = GameObject.Find("Bola");
            Bola b = (Bola)ob.GetComponent(typeof(Bola));
            b.incrementarVelocidad();
        }
    }

    public int puntuacion()
    {
        return punt;
    }

    public float tiempo()
    {
        return tiempoJuego;
    }

    void generarLosa()
    {
        Vector3 pos = posLosa;
        if (UnityEngine.Random.Range(1f, 2f) < 1.5f)
            pos.x += 2;
        else
            pos.z += 2;

        GameObject objeto = Instantiate(ob1, pos, transform.rotation) as GameObject;
        objeto.transform.SetParent(par1.transform);

        posLosa = pos;
        nLosas++;
    }

    public void Reinicio()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void generarCubo()
    {
        Vector3 pos = posLosa;
        pos.y += 1.8f;
        if (UnityEngine.Random.Range(1f, 6f) > 5f)
        {
            pos.x += UnityEngine.Random.Range(-0.9f, 0.9f);
            pos.z += UnityEngine.Random.Range(-0.9f, 0.9f);
            GameObject objeto = Instantiate(ob2, pos, transform.rotation) as GameObject;
            objeto.transform.SetParent(par2.transform);
        }
    }
}
