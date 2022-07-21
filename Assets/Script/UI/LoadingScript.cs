using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider slider;
    public static bool playWarning;
    public float Timer = 0;
    public float DelayAmount;
    public float timeLeft;
    public GameObject notifyScreen;
    private void Start()
    {
        notifyScreen.SetActive(false);
        slider = this.GetComponent<Slider>();
    }
    private void FixedUpdate()
    {
        float realTime = 600f / 100f;
        Timer += Time.deltaTime;

        if (Timer >= realTime)
        {
            Timer = 0f;
            slider.value++;


        }
        if (slider.value == 50 || slider.value == 95)
        {
            playWarning = true;
            ZombieSpawner.stopSpawn = true;



        }
        if (playWarning == true)
        {
            notifyScreen.SetActive(true);
            timeLeft -= Time.deltaTime;
            //Debug.Log(timeLeft);
            if (timeLeft < 0)
            {
                notifyScreen.SetActive(false);
                playWarning = false;
            }
        }

    }
}
