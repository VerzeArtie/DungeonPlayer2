using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class StackObject : MonoBehaviour
{
    [SerializeField] protected int _stackTimer = 0;
    public int StackTimer
    {
        get { return _stackTimer; }
        set { _stackTimer = value; }
    }

    [SerializeField] protected string _stackName = String.Empty;
    public string StackName
    {
        get { return _stackName; }
        set { _stackName = value; }
    }

    [SerializeField] protected Character _player = null;
    public Character Player
    {
        get { return _player; }
        set { _player = value; }
    }

    [SerializeField] protected Character _target = null;
    public Character Target
    {
        get { return _target; }
        set { _target = value; }
    }

    public Text txtStackName;
    public Text txtStackTime;
    public Image imgStackIcon;

    public void ConstructStack(Character player, Character target, string stack_name, int stack_timer)
    {
        _stackName = stack_name;
        _stackTimer = stack_timer;
        _player = player;
        _target = target;
        txtStackName.text = stack_name;
        txtStackTime.text = stack_timer.ToString();
        imgStackIcon.sprite = Resources.Load<Sprite>(stack_name);
    }
}
