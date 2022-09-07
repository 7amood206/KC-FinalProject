using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunaiThrower : MonoBehaviour
{
    [SerializeField] private LayerMask kunai;
    public GameObject Kunai;
    public GameObject KunaiSprite;
    public float launchForce;
    public Transform shotPoint;
    private bool hasKunai = true;
    GameObject newKunai;


    void Start(){
        
    }
    void Update(){
        Vector2 kuniaPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - kuniaPosition;
        transform.right = direction;
        inKunaiRange();

        if(Input.GetMouseButtonDown(0) && hasKunai == true){
            Shoot();
        }
        
        bool inKunaiRange(){
            return Physics2D.OverlapCircle(shotPoint.position, 0.2f, kunai);
        }

        if(Input.GetKeyDown(KeyCode.Q) && hasKunai == false && inKunaiRange()){
            GameObject.Destroy(newKunai);
            hasKunai = true;
            KunaiSprite.GetComponent<Renderer>().enabled = true;
        }

        void Shoot(){
            newKunai = Instantiate(Kunai, shotPoint.position, shotPoint.rotation);
            newKunai.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            hasKunai = false;
            KunaiSprite.GetComponent<Renderer>().enabled = false;
        }

    }
}
