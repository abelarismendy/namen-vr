using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour

{
    public float rateCrecimiento;
    public float timeRemaining = 10;
    public int maxTime;
    public TextMeshPro contador;
    public bool inhalo;
    public bool centinela;

    void Start()
        {
            timeRemaining = 0;
            rateCrecimiento = .2f;
            inhalo = false;
            centinela = false;
        }

    void Update()
    {
        if (timeRemaining < (maxTime-2) & (inhalo==false))
        {
            rateCrecimiento = Mathf.Abs(rateCrecimiento);
            timeRemaining += Time.deltaTime;
            contador.text = "Inhala";

            changeSize();
        }

            else if ((timeRemaining < maxTime) & (timeRemaining >= maxTime-2) & (inhalo == false))
        {
            contador.text = "Mantenga la respiracion";

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

            if (timeRemaining <= 0.1f)
            {
                inhalo = false;
            }

        }

    }

    void changeSize()
    {
        transform.localScale += new Vector3 (rateCrecimiento, rateCrecimiento, rateCrecimiento) * Time.deltaTime;
        //Vector3.one * rateCrecimiento;
    }

}