using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [SerializeField] float beatTempo;

    void Start()
    {
        beatTempo /= 60f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * beatTempo * Time.deltaTime);
    }
}
