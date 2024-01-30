using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    private GameObject orbitCenter = null; // Objeto em torno do qual esse objeto irá orbitar
    [SerializeField]
    private GameObject defaultOrbitCenter; // Objeto "sun" que será definido como padrão no Editor do Unity
    [SerializeField]
    float orbitSpeed = 10f;
    [SerializeField]
    private float selfRotationSpeed = 20f;
    [SerializeField]
    private bool rotateLaterally = false; // Controla se o objeto rotacionará lateralmente
    [SerializeField]
    private float lateralRotationSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        // Definir o valor padrão para orbitCenter como "sun" se não estiver definido explicitamente no Editor
        if (orbitCenter == null && defaultOrbitCenter != null)
        {
            orbitCenter = defaultOrbitCenter;
        }
    }

    // Update is called once per frame
    void Update()
    {
          if (orbitCenter != null)
        {
            this.transform.RotateAround(orbitCenter.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);

            if (rotateLaterally)
            {
                // Rotacionar lateralmente em direção ao centro de órbita
                Vector3 relativePos = orbitCenter.transform.position - this.transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * lateralRotationSpeed);
            }
        }

       

        //this.transform.RotateAround(orbitCenter.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
        this.transform.RotateAround(this.transform.position, Vector3.up, selfRotationSpeed * Time.deltaTime);

    }
}
