using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


    public class IP_UI_System : MonoBehaviour
    {
        //variables
        [Header("System events")]
        public UnityEvent onSwitchedScreen = new UnityEvent();
        private Component[] screens = new Component[0];

        [Header("Fader Properties")]
        public Image m_Fader;
        public float m_FadeInDuration = 1f;
        public float m_FadeOutDuration = 1f;


        private IP_UI_Screen previousScreen;
        public IP_UI_Screen PreviousScreen{get{return previousScreen;}}

        private IP_UI_Screen currentScreen;
        public IP_UI_Screen CurrentScreen{get{return currentScreen;}}
        

        //functions
        void Start()
        {
            screens = GetComponentsInChildren<IP_UI_Screen>(true);

            if(m_Fader){
                m_Fader.gameObject.SetActive(true);//initializes fader
            }
            FadeIn();
        
        }

        public void FadeIn(){
            if(m_Fader){
                m_Fader.CrossFadeAlpha(0f, m_FadeInDuration, false);
            }
        }

        public void FadeOut(){
            if(m_Fader){
                m_Fader.CrossFadeAlpha(0f, m_FadeOutDuration, false);
            }
        }

        
        void Update()
        {
            
        }

        public void SwitchScreens(IP_UI_Screen aScreen){
            if(aScreen){
                if(currentScreen){
                    //currentScreen.Close()
                    previousScreen = currentScreen;
                }
                currentScreen = aScreen;
                currentScreen.gameObject.SetActive(true);
                //currentScreen.StartScreen();

                if(onSwitchedScreen!=null){
                    onSwitchedScreen.Invoke();//broadcast triggered event 
                }

            }
        }

        public void GoToPreviousScreen(){
            if(previousScreen){
                SwitchScreens(previousScreen);
            }
        }

        public void LoadScene(string name){
            //StartCoroutine(WaitToLoad(sceneIndex));
            SceneManager.LoadScene(name);
        }

        IEnumerator WaitToLoad(int sceneIndex){
            yield return null;
        }
    }


