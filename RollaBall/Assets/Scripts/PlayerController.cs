using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    private float count;
    public Text CountText;
    public Text winText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        setcountText();
        
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        //movement.add
        //cs
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);
            count = count + 1;
            setcountText();
        }
    }

    void setcountText(){
        CountText.text = "Score : " + count.ToString();
        if(count >= 11){
            winText.text = "You Win!!!";
        }
    }
}
