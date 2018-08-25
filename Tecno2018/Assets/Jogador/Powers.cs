using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powers : MonoBehaviour {
    public float j_Scale;
    public GameObject j_Cd;
    public float time_j;
    public bool flag_j;

    public float k_Scale;
    public GameObject k_Cd;
    public float time_k;
    public bool flag_k;

    public float l_Scale;
    public GameObject l_Cd;
    public float time_l;
    public bool flag_l;
    public int qtd;
    public Text text_qtd;
    public Text text_letra;
    public GameObject backgorundo;
    public Button heal_button;
    GameObject aux;
        
    public GameObject normal, special;

    void Start () {
        time_j = LogJogador.reload;
        time_k = LogJogador.reload;
        time_l = LogJogador.reload;
        flag_j = true;
        flag_k = false;
        flag_l = true;
        qtd = LogJogador.maxbag;
        j_Scale = 1;
        k_Scale = 0;
        l_Scale = 1;

        text_qtd.text = "<color>X" + qtd.ToString() +"</color>";
        StartCoroutine("K_CD");
    }
	
	void Update () {

        if (!flag_j)
        {
            if (j_Scale >= 1)
            {
                flag_j = true;               
                StopCoroutine("J_CD");
                j_Scale = 1;
            }
        }

        if (!flag_k)
        {
            if (k_Scale >= 1)
            {
                flag_k = true;
                k_Scale = 1;
                StopCoroutine("K_CD");
            }
        }

        if (!flag_l)
        {
            if (l_Scale >= 1)
            {
                flag_l = true;
                l_Scale = 1;
                StopCoroutine("L_CD");
            }
        }

        j_Cd.transform.localScale = new Vector3(j_Scale, j_Cd.transform.localScale.y, j_Cd.transform.localScale.z);
        k_Cd.transform.localScale = new Vector3(k_Scale, k_Cd.transform.localScale.y, k_Cd.transform.localScale.z);
        l_Cd.transform.localScale = new Vector3(l_Scale, l_Cd.transform.localScale.y, l_Cd.transform.localScale.z);
    }
    public void J_Click()
    {
        if(flag_j)
        {
            aux = Instantiate(normal, GameObject.Find("Tiro").transform.position, Quaternion.identity);
            aux.GetComponent<Tiro>().SetTarget(GameObject.Find("Player").GetComponent<Jogador>().Inimigo());
            j_Scale = 0;
            flag_j = false;
            StartCoroutine("J_CD");
        }
    }

    public void K_Click()
    {
        if (flag_k)
        {
            aux = Instantiate(special, GameObject.Find("Tiro").transform.position, Quaternion.identity);
            aux.GetComponent<Tiro>().SetTarget(GameObject.Find("Player").GetComponent<Jogador>().Inimigo());
            k_Scale = 0;
            flag_k = false;
            StartCoroutine("K_CD");
        }
    }

    public void L_Click()
    {
        if (flag_l && qtd-1>0)
        {
            qtd--;
            text_qtd.text = "<color>X" + qtd.ToString() + "</color>";
            l_Scale = 0;
            flag_l = false;
            StartCoroutine("L_CD");
            GameObject.Find("Player").GetComponent<Jogador>().Life(1);
        }
        else if(qtd-1==0)
        {
            text_qtd.text = "<color>X" + qtd.ToString() + "</color>";
            backgorundo.SetActive(false);
            heal_button.interactable = false;
            GameObject.Find("Player").GetComponent<Jogador>().Life(1);
            text_letra.text = "";
        }
    }
    private IEnumerator J_CD()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            j_Scale += time_j;
        }
    }

    private IEnumerator K_CD()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            k_Scale += time_k;
        }
    }

    private IEnumerator L_CD()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            l_Scale += time_l;
        }
    }
}
