using UnityEngine;

using essentials;
using Unity.VisualScripting;
using System.Linq;
public class testing : MonoBehaviour
{

    //andy grabs the base character class from essentials
    class Andy : Character
    {

    }

    void Start()
    {
        Andy guy = new Andy();
        guy.roll_puzzle();
        for(int j = 0; j < guy.puzzle.Count; j++){
        Debug.Log(guy.puzzle.ElementAt(j).required_aspect);
        }
    }

}
