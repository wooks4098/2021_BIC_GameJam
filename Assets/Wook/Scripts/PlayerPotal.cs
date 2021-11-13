using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPotal : MonoBehaviour
{
    [SerializeField] Transform MovePoint;//Æ÷Å» »ç¿ë½Ã µµÂøÁöÁ¡
    [SerializeField] Transform MovePoint2;//Æ÷Å» »ç¿ë½Ã µµÂøÁöÁ¡
    [SerializeField] Transform[] MovePos1;
    [SerializeField] Transform[] MovePos2;
    [SerializeField] bool isStore = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            PlayerMove playermove = other.gameObject.GetComponent<PlayerMove>();
            if (isStore)
            {
                int i = Random.Range(0, 2);
                switch(i)
                {
                    case 0:
                        other.transform.position = MovePoint.position;
                        playermove.ChangeMovePos(MovePos1);
                        break;
                    case 1:
                        other.transform.position = MovePoint2.position;
                        playermove.ChangeMovePos(MovePos2);
                        break;
                }

            }
            else
                other.transform.position = MovePoint.position;
            playermove.SetMove();
        }
    }
}
