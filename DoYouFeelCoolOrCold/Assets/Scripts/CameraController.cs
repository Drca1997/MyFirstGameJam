using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("Referência ao objeto Player, para a câmara o seguir")]
    public GameObject player;

    private Vector3 offset;

    // Interpolação (0f a 1f)
    [SerializeField][Range(0f, 1f)] private float interpolation = 0.1f;
    // Complemento da interpolação
    private float comp_interpolation;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        comp_interpolation = 1 - interpolation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = (transform.position * comp_interpolation) + ((player.transform.position + offset) * interpolation);
    }
}
