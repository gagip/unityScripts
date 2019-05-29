using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea] // 한 줄말고 여러줄로 쓸 수 있게
    public string dialogue;
    public int characterNum;
}

public class talk : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite_StandingCG;
    [SerializeField] private SpriteRenderer sprite_DialogueBox;
    [SerializeField] private Text txt_Dialogue;
    [SerializeField] private Sprite merry;
    [SerializeField] private Sprite ddd;


    private bool isDialogue = false;
    private int count = 0;

    [SerializeField] private Dialogue[] dialogue;



    public void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        sprite_StandingCG.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
    }

    public void ShowDialogue()
    {
        OnOff(true);
        count = 0;
        isDialogue = true;
        NextDialogue();
    }

    public void HideDialogue()
    {
        OnOff(false);
        isDialogue = false;
    }

    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue;
        if(dialogue[count].characterNum == 1)
        {
            sprite_StandingCG.sprite = merry;
        }
        else if(dialogue[count].characterNum == 2)
        {
            sprite_StandingCG.sprite = ddd;
        }
        count++;
    }
    
    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                if (count < dialogue.Length)
                {
                    NextDialogue();

                }
                else
                    HideDialogue();
            }
        }
    }
}
