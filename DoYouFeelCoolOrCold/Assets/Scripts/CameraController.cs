using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("Referência ao objeto Player, para a câmara o seguir")]
    public GameObject player;

    private Vector3 offset;

    [Tooltip("Valor da interpolação da nova posição.")]
    [SerializeField][Range(0f, 1f)] private float interpolation = 0.1f;
    [Tooltip("Tamanho da Câmara enquanto anda.")]
    [SerializeField] [Range(0f, 10f)] private float cameraWalkSize = 5f;
    [Tooltip("Tamanho da Câmara enquanto corre à Naruto.")]
    [SerializeField] [Range(0f, 10f)] private float cameraRunSize = 6f;


    // Complemento da interpolação
    private float comp_interpolation;

    private Camera self_camera;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        comp_interpolation = 1 - interpolation;
        self_camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = (transform.position * comp_interpolation) + ((player.transform.position + offset) * interpolation);
        if (player.GetComponent<PlayerMovement>().is_running)
        {
            self_camera.orthographicSize = self_camera.orthographicSize * comp_interpolation + cameraRunSize * interpolation;
        }
        else
        {
            self_camera.orthographicSize = self_camera.orthographicSize * comp_interpolation + cameraWalkSize * interpolation;
        }
    }
}
