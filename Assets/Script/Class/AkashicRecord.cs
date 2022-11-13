using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkashicRecord : MonoBehaviour
{
  // 新規ゲーム、ロード、リロードに関わらず常に記憶されるクラス

  // ツァルマンの里からもらったObsidianStoneをゴラトラム洞窟のObsidianStone設置箇所に戻す
  [SerializeField] protected bool _inscribeObsidianStone_1 = false;
  public bool InscribeObsidianStone_1
  {
    set { _inscribeObsidianStone_1 = value; }
    get { return _inscribeObsidianStone_1; }
  }
}
