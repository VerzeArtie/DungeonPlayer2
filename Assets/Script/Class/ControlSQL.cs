using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UnityEditor;
using UnityEngine;

public class ControlSQL : MonoBehaviour
{
  public string connection = string.Empty;

  private string TABLE_CHARACTER = "character_data";
  private string TABLE_OWNER_DATA = "dp2_owner_data";
  private string TABLE_ARCHIVEMENT = "archivement";
  private string TABLE_SAVE_DATA = "save_data";
  private string TABLE_DUEL = "duel";
  private string TABLE_AR_DATA = "dp2_ar_data";

  public void SetupSql()
  {
    // if (GroundOne.SupportLog == false) { return; }

    try
    {
      string connection = string.Empty;
      StringBuilder sb = new StringBuilder();
      sb.Append("Server=133.242.151.26;");
      sb.Append("Port=36712;");
      sb.Append("User Id=postgres;");
      sb.Append("Password=volgan3612;");
      sb.Append("Database=postgres;");
      sb.Append("Timeout=1;");

      connection = sb.ToString();
      this.connection = connection;

    }
    catch (Exception ex)
    {
      Debug.Log("SetupSql error... " + DateTime.Now + " " + ex.ToString());
    } // ログ失敗時は、そのまま進む
  }

  public string SelectOwner(string name)
  {
    if (One.CONF.SupportLog == false) { return String.Empty; }

    string table = TABLE_OWNER_DATA;
    string jsonData = String.Empty;
    try
    {
      using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
      {
        //Debug.Log("SelectOwner timeout: " + con.ConnectionTimeout);
        con.OpenAsync().Wait();
        NpgsqlCommand cmd = new NpgsqlCommand(@"select to_json(" + table + ") from " + table + " where name = '" + name + "'", con);
        var dataReader = cmd.ExecuteReaderAsync();
        while (dataReader.Result.Read())
        {
          jsonData += dataReader.Result[0].ToString();
        }
      }
    }
    catch (Exception ex)
    {
      Debug.Log("SelectOwner error... " + DateTime.Now + " " + ex.ToString());
    } // ログ失敗時は、そのまま進む

    return jsonData;
  }

  public void ChangeOwnerName(string main_event, string sub_event, string current_field, string name)
  {
    if (One.CONF.SupportLog == false) { return; }
    if (One.SQL == null) { return; }

    try
    {
      string main_level = String.Empty;
      string guid = String.Empty;

      using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
      {
        con.OpenAsync().Wait();

        NpgsqlCommand cmd = new NpgsqlCommand(@"select guid from " + TABLE_OWNER_DATA + " where name = '" + One.CONF.Account + "'", con);
        var dataReader = cmd.ExecuteReaderAsync();
        while (dataReader.Result.Read())
        {
          guid += dataReader.Result[0].ToString();
        }
      }
      if (guid == String.Empty)
      {
        return;
      }

      using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
      {
        con.OpenAsync().Wait();

        DateTime update_time = DateTime.Now;
        string updateCommand = @"update " + TABLE_OWNER_DATA + " set update_time = :update_time";
        if (name != string.Empty)
        {
          updateCommand += ", name = :name";
        }
        if (main_event != string.Empty)
        {
          updateCommand += ", main_event = :main_event";
        }
        if (sub_event != string.Empty)
        {
          updateCommand += ", sub_event = :sub_event";
        }
        if (current_field != string.Empty)
        {
          updateCommand += ", current_field = :current_field";
        }
        if (main_level != string.Empty)
        {
          updateCommand += ", main_level = :main_level";
        }
        string device_type = Application.platform.ToString();
        updateCommand += ", device_type = :device_type";
        updateCommand += " where guid = :guid";

        NpgsqlCommand command = new NpgsqlCommand(updateCommand, con);
        command.Parameters.Add(new NpgsqlParameter("name", DbType.String) { Value = name });
        command.Parameters.Add(new NpgsqlParameter("update_time", NpgsqlDbType.Timestamp) { Value = update_time }); // Fix-Issue ( DbType.DateTime is incorrect )
        if (main_event != string.Empty)
        {
          command.Parameters.Add(new NpgsqlParameter("main_event", DbType.String) { Value = main_event });
        }
        if (sub_event != string.Empty)
        {
          command.Parameters.Add(new NpgsqlParameter("sub_event", DbType.String) { Value = sub_event });
        }
        if (current_field != string.Empty)
        {
          command.Parameters.Add(new NpgsqlParameter("current_field", DbType.String) { Value = current_field });
        }
        if (main_level != string.Empty)
        {
          command.Parameters.Add(new NpgsqlParameter("main_level", DbType.String) { Value = main_level });
        }
        command.Parameters.Add(new NpgsqlParameter("device_type", DbType.String) { Value = device_type });
        command.Parameters.Add(new NpgsqlParameter("guid", DbType.String) { Value = guid });
        command.ExecuteNonQueryAsync().Wait();
      }
    }
    catch (Exception ex)
    {
      Debug.Log("ChangeOwnerName error... " + DateTime.Now + " " + ex.ToString());
    } // ログ失敗時は、そのまま進む
  }

  public void UpdateOwner(string main_event, string sub_event, string current_field, string main_level)
  {
    Debug.Log("UpdateOwner(S)");
    if (One.CONF.SupportLog == false) { Debug.Log("Support Log false"); return; }
    if (One.SQL == null) { Debug.Log("SQL null"); return; }

    try
    {
      //Debug.Log("UpdateOwner(S) " + DateTime.Now);
      string name = One.CONF.Account;

      using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
      {
        //Debug.Log("UpdateOwner timeout: " + con.ConnectionTimeout);
        con.OpenAsync().Wait();
        DateTime update_time = DateTime.Now;
        string updateCommand = @"update " + TABLE_OWNER_DATA + " set update_time = :update_time";
        if (main_event != string.Empty)
        {
          updateCommand += ", main_event = :main_event";
        }
        if (sub_event != string.Empty)
        {
          updateCommand += ", sub_event = :sub_event";
        }
        if (current_field != string.Empty)
        {
          updateCommand += ", current_field = :current_field";
        }
        if (main_level != string.Empty)
        {
          updateCommand += ", main_level = :main_level";
        }
        string device_type = Application.platform.ToString();
        updateCommand += ", device_type = :device_type";
        updateCommand += " where name = :name";

        NpgsqlCommand command = new NpgsqlCommand(updateCommand, con);
        command.Parameters.Add(new NpgsqlParameter("name", DbType.String) { Value = name });
        command.Parameters.Add(new NpgsqlParameter("update_time", NpgsqlDbType.Timestamp) { Value = update_time }); // Fix-Issue ( DbType.DateTime is incorrect )
        if (main_event != string.Empty)
        {
          command.Parameters.Add(new NpgsqlParameter("main_event", DbType.String) { Value = main_event });
        }
        if (sub_event != string.Empty)
        {
          command.Parameters.Add(new NpgsqlParameter("sub_event", DbType.String) { Value = sub_event });
        }
        if (current_field != string.Empty)
        {
          command.Parameters.Add(new NpgsqlParameter("current_field", DbType.String) { Value = current_field });
        }
        if (main_level != string.Empty)
        {
          command.Parameters.Add(new NpgsqlParameter("main_level", DbType.String) { Value = main_level });
        }
        command.Parameters.Add(new NpgsqlParameter("device_type", DbType.String) { Value = device_type });
        command.ExecuteNonQuery();
        Debug.Log("UpdateOwner(E)");
      }
    }
    catch (Exception ex)
    {
      Debug.Log("UpdateOwner error... " + DateTime.Now + " " + ex.ToString());
    } // ログ失敗時は、そのまま進む
  }

