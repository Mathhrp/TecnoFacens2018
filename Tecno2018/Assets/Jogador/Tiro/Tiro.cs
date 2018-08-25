using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {

    public int vel;
    public int dano;
    public GameObject target = null;

    void Start () {
		dano = LogJogador.dmg+dano;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (target != null)
        {
            Mover();
            VerificaChegada();
        }
    }
    public void Mover()
    {
        float step = vel * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
    public void VerificaChegada()
    {
        if (Mathf.Abs(target.transform.position.x - transform.position.x) < 0.009f && Mathf.Abs(target.transform.position.y - transform.position.y) < 0.009f)
        {
            Destroy(gameObject);
        }
    }
    public void SetTarget(GameObject alvo)
    {
        target = alvo;
    }
}
