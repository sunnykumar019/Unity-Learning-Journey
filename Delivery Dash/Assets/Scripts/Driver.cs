using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float CurrentSpeed = 5f;
    [SerializeField] float BoostSpeed = 10f;
    [SerializeField] float regularSpeed = 5f;
    [SerializeField] TMP_Text boosttext;
    void Start()
    {
        boosttext.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost"))
        {
            CurrentSpeed = BoostSpeed;
            boosttext.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("WorldCollision"));
        {
            CurrentSpeed = regularSpeed;
         boosttext.gameObject.SetActive(false);
        }
        
    }
    void Update()
    {
        float move = 0f;
        float steer = 0f;
        if (Keyboard.current.wKey.isPressed)
        {
           move = 1f;
        }
         else if (Keyboard.current.sKey.isPressed)
        {
           move = -1f;
        }
         if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }
       float steerAmount = steer *steerSpeed*Time.deltaTime;
       float moveAmount =move *CurrentSpeed*Time.deltaTime;
       
        transform.Rotate(0, 0,steerAmount  );
        transform.Translate(0, moveAmount, 0);
    }
}