  public void UpdateCharacter()
  {
    // if (GroundOne.SupportLog == false) { return; }
    if (One.SQL == null) { return; }

    //try
    //{
    //  string name = GroundOne.WE2.Account;
    //  string main_level = String.Empty;
    //  string guid = String.Empty;

    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    con.OpenAsync().Wait();
    //    NpgsqlCommand cmd = new NpgsqlCommand(@"select guid from " + TABLE_OWNER_DATA + " where name = '" + GroundOne.WE2.Account + "'", con);
    //    var dataReader = cmd.ExecuteReaderAsync();
    //    while (dataReader.Result.Read())
    //    {
    //      guid += dataReader.Result[0].ToString();
    //    }
    //  }

    //  if (guid == String.Empty)
    //  {
    //    return;
    //  }

    //  string count = String.Empty;
    //  string table = TABLE_CHARACTER;
    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    con.OpenAsync().Wait();
    //    NpgsqlCommand cmd = new NpgsqlCommand(@"select count(*) from " + table + " where guid = '" + guid + "'", con);
    //    var dataReader = cmd.ExecuteReaderAsync();
    //    while (dataReader.Result.Read())
    //    {
    //      count += dataReader.Result[0].ToString();
    //    }
    //  }

    //  DateTime last_update = DateTime.Now;
    //  if (count.ToString() == "0")
    //  {
    //    using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //    {
    //      con.OpenAsync().Wait();
    //      string sqlCmd = "INSERT INTO " + table + " ( guid, last_update ) VALUES ( :guid, :last_update )";
    //      var cmd = new NpgsqlCommand(sqlCmd, con);
    //      //cmd.Prepare();
    //      cmd.Parameters.Add(new NpgsqlParameter("guid", NpgsqlDbType.Varchar) { Value = guid });
    //      cmd.Parameters.Add(new NpgsqlParameter("last_update", NpgsqlDbType.Timestamp) { Value = last_update });
    //      cmd.ExecuteNonQueryAsync().Wait();
    //    }
    //  }

    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    con.OpenAsync().Wait();
    //    DateTime update_time = DateTime.Now;
    //    List<string> valueData = new List<string>();
    //    List<string> parameter = new List<string>();
    //    string updateCommand = @"update " + table + " set available_second = :available_second, available_third = :available_third";
    //    parameter.Add("available_second");
    //    parameter.Add("available_third");
    //    if (GroundOne.WE.AvailableSecondCharacter) { valueData.Add("true"); }
    //    else { valueData.Add("false"); }
    //    if (GroundOne.WE.AvailableThirdCharacter) { valueData.Add("true"); }
    //    else { valueData.Add("false"); }

    //    string[] list1 = { "first_name", "first_level", "first_strength", "first_agility", "first_intelligence", "first_stamina", "first_mind",
    //                                   "first_mainweapon", "first_subweapon", "first_armor", "first_accessory1", "first_accessory2",
    //                                 };
    //    if (GroundOne.MC != null)
    //    {
    //      for (int ii = 0; ii < list1.Length; ii++)
    //      {
    //        parameter.Add(list1[ii]);
    //      }
    //      for (int ii = 0; ii < list1.Length; ii++)
    //      {
    //        updateCommand += ",";
    //        updateCommand += " " + list1[ii] + " = :" + list1[ii];
    //      }

    //      valueData.Add(GroundOne.MC.FullName);
    //      valueData.Add(GroundOne.MC.Level.ToString());
    //      valueData.Add(GroundOne.MC.Strength.ToString());
    //      valueData.Add(GroundOne.MC.Agility.ToString());
    //      valueData.Add(GroundOne.MC.Intelligence.ToString());
    //      valueData.Add(GroundOne.MC.Stamina.ToString());
    //      valueData.Add(GroundOne.MC.Mind.ToString());
    //      if (GroundOne.MC.MainWeapon == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.MC.MainWeapon.Name); }
    //      if (GroundOne.MC.SubWeapon == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.MC.SubWeapon.Name); }
    //      if (GroundOne.MC.MainArmor == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.MC.MainArmor.Name); }
    //      if (GroundOne.MC.Accessory == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.MC.Accessory.Name); }
    //      if (GroundOne.MC.Accessory2 == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.MC.Accessory2.Name); }
    //    }

    //    string[] list2 = { "second_name", "second_level", "second_strength", "second_agility", "second_intelligence", "second_stamina", "second_mind",
    //                                  "second_mainweapon", "second_subweapon", "second_armor", "second_accessory1", "second_accessory2",
    //                                 };
    //    if (GroundOne.SC != null)
    //    {
    //      for (int ii = 0; ii < list2.Length; ii++)
    //      {
    //        parameter.Add(list2[ii]);
    //      }
    //      for (int ii = 0; ii < list2.Length; ii++)
    //      {
    //        updateCommand += ",";
    //        updateCommand += " " + list2[ii] + " = :" + list2[ii];
    //      }
    //      valueData.Add(GroundOne.SC.FullName);
    //      valueData.Add(GroundOne.SC.Level.ToString());
    //      valueData.Add(GroundOne.SC.Strength.ToString());
    //      valueData.Add(GroundOne.SC.Agility.ToString());
    //      valueData.Add(GroundOne.SC.Intelligence.ToString());
    //      valueData.Add(GroundOne.SC.Stamina.ToString());
    //      valueData.Add(GroundOne.SC.Mind.ToString());
    //      if (GroundOne.SC.MainWeapon == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.SC.MainWeapon.Name); }
    //      if (GroundOne.SC.SubWeapon == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.SC.SubWeapon.Name); }
    //      if (GroundOne.SC.MainArmor == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.SC.MainArmor.Name); }
    //      if (GroundOne.SC.Accessory == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.SC.Accessory.Name); }
    //      if (GroundOne.SC.Accessory2 == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.SC.Accessory2.Name); }
    //    }
    //    string[] list3 = { "third_name", "third_level", "third_strength", "third_agility", "third_intelligence", "third_stamina", "third_mind",
    //                                   "third_mainweapon", "third_subweapon", "third_armor", "third_accessory1", "third_accessory2",
    //                                 };
    //    if (GroundOne.TC != null)
    //    {
    //      for (int ii = 0; ii < list3.Length; ii++)
    //      {
    //        parameter.Add(list3[ii]);
    //      }

    //      for (int ii = 0; ii < list3.Length; ii++)
    //      {
    //        updateCommand += ",";
    //        updateCommand += " " + list3[ii] + " = :" + list3[ii];
    //      }
    //      valueData.Add(GroundOne.TC.FullName);
    //      valueData.Add(GroundOne.TC.Level.ToString());
    //      valueData.Add(GroundOne.TC.Strength.ToString());
    //      valueData.Add(GroundOne.TC.Agility.ToString());
    //      valueData.Add(GroundOne.TC.Intelligence.ToString());
    //      valueData.Add(GroundOne.TC.Stamina.ToString());
    //      valueData.Add(GroundOne.TC.Mind.ToString());
    //      if (GroundOne.TC.MainWeapon == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.TC.MainWeapon.Name); }
    //      if (GroundOne.TC.SubWeapon == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.TC.SubWeapon.Name); }
    //      if (GroundOne.TC.MainArmor == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.TC.MainArmor.Name); }
    //      if (GroundOne.TC.Accessory == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.TC.Accessory.Name); }
    //      if (GroundOne.TC.Accessory2 == null) { valueData.Add("( no item )"); }
    //      else { valueData.Add(GroundOne.TC.Accessory2.Name); }
    //    }
    //    updateCommand += ", last_update = :last_update";
    //    updateCommand += " where guid = :guid";

    //    NpgsqlCommand command = new NpgsqlCommand(updateCommand, con);
    //    for (int ii = 0; ii < parameter.Count; ii++)
    //    {
    //      command.Parameters.Add(new NpgsqlParameter(parameter[ii], NpgsqlDbType.Varchar) { Value = valueData[ii] });
    //    }
    //    command.Parameters.Add(new NpgsqlParameter("last_update", NpgsqlDbType.Timestamp) { Value = last_update }); // Fix-issue ( DbType.DateTime is incorrect )
    //    command.Parameters.Add(new NpgsqlParameter("guid", DbType.String) { Value = guid });
    //    command.ExecuteNonQueryAsync().Wait();
    //  }
    //}
    //catch (Exception ex)
    //{
    //  Debug.Log("UpdateCharacter error... " + DateTime.Now + ": " + ex.ToString());
    //} // ログ失敗時は、そのまま進む
  }

