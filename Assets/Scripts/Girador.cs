using UnityEngine;
using System.Collections;

public class Girador : MonoBehaviour {
    float velocidad = 0.8f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(velocidad, velocidad, velocidad));
	}
}
