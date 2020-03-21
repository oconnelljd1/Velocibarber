using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public enum Equipment { Hand, Cream, Knife, Towel }
    [SerializeField] Equipment[] options;
    private int selected = 0;
    private int highlighted = 0;

    private void Start()
    {
        SetChildColor((int)selected, Color.green);
    }

    public int GetSelected()
    {
        return selected;
    }

    public void SelectHighlighted()
    {
        SetChildColor(selected, Color.white);
        selected = highlighted;
        SetChildColor(selected, Color.green);
    }

    public void HighlightEquipment(int selection)
    {
        SetChildColor(highlighted, Color.white);
        highlighted = (int)options[selection];
        SetChildColor(selected, Color.green);
        SetChildColor(highlighted, Color.yellow);
    }

    private void SetChildColor(int child, Color color)
    {
        gameObject.transform.GetChild((int)options[child]).gameObject.GetComponent<Image>().color = color;
    }

}
