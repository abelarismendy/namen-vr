using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour

{
    public float rateCrecimiento;
    private float timeRemaining;
    private float tiempoInicial;
    public int maxTime;
    public TextMeshProUGUI contador;
    public GameObject salirBoton;
    private bool inhalo;
    private bool centinela;
    private bool respirar;
    private bool finished;
    public List<float> tiemposIntercalados;
    private int i = 0;
    private List<float> tiemposIntercaladosRespaldo;
    void Start()
    {
        timeRemaining = 0.0f;
        tiempoInicial = Time.time;
        inhalo = false;
        centinela = false;
        respirar = false;
        finished = false;
        if (!respirar) {
            contador.text = "";
        }
        tiemposIntercaladosRespaldo = tiemposIntercalados;
        salirBoton.SetActive(false);
    }

    void Update()
    {

        if (Time.time - tiempoInicial >= tiemposIntercalados[0] & !finished){
            if (tiemposIntercalados.Count > 1){
                tiempoInicial += tiemposIntercalados[0];
                tiemposIntercalados.RemoveAt(0);
            }
            else {
                finished = true;
                respirar = false;
                timeRemaining = 2.0f;
            }
            if (i % 2 == 0){
                respirar = true;
            }
            else {
                respirar = false;
            }
            i += 1;

        }
        if (finished){

            if (timeRemaining <= 0.0f){
                tiemposIntercalados = tiemposIntercaladosRespaldo;
                timeRemaining = 0.0f;
                inhalo = false;
                centinela = false;
                respirar = false;
                salirBoton.SetActive(true);
            }
            else {
                timeRemaining -= Time.deltaTime;
            }
        }
        if (respirar){
            if (timeRemaining < (maxTime-2) & (inhalo==false))
            {
                rateCrecimiento = Mathf.Abs(rateCrecimiento);
                timeRemaining += Time.deltaTime;
                contador.text = "Inhala";
                if (Time.time - tiempoInicial + 2.0f >= tiemposIntercalados[0]){
                    contador.text = "";
                }

               changeSize();
            }

            else if ((timeRemaining < maxTime) & (timeRemaining >= maxTime-2) & (inhalo == false))
            {
                contador.text = "Mantén";

                if (timeRemaining <= maxTime & (centinela == false))
                {
                timeRemaining += Time.deltaTime;
                }
                if (timeRemaining >= maxTime)
                {
                    centinela = true;
                }
                if (centinela == true)
                {
                    timeRemaining -= Time.deltaTime;
                    if(timeRemaining<= maxTime-2)
                    {
                        inhalo = true;
                    }
                }

            }

            if (timeRemaining > 0.0f & (inhalo == true) & (timeRemaining <= maxTime-2))
            {
                rateCrecimiento = -Mathf.Abs(rateCrecimiento);
                timeRemaining -= Time.deltaTime;
                contador.text = "Exhala";
                centinela = false;
                changeSize();

                if (timeRemaining <= 1.5f)
                {
                    inhalo = false;
                }

            }
        }
        else {
            contador.text = "";
        }
    }

    void changeSize()
    {
        transform.localScale += new Vector3 (rateCrecimiento, rateCrecimiento, rateCrecimiento) * Time.deltaTime;
        contador.fontSize += rateCrecimiento * Time.deltaTime;
        //Vector3.one * rateCrecimiento;
    }

}