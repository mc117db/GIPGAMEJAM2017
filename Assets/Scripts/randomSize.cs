using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSize : MonoBehaviour {


	void Start () {
        float chosen = Random.RandomRange(0.85f, 1.2f);
        transform.localScale = transform.localScale * chosen;

    }

}
