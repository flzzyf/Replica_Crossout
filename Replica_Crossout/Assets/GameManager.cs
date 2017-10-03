using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject playerHighlightTarget;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

}
