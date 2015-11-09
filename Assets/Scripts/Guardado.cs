using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class Guardado : MonoBehaviour
{
    private const int tam = 5;
    private jugador[] top5 = new jugador[tam];
    private string[] jsontext;
    private JsonData jsonData;

    public void mostrarLista()
    {
        fCargarJSON();
        //Muestra la lista
        GameObject ob = GameObject.Find("Text");
        Text t = ob.GetComponent<Text>();
        ob = GameObject.Find("Terreno");
        Main m = (Main)ob.GetComponent(typeof(Main));

        t.text = ("Puntuacion: " + m.puntuacion() + "\nTiempo: " + m.tiempo());

        for (int i = 0; top5[i]!=null; i++)
        {
            t.text += ("\n" + (i+1) + " " + top5[i].nombre + top5[i].puntuacion + top5[i].tiempo);
        }

        //Actualiza la lista
        int pos = 0;

        while (top5[pos]!=null && m.puntuacion() < top5[pos].puntuacion && pos<5)
        {
            pos++;
        }
        if(pos!=0)
            pos++;

        if (pos < 5)
        {
            for (int i = tam - 2; i >= pos; i--)
                top5[i + 1] = top5[i];

            ob = GameObject.Find("Text3");
            Text input = ob.GetComponent<Text>();
            ob = GameObject.Find("Terreno");
            m = (Main)ob.GetComponent(typeof(Main));
            top5[pos].nombre = input.text;
            top5[pos].puntuacion = m.puntuacion();
            top5[pos].tiempo = m.tiempo();

            /*InputField input = gameObject.GetComponent<InputField>();
            InputField.SubmitEvent se = new InputField.SubmitEvent();
            se.AddListener(SubmitName);
            input.onEndEdit = se;*/
            //fGrabarJSON();
        }
    }
    /*
    private void SubmitName(string texto)
    {
        GameObject ob = GameObject.Find("Terreno");
        Main m = (Main)ob.GetComponent(typeof(Main));
        top5[pos].nombre = texto;
        top5[pos].puntuacion = m.puntuacion();
        top5[pos].tiempo = m.tiempo();
    }*/

    private void fCargarJSON()
    {
        if (!File.Exists(Application.dataPath + "/Player.json"))
            File.Create(Application.dataPath + "/Player.json");

        jsontext = File.ReadAllLines(Application.dataPath + "/Player.json");
        for (int i = 0; i < jsontext.Length; i++)
        {
            jsonData = JsonMapper.ToObject(jsontext[i]);
            top5[i].nombre = jsonData["nombre"].ToString();
            top5[i].puntuacion = int.Parse(jsonData["puntuacion"].ToString());
            top5[i].tiempo = float.Parse(jsonData["tiempo"].ToString());
        }
    }

    private void fGrabarJSON()
    {
        JsonData playerJSON;
        FileStream fs;

        if (!File.Exists(Application.dataPath + "/Player.json"))
            File.Create(Application.dataPath + "/Player.json");

        fs = File.OpenWrite(Application.dataPath + "/Player.json");

        StreamWriter sw = new StreamWriter(fs);

        for (int i = 0; i < tam-1; i++)
        {
            playerJSON = JsonMapper.ToJson(top5[i]);
            sw.Write(playerJSON.ToString()+"\n");
        }
        playerJSON = JsonMapper.ToJson(top5[4]);
        sw.Close();
        fs.Close();
    }

    private class jugador
    {
        public string nombre;
        public int puntuacion;
        public float tiempo;

        public jugador(string nombre, int puntuacion, float tiempo)
        {
            this.nombre = nombre;
            this.puntuacion = puntuacion;
            this.tiempo = tiempo;
        }

    }
}
