using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemykill : MonoBehaviour
{
    public GameObject gameoverpanel;
    public GameObject youwin;

    public static enemykill ek;

    // Start is called before the first frame update
    void Start()
    {
        ek = this;
        gameoverpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void gameovr()
    {
        gameoverpanel.SetActive(true);
    }
    public void youwinmethod()
    {

        youwin.SetActive(true);

    }
}