  private void UpdateArchiveData(string table, string archive_name)
  {
    // if (GroundOne.SupportLog == false) { return; }
    if (One.SQL == null) { return; }

    //try
    //{
    //  string guid = String.Empty;

    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    Debug.Log("UpdateArchiveData timeout: " + con.ConnectionTimeout);
    //    con.OpenAsync().Wait();
    //    NpgsqlCommand cmd = new NpgsqlCommand(@"select guid from " + TABLE_OWNER_DATA + " where name = '" + GroundOne.WE2.Account + "'", con);
    //    var dataReader = cmd.ExecuteReaderAsync();
    //    while (dataReader.Result.Read())
    //    {
    //      guid += dataReader.Result[0].ToString();
    //    }
    //  }

    //  if (guid == String.Empty)
    //  {
    //    return;
    //  }

    //  string count = String.Empty;
    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    con.OpenAsync().Wait();
    //    NpgsqlCommand cmd = new NpgsqlCommand(@"select count(*) from " + table + " where guid = '" + guid + "'", con);
    //    var dataReader = cmd.ExecuteReaderAsync();
    //    while (dataReader.Result.Read())
    //    {
    //      count += dataReader.Result[0].ToString();
    //    }
    //  }

    //  DateTime update_time = DateTime.Now;
    //  if (count.ToString() == "0")
    //  {
    //    using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //    {
    //      con.OpenAsync().Wait();
    //      string sqlCmd = "INSERT INTO " + table + " ( guid, " + archive_name + " ) VALUES ( :guid, :" + archive_name + " )";
    //      var cmd = new NpgsqlCommand(sqlCmd, con);
    //      //cmd.Prepare();
    //      cmd.Parameters.Add(new NpgsqlParameter("guid", NpgsqlDbType.Varchar) { Value = guid });
    //      cmd.Parameters.Add(new NpgsqlParameter(archive_name, NpgsqlDbType.Timestamp) { Value = update_time });
    //      cmd.ExecuteNonQueryAsync().Wait();
    //    }
    //  }
    //  else
    //  {
    //    string currentValue = String.Empty;
    //    using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //    {
    //      con.OpenAsync().Wait();
    //      NpgsqlCommand cmd = new NpgsqlCommand(@"select " + archive_name + " from " + table + " where guid = '" + guid + "'", con);
    //      var dataReader = cmd.ExecuteReaderAsync();
    //      while (dataReader.Result.Read())
    //      {
    //        currentValue += dataReader.Result[0].ToString();
    //      }
    //    }

    //    if (currentValue == String.Empty)
    //    {
    //      using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //      {
    //        con.OpenAsync().Wait();
    //        string updateCommand = @"update " + table + " set " + archive_name + " = :" + archive_name + " where guid = :guid";
    //        NpgsqlCommand command = new NpgsqlCommand(updateCommand, con);
    //        command.Parameters.Add(new NpgsqlParameter(archive_name, DbType.DateTime) { Value = update_time });
    //        command.Parameters.Add(new NpgsqlParameter("guid", DbType.String) { Value = guid });
    //        command.ExecuteNonQueryAsync().Wait();
    //      }
    //    }
    //  }
    //}
    //catch (Exception ex)
    //{
    //  Debug.Log("UpdateArchiveData error... " + DateTime.Now + " " + ex.ToString());
    //} // ログ失敗時は、そのまま進む
  }

