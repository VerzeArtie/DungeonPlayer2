using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkashicRecord : MonoBehaviour
{
  // �V�K�Q�[���A���[�h�A�����[�h�Ɋւ�炸��ɋL�������N���X

  // �c�@���}���̗�����������ObsidianStone���S���g�������A��ObsidianStone�ݒu�ӏ��ɖ߂�
  [SerializeField] protected bool _inscribeObsidianStone_1 = false;
  public bool InscribeObsidianStone_1
  {
    set { _inscribeObsidianStone_1 = value; }
    get { return _inscribeObsidianStone_1; }
  }
}
