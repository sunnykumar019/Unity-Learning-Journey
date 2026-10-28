using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
  bool hasPackage;
  [SerializeField] float delay = 1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Package")&&!hasPackage)
        {
            Debug.Log("Picked Up Package");
            hasPackage = true;   
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject,delay);        
        }
        else if(collision.CompareTag("Customer")&& hasPackage)
        {
            Debug.Log("Delivered");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject);
    }

}
}
