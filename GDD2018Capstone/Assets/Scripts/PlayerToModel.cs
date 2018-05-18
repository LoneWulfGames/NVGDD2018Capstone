using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToModel : MonoBehaviour {

    GameObject selectedModel;
    public GameObject model;

	// Use this for initialization
	void Start ()
    {
        ShowPlayer();
	}

    public void SwapModel(GameObject newModel)
    {
        model = newModel;
        Destroy(selectedModel);
        ShowPlayer();
    }

    void ShowPlayer()
    {
        selectedModel = Instantiate(model, transform);
    }

}
