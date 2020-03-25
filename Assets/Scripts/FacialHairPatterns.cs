using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialHairPatterns : MonoBehaviour
{

    public bool[] goatee = new bool[25] { false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false };
    public bool[] mustache = new bool[25] { false, false, false, false, false, false, false, false, false, false, false, true, true, false, false, false, false, false, false, false, false, false, false, false, true };
    public bool[] handleBar = new bool[25] { false, false, false, false, false, false, false, false, false, true, false, true, true, false, false, false, false, false, false, false, false, false, true, false, true };
    public bool[] muttonChops = new bool[25] { true, true, true, false, false, false, false, true, false, true, false, true, true, true, true, true, false, false, false, false, true, false, true, false, true };
    public bool[] chinStrap = new bool[25] { true, true, true, false, false, false, false, true, true, false, false, false, false, true, true, true, false, false, false, false, true, true, false, false, false };
    public bool[] neckbeard = new bool[25] { false, false, false, true, true, false, false, true, true, false, false, false, false, false, false, false, true, true, false, false, true, true, false, false, false };
    // public bool[] goatee = new bool[25] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
    // public bool[] goatee = new bool[25] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
    // public bool[] goatee = new bool[25] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
}
