using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObjeto : MonoBehaviour
{
    public float speed;
    private float x;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        x += speed * Time.deltaTime;//deltaTime = quanto tempo entre um frame e outro

        transform.position = new Vector3(x, transform.position.y,transform.position.z);

        if(x <= -9)
        {
            Destroy(transform.gameObject); //destroi a barreira depois que acabar a tela
        }


    }
}
