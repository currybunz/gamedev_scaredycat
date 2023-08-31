using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    [SerializeField] private AudioClip moveSound;
    [SerializeField] private AudioClip selectSound;

    private RectTransform rect;
    private int currentPos;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);
    }

    private void ChangePosition(int _change)
    {
        currentPos += _change;

        if (_change != 0)
            Sounds.instance.PlaySound(moveSound);

        if (currentPos < 0)
            currentPos = options.Length - 1;
        else if (currentPos > options.Length - 1)
            currentPos = 0;

        //Assign Y position of current option to the selection arrow
        rect.position = new Vector3(rect.position.x, options[currentPos].position.y, 0);
    }
}
