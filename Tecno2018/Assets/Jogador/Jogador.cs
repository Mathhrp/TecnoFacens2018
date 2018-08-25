using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour {
    //Movimento
    public int i, j;
    public int vel;

    //Status
    public int dmg;
    public int speed;
    public int maxhp,hp;
    public int maxbag;
    public float reload;
    //Vida
    public GameObject target = null,atual=null;
    public List<GameObject> heart;
    public Sprite heart_full;
    public Sprite heart_low;

    //Comandos
    public Button botao_J;
    public Button botao_K;
    public Button botao_L;
    //Morte
    public bool death;
    void Start()
    {
        death = false;
        dmg = LogJogador.dmg;
        speed = LogJogador.speed;
        maxhp = LogJogador.maxhp;
        hp = LogJogador.maxhp;
        maxbag = LogJogador.maxbag;
        reload = LogJogador.reload;

        i = 1;
        j = 2;
        atual = Quadrado();
        transform.position = new Vector3(atual.transform.position.x, atual.transform.position.y, transform.position.z);

        heart = new List<GameObject>();
        heart.Add(GameObject.Find("h1"));
        heart.Add(GameObject.Find("h2"));
        heart.Add(GameObject.Find("h3"));
        heart[0].SetActive(false);
        heart[1].SetActive(false);
        heart[2].SetActive(false);
        HeartControl();       
    }
	void Update () {
        if (target == null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                AddI(-1);
                target = Quadrado();
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                AddI(1);
                target = Quadrado();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                AddJ(-1);
                target = Quadrado();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                AddJ(1);
                target = Quadrado();
            }
            else if(Input.GetKeyDown(KeyCode.J))
            {
                botao_J.onClick.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                botao_K.onClick.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                if (hp < maxhp)
                {
                    botao_L.onClick.Invoke();
                }
            }
        }
        else 
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
        if(Mathf.Abs(target.transform.position.x - transform.position.x) <0.009f && Mathf.Abs(target.transform.position.y - transform.position.y) < 0.009f)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -0.1f);
            atual = target;
            target = null;
        }
    }
    public GameObject Quadrado()
    {
        return GameObject.Find("m_"+i.ToString()+"_"+j.ToString());
    }
    public void AddI(int val)
    {
        if(i+val<=2 && i+val>=0)
        {
            i = i + val;
        }
    }
    public void AddJ(int val)
    {
        if (j + val <= 2 && j + val >= 0)
        {
            j = j + val;
        }
    }

    public void HeartControl()
    {
        for(int i=0;i<hp;i++)
        {
          heart[i].SetActive(true);
        }

    }

    public void Life(int soma)
    {
        if(hp+soma<=0)
        {
            hp = 0;
            LifeUpdate();
            death = true;
        }
        else if(hp+soma<=maxhp)
        {
            hp = hp + soma;
            LifeUpdate();
        }
    }
    public void LifeUpdate()
    {
        for(int i=0;i<maxhp; i++)
        {
            if(i+1<=hp)
            {
                heart[i].GetComponent<Image>().sprite = heart_full;
            }
            else
            {
                heart[i].GetComponent<Image>().sprite = heart_low;
            }
        }
    }
    public GameObject Inimigo()
    {
        if(GameObject.Find("Inimigo")!=null)
        {
            return GameObject.Find("Inimigo");
        }
        else
        {
            return GameObject.Find("t_"+i.ToString());
        }

    }
}
