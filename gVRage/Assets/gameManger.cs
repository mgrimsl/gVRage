using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManger : MonoBehaviour
{

    public int state = 0;

    public GameObject car;
    public GameObject jack;
    public GameObject tire;
    public GameObject wrench;
    public GameObject spare;



    Animator anim;
    Animator jackanim;
    Animator tireanim;
    Animator wrenchanim;
    Animator spareanim;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = car.GetComponent<Animator>();
        jackanim = jack.GetComponent<Animator>();
        tireanim = tire.GetComponent<Animator>();
        wrenchanim = wrench.GetComponent<Animator>();
        spareanim = spare.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            state = state + 1;
        }
        if (state == 1)
        {
            jackanim.SetBool("jackpalt", true);
            anim.SetBool("carjaked", true);
            tireanim.SetBool("tireup", true);
        }
        else if (state == 2)
        {
            wrenchanim.SetBool("removeLugnut", true);

        }else if (state == 3)
        {
            tireanim.SetBool("tireoff", true);
            wrenchanim.SetBool("backOut", true);


        }else if(state == 4)
        {
            tire.SetActive(false);
            spareanim.SetBool("putOn", true);
        }else if (state == 5)
        {
            wrenchanim.SetBool("backOut", false);
            wrenchanim.SetBool("backOn", true);
        }else if (state == 6)
        {
            jackanim.SetBool("jackpalt", false);
            anim.SetBool("carjaked", false);
            spareanim.SetBool("lower", true);
        }
    }
}
