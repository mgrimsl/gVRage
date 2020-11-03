using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManger : MonoBehaviour
{
    //state
    public int state = 0;
    //objects to animate 
    public GameObject car;
    public GameObject jack;
    public GameObject tire;
    public GameObject wrench;
    public GameObject spare;
    //audio clips to play
    public AudioClip step1;
    public AudioClip step2;
    public AudioClip step3;
    public AudioClip step4;
    public AudioClip step5;
    public AudioClip step6;
    public AudioClip step7;
    public AudioClip step8;
    public AudioClip step9;
    //animators to control animations
    Animator anim;
    Animator jackanim;
    Animator tireanim;
    Animator wrenchanim;
    Animator spareanim;
    //audio source to control audio clips
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = car.GetComponent<Animator>();
        jackanim = jack.GetComponent<Animator>();
        tireanim = tire.GetComponent<Animator>();
        wrenchanim = wrench.GetComponent<Animator>();
        spareanim = spare.GetComponent<Animator>();


        sound = GetComponent<AudioSource>();
        
    }

    public void nextState()
    {
        state = state + 1;
        if (state == 1)
        {              
            sound.clip = step1;
            sound.Play();
            
        }
        if (state == 2)
        {
            //losen lugnuts slightly before you jack car
            sound.clip = step2;
            sound.Play();

 
        }
        else if (state == 3)
        {

            sound.clip = step3;
            sound.Play();

            jackanim.SetBool("jackpalt", true);
            anim.SetBool("carjaked", true);
            tireanim.SetBool("tireup", true);
        }
        else if (state == 4)
        {
            sound.clip = step4;
            sound.Play();
            wrenchanim.SetBool("removeLugnut", true);
      
        }
        else if (state == 5)
        {

            sound.clip = step5;
            sound.Play();
            tireanim.SetBool("tireoff", true);
            wrenchanim.SetBool("backOut", true);

        }
        else if (state == 6)
        {
            sound.clip = step6;
            sound.Play();
            tire.SetActive(false);
            spareanim.SetBool("putOn", true);
        }
        else if (state == 7)
        {
            sound.clip = step7;
            sound.Play();
            wrenchanim.SetBool("backOut", false);
            wrenchanim.SetBool("backOn", true);
        }
        else if (state == 8)
        {
            sound.clip = step8;
            sound.Play();
            jackanim.SetBool("jackpalt", false);
            anim.SetBool("carjaked", false);
            spareanim.SetBool("lower", true);
        }
        else if (state == 9)
        {
            sound.clip = step9;
            sound.Play();

        }
    }

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKeyDown("right"))
        {
            nextState();
        }
       
    }
}
