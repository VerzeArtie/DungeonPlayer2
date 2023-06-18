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

  // ���F���K�X�̊C��_�a�A�E���̊ԁA���̐߂Q�`�P�T�̋L�^�i���o�[
  // ���̐߂P�ƂP�U�͌Œ�l�i�ύX����Ȃ��j�����������Ȃ�̂ŁA�L�^�ɂ͓���Ă����B
  [SerializeField] protected int _velgus_chant_sequence_1 = 1; // 1�����Œ�
  public int Velgus_Chant_Sequence_1
  {
    set { _velgus_chant_sequence_1 = value; }
    get { return _velgus_chant_sequence_1; }
  }
  [SerializeField] protected int _velgus_chant_sequence_2 = 0;
  public int Velgus_Chant_Sequence_2
  {
    set { _velgus_chant_sequence_2 = value; }
    get { return _velgus_chant_sequence_2; }
  }
  [SerializeField] protected int _velgus_chant_sequence_3 = 0;
  public int Velgus_Chant_Sequence_3
  {
    set { _velgus_chant_sequence_3 = value; }
    get { return _velgus_chant_sequence_3; }
  }
  [SerializeField] protected int _velgus_chant_sequence_4 = 0;
  public int Velgus_Chant_Sequence_4
  {
    set { _velgus_chant_sequence_4 = value; }
    get { return _velgus_chant_sequence_4; }
  }
  [SerializeField] protected int _velgus_chant_sequence_5 = 0;
  public int Velgus_Chant_Sequence_5
  {
    set { _velgus_chant_sequence_5 = value; }
    get { return _velgus_chant_sequence_5; }
  }
  [SerializeField] protected int _velgus_chant_sequence_6 = 0;
  public int Velgus_Chant_Sequence_6
  {
    set { _velgus_chant_sequence_6 = value; }
    get { return _velgus_chant_sequence_6; }
  }
  [SerializeField] protected int _velgus_chant_sequence_7 = 0;
  public int Velgus_Chant_Sequence_7
  {
    set { _velgus_chant_sequence_7 = value; }
    get { return _velgus_chant_sequence_7; }
  }
  [SerializeField] protected int _velgus_chant_sequence_8 = 0;
  public int Velgus_Chant_Sequence_8
  {
    set { _velgus_chant_sequence_8 = value; }
    get { return _velgus_chant_sequence_8; }
  }
  [SerializeField] protected int _velgus_chant_sequence_9 = 0;
  public int Velgus_Chant_Sequence_9
  {
    set { _velgus_chant_sequence_9 = value; }
    get { return _velgus_chant_sequence_9; }
  }
  [SerializeField] protected int _velgus_chant_sequence_10 = 0;
  public int Velgus_Chant_Sequence_10
  {
    set { _velgus_chant_sequence_10 = value; }
    get { return _velgus_chant_sequence_10; }
  }
  [SerializeField] protected int _velgus_chant_sequence_11 = 0;
  public int Velgus_Chant_Sequence_11
  {
    set { _velgus_chant_sequence_11 = value; }
    get { return _velgus_chant_sequence_11; }
  }
  [SerializeField] protected int _velgus_chant_sequence_12 = 0;
  public int Velgus_Chant_Sequence_12
  {
    set { _velgus_chant_sequence_12 = value; }
    get { return _velgus_chant_sequence_12; }
  }
  [SerializeField] protected int _velgus_chant_sequence_13 = 0;
  public int Velgus_Chant_Sequence_13
  {
    set { _velgus_chant_sequence_13 = value; }
    get { return _velgus_chant_sequence_13; }
  }
  [SerializeField] protected int _velgus_chant_sequence_14 = 0;
  public int Velgus_Chant_Sequence_14
  {
    set { _velgus_chant_sequence_14 = value; }
    get { return _velgus_chant_sequence_14; }
  }
  [SerializeField] protected int _velgus_chant_sequence_15 = 0;
  public int Velgus_Chant_Sequence_15
  {
    set { _velgus_chant_sequence_15 = value; }
    get { return _velgus_chant_sequence_15; }
  }
  [SerializeField] protected int _velgus_chant_sequence_16 = 16; // 16�����Œ�
  public int Velgus_Chant_Sequence_16
  {
    set { _velgus_chant_sequence_16 = value; }
    get { return _velgus_chant_sequence_16; }
  }

  [SerializeField] protected bool _velgus_chant_achivement = false;
  public bool VelgusChantAchivement
  {
    set { _velgus_chant_achivement = value; }
    get { return _velgus_chant_achivement; }
  }

  public void Velgus_Chant_Sequence(int number)
  {
    if (number == One.AR.Velgus_Chant_Sequence_2 ||
        number == One.AR.Velgus_Chant_Sequence_3 ||
        number == One.AR.Velgus_Chant_Sequence_4 ||
        number == One.AR.Velgus_Chant_Sequence_5 ||
        number == One.AR.Velgus_Chant_Sequence_6 ||
        number == One.AR.Velgus_Chant_Sequence_7 ||
        number == One.AR.Velgus_Chant_Sequence_8 ||
        number == One.AR.Velgus_Chant_Sequence_9 ||
        number == One.AR.Velgus_Chant_Sequence_10 ||
        number == One.AR.Velgus_Chant_Sequence_11 ||
        number == One.AR.Velgus_Chant_Sequence_12 ||
        number == One.AR.Velgus_Chant_Sequence_13 ||
        number == One.AR.Velgus_Chant_Sequence_14 ||
        number == One.AR.Velgus_Chant_Sequence_15)
    {
      // ���Ƀ��R�[�h�����ӏ�������ꍇ�͍X�V���Ȃ��B
      Debug.Log("AkashicRecord has been already recorded, then no action: " + number.ToString());
      return;
    }

    if (One.AR.Velgus_Chant_Sequence_2 == 0)
    {
      One.AR.Velgus_Chant_Sequence_2 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_2:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_3 == 0)
    {
      One.AR.Velgus_Chant_Sequence_3 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_3:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_4 == 0)
    {
      One.AR.Velgus_Chant_Sequence_4 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_4:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_5 == 0)
    {
      One.AR.Velgus_Chant_Sequence_5 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_5:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_6 == 0)
    {
      One.AR.Velgus_Chant_Sequence_6 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_6:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_7 == 0)
    {
      One.AR.Velgus_Chant_Sequence_7 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_7:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_8 == 0)
    {
      One.AR.Velgus_Chant_Sequence_8 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_8:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_9 == 0)
    {
      One.AR.Velgus_Chant_Sequence_9 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_9:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_10 == 0)
    {
      One.AR.Velgus_Chant_Sequence_10 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_10:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_11 == 0)
    {
      One.AR.Velgus_Chant_Sequence_11 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_11:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_12 == 0)
    {
      One.AR.Velgus_Chant_Sequence_12 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_12:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_13 == 0)
    {
      One.AR.Velgus_Chant_Sequence_13 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_13:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_14 == 0)
    {
      One.AR.Velgus_Chant_Sequence_14 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_14:" + number.ToString());
    }
    else if (One.AR.Velgus_Chant_Sequence_15 == 0)
    {
      One.AR.Velgus_Chant_Sequence_15 = number;
      One.UpdateAkashicRecord();
      Debug.Log("AkashicRecord was recorded: Velgus_Chant_Sequence_15:" + number.ToString());
    }
  }

  public int VelgusSearchChantNumber(int number)
  {
    if (number == 2) { return One.AR.Velgus_Chant_Sequence_2; }
    if (number == 3) { return One.AR.Velgus_Chant_Sequence_3; }
    if (number == 4) { return One.AR.Velgus_Chant_Sequence_4; }
    if (number == 5) { return One.AR.Velgus_Chant_Sequence_5; }
    if (number == 6) { return One.AR.Velgus_Chant_Sequence_6; }
    if (number == 7) { return One.AR.Velgus_Chant_Sequence_7; }
    if (number == 8) { return One.AR.Velgus_Chant_Sequence_8; }
    if (number == 9) { return One.AR.Velgus_Chant_Sequence_9; }
    if (number == 10) { return One.AR.Velgus_Chant_Sequence_10; }
    if (number == 11) { return One.AR.Velgus_Chant_Sequence_11; }
    if (number == 12) { return One.AR.Velgus_Chant_Sequence_12; }
    if (number == 13) { return One.AR.Velgus_Chant_Sequence_13; }
    if (number == 14) { return One.AR.Velgus_Chant_Sequence_14; }
    if (number == 15) { return One.AR.Velgus_Chant_Sequence_15; }

    return 0;
  }
}
