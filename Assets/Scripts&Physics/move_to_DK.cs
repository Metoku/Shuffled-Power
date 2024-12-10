using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class move_to_DK : MonoBehaviour
{
    // Start is called before the first frame update
    public LoadController loadController;
    private void OnTriggerEnter(Collider other)
    {
        loadController.LoadLevel(9);
    }
}
