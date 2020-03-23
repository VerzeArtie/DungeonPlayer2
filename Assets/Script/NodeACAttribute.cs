using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class NodeACAttribute : MonoBehaviour
{
    public Fix.CommandAttribute CommandAttribute;
    public Text txtName;
    public Image background;
    public Text txtTotal;
    public GameObject lockPanel;
    public List<Image> imgACElement;
    public List<Text> txtACElement;
    public List<Text> txtACPlus;
}
