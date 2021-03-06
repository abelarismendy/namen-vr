﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class Gaze : MonoBehaviour
{
    public float gazetime = 3f;
    private float timer;
    private bool gazed;
    public Button button;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (gazed) {
            timer += Time.deltaTime;

            if (timer >= gazetime) {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
            }
        }
    }

    public void PointerEnter() {
        gazed = true;
    }

    public void PointerExit() {
        gazed = false;
    }

    public void PointerDown() {
        button = GetComponent<Button>();
        ExecuteEvents.Execute(button.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
    }
}