  public void UpdaeSaveData(byte[] save_current, byte[] save_we2, string sender_text, string page_number)
  {
    //try
    //{
    //  // guidを確認
    //  string guid = String.Empty;
    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    con.OpenAsync().Wait();
    //    NpgsqlCommand cmd = new NpgsqlCommand(@"select guid from " + TABLE_OWNER_DATA + " where name = '" + GroundOne.WE2.Account + "'", con);
    //    var dataReader = cmd.ExecuteReaderAsync();
    //    while (dataReader.Result.Read())
    //    {
    //      guid += dataReader.Result[0].ToString();
    //    }
    //  }
    //  if (guid == String.Empty)
    //  {
    //    return;
    //  }

    //  // テーブルに該当GUIDの存在有無を確認
    //  string count = String.Empty;
    //  string table = TABLE_SAVE_DATA;
    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    con.OpenAsync().Wait();
    //    NpgsqlCommand cmd = new NpgsqlCommand(@"select count(*) from " + table + " where guid = '" + guid + "'", con);
    //    var dataReader = cmd.ExecuteReaderAsync();
    //    while (dataReader.Result.Read())
    //    {
    //      count += dataReader.Result[0].ToString();
    //    }
    //  }

    //  // 該当がなければ新規追加
    //  DateTime update_time = DateTime.Now;
    //  if (count.ToString() == "0")
    //  {
    //    using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //    {
    //      con.OpenAsync().Wait();
    //      string sqlCmd = "INSERT INTO " + table + " ( guid, update_time, save_current, save_we2 ) VALUES ( :guid, :update_time, :save_current, :save_we2)";
    //      var cmd = new NpgsqlCommand(sqlCmd, con);
    //      //cmd.Prepare();
    //      cmd.Parameters.Add(new NpgsqlParameter("guid", NpgsqlDbType.Varchar) { Value = guid });
    //      cmd.Parameters.Add(new NpgsqlParameter("update_time", NpgsqlDbType.Timestamp) { Value = update_time });
    //      cmd.Parameters.Add(new NpgsqlParameter("save_current", NpgsqlDbType.Bytea) { Value = save_current });
    //      cmd.Parameters.Add(new NpgsqlParameter("save_we2", NpgsqlDbType.Bytea) { Value = save_we2 });
    //      cmd.ExecuteNonQueryAsync().Wait();
    //    }
    //    return;
    //  }

    //  // 該当があれば更新する。
    //  string currentValue = String.Empty;
    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    con.OpenAsync().Wait();
    //    string updateCommand = @"update " + TABLE_SAVE_DATA + " set update_time = :update_time, save_current = :save_current, save_we2 = :save_we2 where guid = :guid";
    //    NpgsqlCommand command = new NpgsqlCommand(updateCommand, con);
    //    command.Parameters.Add(new NpgsqlParameter("update_time", NpgsqlDbType.Timestamp) { Value = update_time });
    //    command.Parameters.Add(new NpgsqlParameter("save_current", NpgsqlDbType.Bytea) { Value = save_current });
    //    command.Parameters.Add(new NpgsqlParameter("save_we2", NpgsqlDbType.Bytea) { Value = save_we2 });
    //    command.Parameters.Add(new NpgsqlParameter("guid", DbType.String) { Value = guid });
    //    command.ExecuteNonQueryAsync().Wait();
    //  }

    //  // OwnerDataを更新
    //  UpdateOwner(Database.LOG_SAVE_GAME, sender_text, page_number);

    //  // CharacterDataを更新
    //  UpdateCharacter(); // add 2024/02/07
    //}
    //catch (Exception ex)
    //{
    //  Debug.Log("UpdaeSaveData error... " + DateTime.Now + " " + ex.ToString());
    //} // ログ失敗時は、そのまま進む
  }

  public void UpdateDuel(string archive_name)
  {
    UpdateArchiveData(TABLE_DUEL, archive_name);
  }
  public void UpdateArchivement(string archive_name)
  {
    UpdateArchiveData(TABLE_ARCHIVEMENT, archive_name);
  }

