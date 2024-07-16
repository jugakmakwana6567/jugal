using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunaim : MonoBehaviour
{
    public GameObject aim;
    public GameObject BulletPrefab;
    int bullets;
    public enemykill enemykill;
 

    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame  
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aim.transform.position = new Vector3(mousePos.x, mousePos.y);

        var diff = mousePos - transform.position;
        var angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetMouseButtonDown(0))
        {
            shoot(angle);

        }

    }
    private void shoot(float angle)
    {
        GameObject[] gunammos = GameObject.FindGameObjectsWithTag("ammo");

        if (gunammos.Length > 0)
        {
            bullets++;
            print("bulletcount" + bullets);

            var bullet = Instantiate(
                BulletPrefab,
                transform.position,
                Quaternion.Euler(0, 0, angle + 90)
            );

            var mousePos = Camera.main.WorldToScreenPoint(transform.position);
            var offset = (Input.mousePosition - mousePos).normalized;
            bullet.GetComponent<Rigidbody2D>().AddForce(offset * 100);

            var ammo = gunammos[gunammos.Length - 1].gameObject;
            ammo.transform.parent = null;
            Destroy(ammo);
            
        }
        else if(gunammos.Length <=1)
        {
            enemykill.ek.gameovr();
        }
      

    }
}
