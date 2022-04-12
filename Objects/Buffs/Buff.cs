using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public BuffObject data;
    private SpriteRenderer _sr;
    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sprite = data.sprite;
    }
    public void Delete()
    {
        Destroy(gameObject);
    }

}
