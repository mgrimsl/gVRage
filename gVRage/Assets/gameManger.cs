using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using cakeslice;


public class gameManger : MonoBehaviour
{

    //buttons
    public Button next;
    public Button prev;

    //state
    public int state = 0;
    //objects to animate 
    public GameObject car;
    public GameObject jack;
    public GameObject tire;
    public GameObject wrench;
    public GameObject spare;
    public GameObject jackPlatform;
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

        prev.onClick.AddListener(prevHandle);
        next.onClick.AddListener(nextHandle);
        
        anim = car.GetComponent<Animator>();
        jackanim = jack.GetComponent<Animator>();
        tireanim = tire.GetComponent<Animator>();
        wrenchanim = wrench.GetComponent<Animator>();
        spareanim = spare.GetComponent<Animator>();


        sound = GetComponent<AudioSource>();
        
    }


    void prevHandle()
    {
        StartCoroutine(nextState(-1));
    }

    void nextHandle()
    {
        StartCoroutine(nextState(1));
    }

    public IEnumerator nextState(int num)
    {
        state = state + num;
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

            jackPlatform.AddComponent<cakeslice.Outline>();

            jackanim.SetBool("jackpalt", true);
            anim.SetBool("carjaked", true);
            tireanim.SetBool("tireup", true);
        }
        else if (state == 4)
        {
            Component jackOutline = jackPlatform.GetComponent<cakeslice.Outline>();
            Destroy(jackOutline);

            sound.clip = step4;
            sound.Play();
            wrench.AddComponent<cakeslice.Outline>();
            wrenchanim.SetBool("removeLugnut", true);
      
        }
        else if (state == 5)
        {
            sound.clip = step5;
            sound.Play();
            tire.AddComponent<cakeslice.Outline>();
            tireanim.SetBool("tireoff", true);
            wrenchanim.SetBool("backOut", true);

        }
        else if (state == 6)
        {
            Component wrenchOutline = wrench.GetComponent<cakeslice.Outline>();
            Destroy(wrenchOutline);
            Component tireOutline = tire.GetComponent<cakeslice.Outline>();
            Destroy(tireOutline);

            sound.clip = step6;
            sound.Play();

            spare.AddComponent<cakeslice.Outline>();
            tire.SetActive(false);
            spareanim.SetBool("putOn", true);
        }
        else if (state == 7)
        {
            Component spareOutline = spare.GetComponent<cakeslice.Outline>();
            Destroy(spareOutline);

            sound.clip = step7;
            sound.Play();

            wrench.AddComponent<cakeslice.Outline>();
            wrenchanim.SetBool("backOut", false);
            wrenchanim.SetBool("backOn", true);
        }
        else if (state == 8)
        {
            Component wrenchOutline = wrench.GetComponent<cakeslice.Outline>();
            Destroy(wrenchOutline);



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
            yield return new WaitForSeconds(3);
            wrenchanim.Play("Base Layer.spin", 0, 0f);
        }
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown("right"))
        {
            Debug.Log("next");
            StartCoroutine(nextState(1));
        }
       
    }
}
