using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinamicGridNumBTN : MonoBehaviour {

    public int col, row;

    RectTransform parent;
    GridLayoutGroup grid;
     
    void Start () {
        parent = gameObject.GetComponent<RectTransform>();
        grid = gameObject.GetComponent<GridLayoutGroup>();

        grid.cellSize = new Vector2(parent.rect.width/col, parent.rect.height/row);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
