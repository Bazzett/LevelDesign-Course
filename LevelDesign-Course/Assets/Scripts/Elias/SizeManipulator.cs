using UnityEngine;

public class SizeManipulator : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private enum State
    {
        Normal,
        Big,
        Small,
    }

    private State _state;

    private void Start()
    {
        _state = State.Normal;
    }


    void Update()
    {
        switch (_state)
        {
            case State.Normal:
                break;
            case State.Big:
                break;
            case State.Small:
                break;
        }
        
        Shrink();
        
        Grow();
    }

    private void Grow()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.transform.localScale = new Vector3(2, 2, 2);
        }
    }

    private void Shrink()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
