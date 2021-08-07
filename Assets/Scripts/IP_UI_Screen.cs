using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CanvasGroup))]
public class IP_UI_Screen : MonoBehaviour
{
    //variables
    [Header("Main Properties")]
    public Selectable m_StartSelectable;

    [Header("Screen Events")]
    public UnityEvent onScreenStart = new UnityEvent();
    public UnityEvent onScreenClose = new UnityEvent();
    
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
        if(m_StartSelectable){
            EventSystem.current.SetSelectedGameObject(m_StartSelectable.gameObject);
        }
    }

    public virtual void StartScreen(){
        if(onScreenStart!=null){
            onScreenStart.Invoke();
        }
        handleAnimator("show");
        
    } 
    public virtual void CloseScreen(){
        if(onScreenClose!=null){
            onScreenClose.Invoke();
        }
        handleAnimator("hide");
    } 

    void handleAnimator(string aTrigger){
        if(animator){
            animator.SetTrigger(aTrigger);
        }
    }

    
}

