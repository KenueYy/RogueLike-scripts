using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float damping;
    [SerializeField]
    private Transform _player;
    void Update()
    {
        
        Vector3 currentPosition = Vector3.Lerp(transform.position, new Vector3(_player.transform.position.x, _player.transform.position.y, -10f), damping * Time.deltaTime);
        transform.position = currentPosition;
    }
}
