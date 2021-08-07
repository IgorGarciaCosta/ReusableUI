using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public class IP_UI_System : MonoBehaviour
    {
        //variables
        [Header("System events")]
        public UnityEvent onSwitchedScreen = new UnityEvent();
        private Component[] screens = new Component[0];

        private IP_UI_Screen previousScreen;
        public IP_UI_Screen PreviousScreen{get{return previousScreen;}}

        private IP_UI_Screen currentScreen;
        public IP_UI_Screen CurrentScreen{get{return currentScreen;}}
        

        //functions
        void Start()
        {
            screens = GetComponentsInChildren<IP_UI_Screen>(true);
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

        public void LoadScene(int sceneIndex){
            StartCoroutine(WaitToLoad(sceneIndex));
        }

        IEnumerator WaitToLoad(int sceneIndex){
            yield return null;
        }
    }


