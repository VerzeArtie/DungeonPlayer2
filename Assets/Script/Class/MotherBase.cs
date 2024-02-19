using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MotherBase : MonoBehaviour
{
  public GameObject Filter;

  public virtual void Start()
  {
    One.InitializeGroundOne(false);
    Application.targetFrameRate = 60;
  }

  public virtual void RefreshAllView()
  {
    // 何もなし
  }

  public virtual void SceneBack()
  {
    if (this.Filter != null)
    {
      this.Filter.SetActive(false);
    }
  }
}