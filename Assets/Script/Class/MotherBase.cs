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

  /// <summary>
  /// 指定した Text を上下スクロール可能にする。
  /// フォントサイズを一定に保ったまま任意の長さの文章を読ませるための土台であり、
  /// 枠に収めるために文面を削ったり言語ごとに字を小さくしたりする必要を無くす。
  /// 元の RectTransform をそのまま表示窓 (Viewport) として使い、Text 自身を中身 (Content) にする。
  /// シーン側の構造には手を入れず実行時に組み立てる。二重適用はしない。
  /// </summary>
  protected ScrollRect MakeVerticalScrollable(Text target)
  {
    if (target == null) { return null; }

    RectTransform content = target.rectTransform;
    ScrollRect already = target.GetComponentInParent<ScrollRect>();
    if (already != null) { return already; }

    Transform parent = content.parent;
    if (parent == null)
    {
      Debug.LogError("MakeVerticalScrollable: 親が存在しません name=" + target.name);
      return null;
    }

    // 表示窓を Text と同じ位置・大きさで作り、Text をその子に移す。
    GameObject viewObj = new GameObject(target.name + "_Viewport",
      typeof(RectTransform), typeof(Image), typeof(RectMask2D), typeof(ScrollRect));
    RectTransform view = viewObj.GetComponent<RectTransform>();
    view.SetParent(parent, false);
    view.SetSiblingIndex(content.GetSiblingIndex());
    view.anchorMin = content.anchorMin;
    view.anchorMax = content.anchorMax;
    view.pivot = content.pivot;
    view.offsetMin = content.offsetMin;
    view.offsetMax = content.offsetMax;

    // 文章が短く余白ができた時でもドラッグを拾えるよう、透明の当たり判定を敷く。
    Image catcher = viewObj.GetComponent<Image>();
    catcher.color = new Color(0f, 0f, 0f, 0f);
    catcher.raycastTarget = true;

    content.SetParent(view, false);
    content.anchorMin = new Vector2(0f, 1f);
    content.anchorMax = new Vector2(1f, 1f);
    content.pivot = new Vector2(0.5f, 1f);
    content.anchoredPosition = Vector2.zero;
    content.sizeDelta = new Vector2(0f, content.sizeDelta.y);

    // 文字量に応じて縦へ伸ばす。Best Fit は使わない (言語を区別せず日本語まで縮めるため)。
    target.horizontalOverflow = HorizontalWrapMode.Wrap;
    target.verticalOverflow = VerticalWrapMode.Overflow;
    target.resizeTextForBestFit = false;

    ContentSizeFitter fitter = target.GetComponent<ContentSizeFitter>();
    if (fitter == null) { fitter = target.gameObject.AddComponent<ContentSizeFitter>(); }
    fitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
    fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

    ScrollRect scroll = viewObj.GetComponent<ScrollRect>();
    scroll.viewport = view;
    scroll.content = content;
    scroll.horizontal = false;
    scroll.vertical = true;
    scroll.movementType = ScrollRect.MovementType.Clamped;
    scroll.inertia = true;
    scroll.scrollSensitivity = 20f;
    return scroll;
  }

  /// <summary>
  /// 文章を差し替えた直後にスクロール位置を先頭へ戻す。
  /// 差し替え前の位置が残ると、短い文章に切り替えた時に何も見えなくなる。
  /// </summary>
  protected void ResetScrollToTop(Text target)
  {
    if (target == null) { return; }
    ScrollRect scroll = target.GetComponentInParent<ScrollRect>();
    if (scroll == null) { return; }

    // 新しい文章の高さが確定してからでないと、先頭へ戻す計算が古い高さで行われる。
    Canvas.ForceUpdateCanvases();
    LayoutRebuilder.ForceRebuildLayoutImmediate(target.rectTransform);
    scroll.verticalNormalizedPosition = 1f;
  }

  public virtual void SceneBack()
  {
    if (this.Filter != null)
    {
      this.Filter.SetActive(false);
    }
  }
}