using Unity.VisualScripting;
using UnityEngine;

public class ArrowPress : MonoBehaviour
{
    [SerializeField] bool canBePressed;
    [SerializeField] KeyCode keyToPress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && canBePressed)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target") canBePressed = true;
        else if (other.CompareTag("Destroyer")) Destroy(gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Target") canBePressed = false;
    }

    
}
