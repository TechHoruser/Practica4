using UnityEngine;
using System.Collections;

public class Caedor : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(this.transform.position.y < -20)
        {
            GameObject ob = GameObject.Find("Terreno");
            Main m = (Main) ob.GetComponent(typeof(Main));
            m.decrementarLosa();
            Destroy(this);
        }
	}

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.name == "Bola")
            this.gameObject.AddComponent<Rigidbody>();
    }
}