  public void CreateOwner(string name, System.Guid guid)
  {
    // if (GroundOne.SupportLog == false) { return; }

    try
    {
      if (name == String.Empty)
      {
        name = guid.ToString();
      }

      DateTime create_time = DateTime.Now;
      string device_type = Application.platform.ToString();
      using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
      {
        Debug.Log("CreateOwner timeout: " + con.ConnectionTimeout);
        con.OpenAsync().Wait();
        string sqlCmd = "INSERT INTO " + TABLE_OWNER_DATA + " ( name, guid, create_time, device_type ) VALUES ( :name, :guid, :create_time, :device_type )";
        var cmd = new NpgsqlCommand(sqlCmd, con);
        //cmd.Prepare();
        cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlDbType.Varchar) { Value = name });
        cmd.Parameters.Add(new NpgsqlParameter("guid", NpgsqlDbType.Varchar) { Value = guid.ToString() }); // Fix-issue ( guid(direct) is incorrect )
        cmd.Parameters.Add(new NpgsqlParameter("create_time", NpgsqlDbType.Timestamp) { Value = create_time });
        cmd.Parameters.Add(new NpgsqlParameter("device_type", DbType.String) { Value = device_type });
        cmd.ExecuteNonQueryAsync().Wait();
      }
    }
    catch (Exception ex)
    {
      Debug.Log("CreateOwner error... " + DateTime.Now + " " + ex.ToString());
    } // ログ失敗時は、そのまま進む
  }

  public void CreateArData(string account)
  {
    if (One.CONF.SupportLog == false) { return; }
    try
    {
      string guid = String.Empty;
      using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
      {
        con.OpenAsync().Wait();

        NpgsqlCommand cmd = new NpgsqlCommand(@"select guid from " + TABLE_OWNER_DATA + " where name = '" + account + "'", con);
        var dataReader = cmd.ExecuteReaderAsync();
        while (dataReader.Result.Read())
        {
          guid += dataReader.Result[0].ToString();
        }
      }
      if (guid == String.Empty)
      {
        return;
      }

      bool newCreate = true;
      using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
      {
        con.OpenAsync().Wait();

        NpgsqlCommand cmd = new NpgsqlCommand(@"select guid from " + TABLE_AR_DATA + " where guid = '" + guid + "'", con);
        var dataReader = cmd.ExecuteReaderAsync();
        while (dataReader.Result.Read())
        {
          newCreate = false;
          break;
        }
      }

      if (newCreate)
      {
        using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
        {
          con.OpenAsync().Wait();
          string sqlCmd = "INSERT INTO " + TABLE_AR_DATA + " ( guid, enter_seeker_mode, leave_seeker_mode, normal_ending, true_ending, record_earring_of_lana, equip_available_11, equip_available_12, equip_available_13, equip_available_21, equip_available_22, equip_available_23, equip_available_24, equip_available_31, equip_available_32, equip_available_33, equip_available_34, equip_available_41, equip_available_42, equip_available_43, equip_available_44, equip_available_51, equip_available_52, equip_available_53, equip_available_54, potion_available_11, potion_available_12, potion_available_13, potion_available_21, potion_available_22, potion_available_23, potion_available_24, potion_available_31, potion_available_32, potion_available_33, potion_available_34, potion_available_41, potion_available_42, potion_available_43, potion_available_44, potion_available_51, potion_available_52, potion_available_53, potion_available_54, food_available_11, food_available_12, food_available_13, food_available_21, food_available_22, food_available_23, food_available_31, food_available_32, food_available_33, food_available_41, food_available_42, food_available_43, food_available_51, food_available_52, food_available_53, equip_mixture_day_11, equip_mixture_day_12, equip_mixture_day_13, equip_mixture_day_21, equip_mixture_day_22, equip_mixture_day_23, equip_mixture_day_24, equip_mixture_day_31, equip_mixture_day_32, equip_mixture_day_33, equip_mixture_day_34, equip_mixture_day_41, equip_mixture_day_42, equip_mixture_day_43, equip_mixture_day_44, equip_mixture_day_51, equip_mixture_day_52, equip_mixture_day_53, equip_mixture_day_54, potion_mixture_day_11, potion_mixture_day_12, potion_mixture_day_13, potion_mixture_day_21, potion_mixture_day_22, potion_mixture_day_23, potion_mixture_day_24, potion_mixture_day_31, potion_mixture_day_32, potion_mixture_day_33, potion_mixture_day_34, potion_mixture_day_41, potion_mixture_day_42, potion_mixture_day_43, potion_mixture_day_44, potion_mixture_day_51, potion_mixture_day_52, potion_mixture_day_53, potion_mixture_day_54, food_mixture_day_11, food_mixture_day_12, food_mixture_day_13, food_mixture_day_21, food_mixture_day_22, food_mixture_day_23, food_mixture_day_31, food_mixture_day_32, food_mixture_day_33, food_mixture_day_41, food_mixture_day_42, food_mixture_day_43, food_mixture_day_51, food_mixture_day_52, food_mixture_day_53, equip_material_11, equip_material_12, equip_material_13, equip_material_14, equip_material_15, equip_material_16, equip_material_21, equip_material_22, equip_material_23, equip_material_24, equip_material_25, equip_material_26, equip_material_27, equip_material_28, equip_material_31, equip_material_32, equip_material_33, equip_material_34, equip_material_35, equip_material_36, equip_material_37, equip_material_38, equip_material_41, equip_material_42, equip_material_43, equip_material_44, equip_material_45, equip_material_46, equip_material_47, equip_material_48, equip_material_49, equip_material_410, equip_material_411, equip_material_412, equip_material_413, equip_material_51, equip_material_52, equip_material_53, equip_material_54, equip_material_55, equip_material_56, equip_material_57, equip_material_58, equip_material_59, equip_material_510, equip_material_511, equip_material_512, equip_material_513, potion_material_11, potion_material_12, potion_material_13, potion_material_14, potion_material_15, potion_material_16, potion_material_21, potion_material_22, potion_material_23, potion_material_24, potion_material_25, potion_material_26, potion_material_27, potion_material_28, potion_material_31, potion_material_32, potion_material_33, potion_material_34, potion_material_35, potion_material_36, potion_material_37, potion_material_38, potion_material_41, potion_material_42, potion_material_43, potion_material_44, potion_material_45, potion_material_46, potion_material_47, potion_material_48, potion_material_49, potion_material_410, potion_material_411, potion_material_412, potion_material_51, potion_material_52, potion_material_53, potion_material_54, potion_material_55, potion_material_56, potion_material_57, potion_material_58, potion_material_59, potion_material_510, potion_material_511, potion_material_512, potion_material_513, food_material_11, food_material_12, food_material_13, food_material_14, food_material_15, food_material_16, food_material_21, food_material_22, food_material_23, food_material_24, food_material_25, food_material_26, food_material_31, food_material_32, food_material_33, food_material_34, food_material_35, food_material_36, food_material_41, food_material_42, food_material_43, food_material_44, food_material_45, food_material_46, food_material_51, food_material_52, food_material_53, food_material_54, food_material_55, food_material_56, food_material_57, food_material_58, food_material_59, party_join_eone_fulnea, party_join_billy_raki, party_join_adel_brigandy, inscribe_obsidian_stone_1, inscribe_obsidian_stone_2, inscribe_obsidian_stone_3, inscribe_obsidian_stone_4, inscribe_obsidian_stone_5, inscribe_obsidian_stone_6, velgus_chant_sequence_1, velgus_chant_sequence_2, velgus_chant_sequence_3, velgus_chant_sequence_4, velgus_chant_sequence_5, velgus_chant_sequence_6, velgus_chant_sequence_7, velgus_chant_sequence_8, velgus_chant_sequence_9, velgus_chant_sequence_10, velgus_chant_sequence_11, velgus_chant_sequence_12, velgus_chant_sequence_13, velgus_chant_sequence_14, velgus_chant_sequence_15, velgus_chant_sequence_16, velgus_chant_achivement, edelgarzen_mirror_sequence_1, edelgarzen_mirror_sequence_2, edelgarzen_mirror_sequence_3, edelgarzen_mirror_sequence_4, edelgarzen_mirror_sequence_5, edelgarzen_mirror_sequence_6, edelgarzen_mirror_sequence_7, edelgarzen_mirror_sequence_8, edelgarzen_mirror_sequence_9, edelgarzen_mirror_sequence_10, edelgarzen_mirror_sequence_11, edelgarzen_mirror_sequence_12, edelgarzen_mirror_sequence_13, edelgarzen_mirror_sequence_14, edelgarzen_mirror_sequence_15, edelgarzen_mirror_sequence_a, edelgarzen_mirror_sequence_b, edelgarzen_mirror_sequence_c, edelgarzen_mirror_final_a, edelgarzen_mirror_final_b, edelgarzen_mirror_final_c, edelgarzen_holy_answer, edelgarzen_fool_answer, velgus_badend_genesis_gate )" +
            " VALUES ( :guid, :enter_seeker_mode, :leave_seeker_mode, :normal_ending, :true_ending, :record_earring_of_lana, :equip_available_11, :equip_available_12, :equip_available_13, :equip_available_21, :equip_available_22, :equip_available_23, :equip_available_24, :equip_available_31, :equip_available_32, :equip_available_33, :equip_available_34, :equip_available_41, :equip_available_42, :equip_available_43, :equip_available_44, :equip_available_51, :equip_available_52, :equip_available_53, :equip_available_54, :potion_available_11, :potion_available_12, :potion_available_13, :potion_available_21, :potion_available_22, :potion_available_23, :potion_available_24, :potion_available_31, :potion_available_32, :potion_available_33, :potion_available_34, :potion_available_41, :potion_available_42, :potion_available_43, :potion_available_44, :potion_available_51, :potion_available_52, :potion_available_53, :potion_available_54, :food_available_11, :food_available_12, :food_available_13, :food_available_21, :food_available_22, :food_available_23, :food_available_31, :food_available_32, :food_available_33, :food_available_41, :food_available_42, :food_available_43, :food_available_51, :food_available_52, :food_available_53, :equip_mixture_day_11, :equip_mixture_day_12, :equip_mixture_day_13, :equip_mixture_day_21, :equip_mixture_day_22, :equip_mixture_day_23, :equip_mixture_day_24, :equip_mixture_day_31, :equip_mixture_day_32, :equip_mixture_day_33, :equip_mixture_day_34, :equip_mixture_day_41, :equip_mixture_day_42, :equip_mixture_day_43, :equip_mixture_day_44, :equip_mixture_day_51, :equip_mixture_day_52, :equip_mixture_day_53, :equip_mixture_day_54, :potion_mixture_day_11, :potion_mixture_day_12, :potion_mixture_day_13, :potion_mixture_day_21, :potion_mixture_day_22, :potion_mixture_day_23, :potion_mixture_day_24, :potion_mixture_day_31, :potion_mixture_day_32, :potion_mixture_day_33, :potion_mixture_day_34, :potion_mixture_day_41, :potion_mixture_day_42, :potion_mixture_day_43, :potion_mixture_day_44, :potion_mixture_day_51, :potion_mixture_day_52, :potion_mixture_day_53, :potion_mixture_day_54, :food_mixture_day_11, :food_mixture_day_12, :food_mixture_day_13, :food_mixture_day_21, :food_mixture_day_22, :food_mixture_day_23, :food_mixture_day_31, :food_mixture_day_32, :food_mixture_day_33, :food_mixture_day_41, :food_mixture_day_42, :food_mixture_day_43, :food_mixture_day_51, :food_mixture_day_52, :food_mixture_day_53, :equip_material_11, :equip_material_12, :equip_material_13, :equip_material_14, :equip_material_15, :equip_material_16, :equip_material_21, :equip_material_22, :equip_material_23, :equip_material_24, :equip_material_25, :equip_material_26, :equip_material_27, :equip_material_28, :equip_material_31, :equip_material_32, :equip_material_33, :equip_material_34, :equip_material_35, :equip_material_36, :equip_material_37, :equip_material_38, :equip_material_41, :equip_material_42, :equip_material_43, :equip_material_44, :equip_material_45, :equip_material_46, :equip_material_47, :equip_material_48, :equip_material_49, :equip_material_410, :equip_material_411, :equip_material_412, :equip_material_413, :equip_material_51, :equip_material_52, :equip_material_53, :equip_material_54, :equip_material_55, :equip_material_56, :equip_material_57, :equip_material_58, :equip_material_59, :equip_material_510, :equip_material_511, :equip_material_512, :equip_material_513, :potion_material_11, :potion_material_12, :potion_material_13, :potion_material_14, :potion_material_15, :potion_material_16, :potion_material_21, :potion_material_22, :potion_material_23, :potion_material_24, :potion_material_25, :potion_material_26, :potion_material_27, :potion_material_28, :potion_material_31, :potion_material_32, :potion_material_33, :potion_material_34, :potion_material_35, :potion_material_36, :potion_material_37, :potion_material_38, :potion_material_41, :potion_material_42, :potion_material_43, :potion_material_44, :potion_material_45, :potion_material_46, :potion_material_47, :potion_material_48, :potion_material_49, :potion_material_410, :potion_material_411, :potion_material_412, :potion_material_51, :potion_material_52, :potion_material_53, :potion_material_54, :potion_material_55, :potion_material_56, :potion_material_57, :potion_material_58, :potion_material_59, :potion_material_510, :potion_material_511, :potion_material_512, :potion_material_513, :food_material_11, :food_material_12, :food_material_13, :food_material_14, :food_material_15, :food_material_16, :food_material_21, :food_material_22, :food_material_23, :food_material_24, :food_material_25, :food_material_26, :food_material_31, :food_material_32, :food_material_33, :food_material_34, :food_material_35, :food_material_36, :food_material_41, :food_material_42, :food_material_43, :food_material_44, :food_material_45, :food_material_46, :food_material_51, :food_material_52, :food_material_53, :food_material_54, :food_material_55, :food_material_56, :food_material_57, :food_material_58, :food_material_59, :party_join_eone_fulnea, :party_join_billy_raki, :party_join_adel_brigandy, :inscribe_obsidian_stone_1, :inscribe_obsidian_stone_2, :inscribe_obsidian_stone_3, :inscribe_obsidian_stone_4, :inscribe_obsidian_stone_5, :inscribe_obsidian_stone_6, :velgus_chant_sequence_1, :velgus_chant_sequence_2, :velgus_chant_sequence_3, :velgus_chant_sequence_4, :velgus_chant_sequence_5, :velgus_chant_sequence_6, :velgus_chant_sequence_7, :velgus_chant_sequence_8, :velgus_chant_sequence_9, :velgus_chant_sequence_10, :velgus_chant_sequence_11, :velgus_chant_sequence_12, :velgus_chant_sequence_13, :velgus_chant_sequence_14, :velgus_chant_sequence_15, :velgus_chant_sequence_16, :velgus_chant_achivement, :edelgarzen_mirror_sequence_1, :edelgarzen_mirror_sequence_2, :edelgarzen_mirror_sequence_3, :edelgarzen_mirror_sequence_4, :edelgarzen_mirror_sequence_5, :edelgarzen_mirror_sequence_6, :edelgarzen_mirror_sequence_7, :edelgarzen_mirror_sequence_8, :edelgarzen_mirror_sequence_9, :edelgarzen_mirror_sequence_10, :edelgarzen_mirror_sequence_11, :edelgarzen_mirror_sequence_12, :edelgarzen_mirror_sequence_13, :edelgarzen_mirror_sequence_14, :edelgarzen_mirror_sequence_15, :edelgarzen_mirror_sequence_a, :edelgarzen_mirror_sequence_b, :edelgarzen_mirror_sequence_c, :edelgarzen_mirror_final_a, :edelgarzen_mirror_final_b, :edelgarzen_mirror_final_c, :edelgarzen_holy_answer, :edelgarzen_fool_answer, :velgus_badend_genesis_gate )";
          var cmd = new NpgsqlCommand(sqlCmd, con);
          //cmd.Prepare();
          cmd.Parameters.Add(new NpgsqlParameter("guid", NpgsqlDbType.Varchar) { Value = guid });
          cmd.Parameters.Add(new NpgsqlParameter("enter_seeker_mode", NpgsqlDbType.Boolean) { Value = One.AR.EnterSeekerMode });
          cmd.Parameters.Add(new NpgsqlParameter("leave_seeker_mode", NpgsqlDbType.Boolean) { Value = One.AR.LeaveSeekerMode });
          cmd.Parameters.Add(new NpgsqlParameter("normal_ending", NpgsqlDbType.Boolean) { Value = One.AR.NormalEnding });
          cmd.Parameters.Add(new NpgsqlParameter("true_ending", NpgsqlDbType.Boolean) { Value = One.AR.TrueEnding });
          cmd.Parameters.Add(new NpgsqlParameter("record_earring_of_lana", NpgsqlDbType.Boolean) { Value = One.AR.Record_EarringOfLana });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_11", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_11 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_12", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_12 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_13", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_13 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_21", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_21 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_22", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_22 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_23", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_23 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_24", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_24 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_31", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_31 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_32", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_32 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_33", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_33 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_34", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_34 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_41", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_41 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_42", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_42 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_43", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_43 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_44", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_44 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_51", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_51 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_52", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_52 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_53", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_53 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_available_54", NpgsqlDbType.Boolean) { Value = One.AR.EquipAvailable_54 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_11", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_11 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_12", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_12 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_13", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_13 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_21", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_21 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_22", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_22 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_23", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_23 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_24", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_24 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_31", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_31 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_32", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_32 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_33", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_33 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_34", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_34 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_41", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_41 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_42", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_42 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_43", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_43 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_44", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_44 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_51", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_51 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_52", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_52 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_53", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_53 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_available_54", NpgsqlDbType.Boolean) { Value = One.AR.PotionAvailable_54 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_11", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_11 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_12", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_12 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_13", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_13 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_21", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_21 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_22", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_22 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_23", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_23 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_31", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_31 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_32", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_32 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_33", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_33 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_41", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_41 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_42", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_42 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_43", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_43 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_51", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_51 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_52", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_52 });
          cmd.Parameters.Add(new NpgsqlParameter("food_available_53", NpgsqlDbType.Boolean) { Value = One.AR.FoodAvailable_53 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_11", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_11 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_12", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_12 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_13", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_13 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_21", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_21 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_22", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_22 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_23", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_23 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_24", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_24 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_31", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_31 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_32", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_32 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_33", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_33 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_34", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_34 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_41", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_41 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_42", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_42 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_43", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_43 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_44", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_44 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_51", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_51 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_52", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_52 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_53", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_53 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_mixture_day_54", NpgsqlDbType.Integer) { Value = One.AR.EquipMixtureDay_54 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_11", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_11 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_12", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_12 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_13", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_13 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_21", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_21 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_22", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_22 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_23", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_23 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_24", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_24 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_31", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_31 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_32", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_32 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_33", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_33 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_34", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_34 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_41", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_41 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_42", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_42 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_43", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_43 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_44", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_44 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_51", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_51 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_52", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_52 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_53", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_53 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_mixture_day_54", NpgsqlDbType.Integer) { Value = One.AR.PotionMixtureDay_54 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_11", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_11 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_12", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_12 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_13", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_13 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_21", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_21 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_22", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_22 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_23", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_23 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_31", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_31 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_32", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_32 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_33", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_33 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_41", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_41 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_42", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_42 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_43", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_43 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_51", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_51 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_52", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_52 });
          cmd.Parameters.Add(new NpgsqlParameter("food_mixture_day_53", NpgsqlDbType.Integer) { Value = One.AR.FoodMixtureDay_53 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_11", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_11 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_12", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_12 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_13", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_13 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_14", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_14 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_15", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_15 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_16", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_16 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_21", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_21 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_22", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_22 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_23", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_23 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_24", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_24 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_25", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_25 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_26", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_26 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_27", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_27 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_28", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_28 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_31", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_31 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_32", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_32 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_33", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_33 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_34", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_34 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_35", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_35 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_36", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_36 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_37", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_37 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_38", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_38 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_41", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_41 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_42", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_42 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_43", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_43 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_44", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_44 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_45", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_45 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_46", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_46 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_47", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_47 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_48", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_48 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_49", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_49 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_410", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_410 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_411", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_411 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_412", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_412 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_413", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_413 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_51", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_51 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_52", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_52 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_53", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_53 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_54", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_54 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_55", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_55 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_56", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_56 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_57", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_57 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_58", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_58 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_59", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_59 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_510", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_510 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_511", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_511 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_512", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_512 });
          cmd.Parameters.Add(new NpgsqlParameter("equip_material_513", NpgsqlDbType.Integer) { Value = One.AR.EquipMaterial_513 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_11", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_11 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_12", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_12 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_13", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_13 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_14", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_14 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_15", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_15 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_16", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_16 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_21", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_21 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_22", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_22 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_23", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_23 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_24", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_24 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_25", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_25 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_26", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_26 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_27", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_27 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_28", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_28 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_31", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_31 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_32", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_32 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_33", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_33 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_34", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_34 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_35", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_35 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_36", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_36 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_37", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_37 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_38", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_38 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_41", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_41 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_42", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_42 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_43", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_43 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_44", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_44 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_45", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_45 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_46", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_46 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_47", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_47 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_48", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_48 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_49", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_49 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_410", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_410 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_411", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_411 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_412", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_412 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_51", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_51 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_52", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_52 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_53", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_53 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_54", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_54 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_55", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_55 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_56", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_56 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_57", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_57 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_58", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_58 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_59", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_59 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_510", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_510 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_511", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_511 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_512", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_512 });
          cmd.Parameters.Add(new NpgsqlParameter("potion_material_513", NpgsqlDbType.Integer) { Value = One.AR.PotionMaterial_513 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_11", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_11 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_12", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_12 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_13", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_13 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_14", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_14 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_15", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_15 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_16", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_16 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_21", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_21 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_22", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_22 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_23", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_23 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_24", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_24 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_25", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_25 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_26", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_26 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_31", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_31 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_32", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_32 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_33", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_33 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_34", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_34 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_35", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_35 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_36", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_36 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_41", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_41 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_42", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_42 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_43", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_43 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_44", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_44 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_45", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_45 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_46", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_46 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_51", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_51 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_52", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_52 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_53", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_53 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_54", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_54 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_55", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_55 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_56", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_56 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_57", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_57 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_58", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_58 });
          cmd.Parameters.Add(new NpgsqlParameter("food_material_59", NpgsqlDbType.Integer) { Value = One.AR.FoodMaterial_59 });
          cmd.Parameters.Add(new NpgsqlParameter("party_join_eone_fulnea", NpgsqlDbType.Boolean) { Value = One.AR.PartyJoin_EoneFulnea });
          cmd.Parameters.Add(new NpgsqlParameter("party_join_billy_raki", NpgsqlDbType.Boolean) { Value = One.AR.PartyJoin_BillyRaki });
          cmd.Parameters.Add(new NpgsqlParameter("party_join_adel_brigandy", NpgsqlDbType.Boolean) { Value = One.AR.PartyJoin_AdelBrigandy });
          cmd.Parameters.Add(new NpgsqlParameter("inscribe_obsidian_stone_1", NpgsqlDbType.Boolean) { Value = One.AR.InscribeObsidianStone_1 });
          cmd.Parameters.Add(new NpgsqlParameter("inscribe_obsidian_stone_2", NpgsqlDbType.Boolean) { Value = One.AR.InscribeObsidianStone_2 });
          cmd.Parameters.Add(new NpgsqlParameter("inscribe_obsidian_stone_3", NpgsqlDbType.Boolean) { Value = One.AR.InscribeObsidianStone_3 });
          cmd.Parameters.Add(new NpgsqlParameter("inscribe_obsidian_stone_4", NpgsqlDbType.Boolean) { Value = One.AR.InscribeObsidianStone_4 });
          cmd.Parameters.Add(new NpgsqlParameter("inscribe_obsidian_stone_5", NpgsqlDbType.Boolean) { Value = One.AR.InscribeObsidianStone_5 });
          cmd.Parameters.Add(new NpgsqlParameter("inscribe_obsidian_stone_6", NpgsqlDbType.Boolean) { Value = One.AR.InscribeObsidianStone_6 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_1", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_1 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_2", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_2 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_3", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_3 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_4", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_4 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_5", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_5 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_6", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_6 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_7", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_7 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_8", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_8 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_9", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_9 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_10", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_10 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_11", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_11 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_12", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_12 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_13", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_13 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_14", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_14 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_15", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_15 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_sequence_16", NpgsqlDbType.Integer) { Value = One.AR.Velgus_Chant_Sequence_16 });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_chant_achivement", NpgsqlDbType.Boolean) { Value = One.AR.VelgusChantAchivement });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_1", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_1 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_2", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_2 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_3", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_3 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_4", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_4 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_5", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_5 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_6", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_6 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_7", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_7 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_8", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_8 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_9", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_9 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_10", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_10 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_11", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_11 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_12", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_12 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_13", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_13 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_14", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_14 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_15", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_15 });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_a", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_A });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_b", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_B });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_sequence_c", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorSequence_C });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_final_a", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorFinal_A });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_final_b", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorFinal_B });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_mirror_final_c", NpgsqlDbType.Integer) { Value = One.AR.EdelgarzenMirrorFinal_C });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_holy_answer", NpgsqlDbType.Boolean) { Value = One.AR.EdelgarzenHolyAnswer });
          cmd.Parameters.Add(new NpgsqlParameter("edelgarzen_fool_answer", NpgsqlDbType.Boolean) { Value = One.AR.EdelgarzenFoolAnswer });
          cmd.Parameters.Add(new NpgsqlParameter("velgus_badend_genesis_gate", NpgsqlDbType.Boolean) { Value = One.AR.Velgus_BadEnd_GenesisGate });

          cmd.ExecuteNonQueryAsync().Wait();
        }
      }
      else
      {
        using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
        {
          //Debug.Log("UpdateOwner timeout: " + con.ConnectionTimeout);
          con.OpenAsync().Wait();
          DateTime update_time = DateTime.Now;
          string updateCommand = @"update " + TABLE_AR_DATA + " set enter_seeker_mode = :enter_seeker_mode, leave_seeker_mode = :leave_seeker_mode, normal_ending = :normal_ending, true_ending = :true_ending";
          updateCommand += " where guid = :guid";

          NpgsqlCommand command = new NpgsqlCommand(updateCommand, con);
          command.Parameters.Add(new NpgsqlParameter("guid", DbType.String) { Value = guid });
          command.Parameters.Add(new NpgsqlParameter("enter_seeker_mode", NpgsqlDbType.Boolean) { Value = One.AR.EnterSeekerMode });
          command.Parameters.Add(new NpgsqlParameter("leave_seeker_mode", NpgsqlDbType.Boolean) { Value = One.AR.LeaveSeekerMode });
          command.Parameters.Add(new NpgsqlParameter("normal_ending", NpgsqlDbType.Boolean) { Value = One.AR.NormalEnding });
          command.Parameters.Add(new NpgsqlParameter("true_ending", NpgsqlDbType.Boolean) { Value = One.AR.TrueEnding });
          command.ExecuteNonQuery();
          Debug.Log("CreateArData(E)");
        }
      }
    }
    catch (Exception ex)
    {
      Debug.Log("CreateArData error... " + DateTime.Now + " " + ex.ToString());
    } // ログ失敗時は、そのまま進む
  }

  public bool ExistOwnerName(string name)
  {
    if (One.CONF.SupportLog == false) { return false; }
    try
    {
      string existName = String.Empty;

      using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
      {
        con.OpenAsync().Wait();
        NpgsqlCommand cmd = new NpgsqlCommand(@"select name from " + TABLE_OWNER_DATA + " where name = '" + name + "'", con);

        var dataReader = cmd.ExecuteReaderAsync();
        while (dataReader.Result.Read())
        {
          existName += dataReader.Result[0].ToString();
        }
      }

      if (existName == name)
      {
        return true;
      }
      else
      {
        return false;
      }

    }
    catch (Exception ex)
    {
      Debug.Log("ExistOwnerName error... " + DateTime.Now + " " + ex.ToString());
      return false;
    } // 取得失敗時は名前がぶつかっている可能性があるが、ひとまず通しとする。
    return false;
  }
}