using UnityEngine;

using essentials;
using Unity.VisualScripting;
using System.Linq;
public class testing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    class Andy : Character
    {

    }

    void Start()
    {
        Andy guy = new Andy();
        guy.roll_puzzle();
        for(int j = 0; j < guy.puzzle.Count; j++){
        Debug.Log(guy.puzzle.ElementAt(j));
    }
    }

}
