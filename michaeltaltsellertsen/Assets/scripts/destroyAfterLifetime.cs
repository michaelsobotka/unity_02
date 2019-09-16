using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterLifetime : MonoBehaviour
{
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", lifetime);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
