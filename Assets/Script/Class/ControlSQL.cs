using System;
using System.Text;
using System.Data;
//using Npgsql;
//using NpgsqlTypes;
using UnityEngine;
using System.Collections.Generic;

public class ControlSQL : MonoBehaviour
{
  public string connection = string.Empty;

  private string TABLE_CHARACTER = "character_data";
  private string TABLE_OWNER_DATA = "owner_data";
  private string TABLE_ARCHIVEMENT = "archivement";
  private string TABLE_SAVE_DATA = "save_data";
  private string TABLE_DUEL = "duel";
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
    // if (GroundOne.SupportLog == false) { return String.Empty; }

    string table = TABLE_OWNER_DATA;
    string jsonData = String.Empty;
    //try
    //{
    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    //Debug.Log("SelectOwner timeout: " + con.ConnectionTimeout);
    //    con.OpenAsync().Wait();
    //    NpgsqlCommand cmd = new NpgsqlCommand(@"select to_json(" + table + ") from " + table + " where name = '" + name + "'", con);
    //    var dataReader = cmd.ExecuteReaderAsync();
    //    while (dataReader.Result.Read())
    //    {
    //      jsonData += dataReader.Result[0].ToString();
    //    }
    //  }
    //}
    //catch (Exception ex)
    //{
    //  Debug.Log("SelectOwner error... " + DateTime.Now + " " + ex.ToString());
    //} // ログ失敗時は、そのまま進む

    return jsonData;
  }

  public void ChangeOwnerName(string main_event, string sub_event, string current_field, string name)
  {
    // if (GroundOne.SupportLog == false) { return; }
    if (One.SQL == null) { return; }

    //try
    //{
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

    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    con.OpenAsync().Wait();

    //    DateTime update_time = DateTime.Now;
    //    string updateCommand = @"update " + TABLE_OWNER_DATA + " set update_time = :update_time";
    //    if (name != string.Empty)
    //    {
    //      updateCommand += ", name = :name";
    //    }
    //    if (main_event != string.Empty)
    //    {
    //      updateCommand += ", main_event = :main_event";
    //    }
    //    if (sub_event != string.Empty)
    //    {
    //      updateCommand += ", sub_event = :sub_event";
    //    }
    //    if (current_field != string.Empty)
    //    {
    //      updateCommand += ", current_field = :current_field";
    //    }
    //    if (main_level != string.Empty)
    //    {
    //      updateCommand += ", main_level = :main_level";
    //    }
    //    string device_type = Application.platform.ToString();
    //    updateCommand += ", device_type = :device_type";
    //    updateCommand += " where guid = :guid";

    //    NpgsqlCommand command = new NpgsqlCommand(updateCommand, con);
    //    command.Parameters.Add(new NpgsqlParameter("name", DbType.String) { Value = name });
    //    command.Parameters.Add(new NpgsqlParameter("update_time", DbType.DateTime) { Value = update_time });
    //    if (main_event != string.Empty)
    //    {
    //      command.Parameters.Add(new NpgsqlParameter("main_event", DbType.String) { Value = main_event });
    //    }
    //    if (sub_event != string.Empty)
    //    {
    //      command.Parameters.Add(new NpgsqlParameter("sub_event", DbType.String) { Value = sub_event });
    //    }
    //    if (current_field != string.Empty)
    //    {
    //      command.Parameters.Add(new NpgsqlParameter("current_field", DbType.String) { Value = current_field });
    //    }
    //    if (main_level != string.Empty)
    //    {
    //      command.Parameters.Add(new NpgsqlParameter("main_level", DbType.String) { Value = main_level });
    //    }
    //    command.Parameters.Add(new NpgsqlParameter("device_type", DbType.String) { Value = device_type });
    //    command.Parameters.Add(new NpgsqlParameter("guid", DbType.String) { Value = guid });
    //    command.ExecuteNonQueryAsync().Wait();
    //  }
    //}
    //catch (Exception ex)
    //{
    //  Debug.Log("ChangeOwnerName error... " + DateTime.Now + " " + ex.ToString());
    //} // ログ失敗時は、そのまま進む
  }

  public void UpdateOwner(string main_event, string sub_event, string current_field)
  {
    // if (GroundOne.SupportLog == false) { return; }
    if (One.SQL == null) { return; }

    //try
    //{
    //  //Debug.Log("UpdateOwner(S) " + DateTime.Now);
    //  string name = GroundOne.WE2.Account;
    //  string main_level = String.Empty;

    //  if (GroundOne.MC != null)
    //  {
    //    main_level = GroundOne.MC.Level.ToString();
    //  }

    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    //Debug.Log("UpdateOwner timeout: " + con.ConnectionTimeout);
    //    con.OpenAsync().Wait();
    //    DateTime update_time = DateTime.Now;
    //    string updateCommand = @"update " + TABLE_OWNER_DATA + " set update_time = :update_time";
    //    if (main_event != string.Empty)
    //    {
    //      updateCommand += ", main_event = :main_event";
    //    }
    //    if (sub_event != string.Empty)
    //    {
    //      updateCommand += ", sub_event = :sub_event";
    //    }
    //    if (current_field != string.Empty)
    //    {
    //      updateCommand += ", current_field = :current_field";
    //    }
    //    if (main_level != string.Empty)
    //    {
    //      updateCommand += ", main_level = :main_level";
    //    }
    //    string device_type = Application.platform.ToString();
    //    updateCommand += ", device_type = :device_type";
    //    updateCommand += " where name = :name";

    //    NpgsqlCommand command = new NpgsqlCommand(updateCommand, con);
    //    command.Parameters.Add(new NpgsqlParameter("name", DbType.String) { Value = name });
    //    command.Parameters.Add(new NpgsqlParameter("update_time", NpgsqlDbType.Timestamp) { Value = update_time }); // Fix-Issue ( DbType.DateTime is incorrect )
    //    if (main_event != string.Empty)
    //    {
    //      command.Parameters.Add(new NpgsqlParameter("main_event", DbType.String) { Value = main_event });
    //    }
    //    if (sub_event != string.Empty)
    //    {
    //      command.Parameters.Add(new NpgsqlParameter("sub_event", DbType.String) { Value = sub_event });
    //    }
    //    if (current_field != string.Empty)
    //    {
    //      command.Parameters.Add(new NpgsqlParameter("current_field", DbType.String) { Value = current_field });
    //    }
    //    if (main_level != string.Empty)
    //    {
    //      command.Parameters.Add(new NpgsqlParameter("main_level", DbType.String) { Value = main_level });
    //    }
    //    command.Parameters.Add(new NpgsqlParameter("device_type", DbType.String) { Value = device_type });
    //    command.ExecuteNonQuery();
    //  }
    //}
    //catch (Exception ex)
    //{
    //  Debug.Log("UpdateOwner error... " + DateTime.Now + " " + ex.ToString());
    //} // ログ失敗時は、そのまま進む
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

    //try
    //{
    //  if (name == String.Empty)
    //  {
    //    name = guid.ToString();
    //  }

    //  DateTime create_time = DateTime.Now;
    //  string device_type = Application.platform.ToString();
    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    Debug.Log("CreateOwner timeout: " + con.ConnectionTimeout);
    //    con.OpenAsync().Wait();
    //    string sqlCmd = "INSERT INTO " + TABLE_OWNER_DATA + " ( name, guid, create_time, device_type ) VALUES ( :name, :guid, :create_time, :device_type )";
    //    var cmd = new NpgsqlCommand(sqlCmd, con);
    //    //cmd.Prepare();
    //    cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlDbType.Varchar) { Value = name });
    //    cmd.Parameters.Add(new NpgsqlParameter("guid", NpgsqlDbType.Varchar) { Value = guid.ToString() }); // Fix-issue ( guid(direct) is incorrect )
    //    cmd.Parameters.Add(new NpgsqlParameter("create_time", NpgsqlDbType.Timestamp) { Value = create_time });
    //    cmd.Parameters.Add(new NpgsqlParameter("device_type", DbType.String) { Value = device_type });
    //    cmd.ExecuteNonQueryAsync().Wait();
    //  }
    //}
    //catch (Exception ex)
    //{
    //  Debug.Log("CreateOwner error... " + DateTime.Now + " " + ex.ToString());
    //} // ログ失敗時は、そのまま進む
  }

  public bool ExistOwnerName(string name)
  {
    // if (GroundOne.SupportLog == false) { return false; }
    //try
    //{
    //  string existName = String.Empty;

    //  using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(connection))
    //  {
    //    con.OpenAsync().Wait();
    //    NpgsqlCommand cmd = new NpgsqlCommand(@"select name from " + TABLE_OWNER_DATA + " where name = '" + name + "'", con);

    //    var dataReader = cmd.ExecuteReaderAsync();
    //    while (dataReader.Result.Read())
    //    {
    //      existName += dataReader.Result[0].ToString();
    //    }
    //  }

    //  if (existName == name)
    //  {
    //    return true;
    //  }
    //  else
    //  {
    //    return false;
    //  }

    //}
    //catch (Exception ex)
    //{
    //  Debug.Log("ExistOwnerName error... " + DateTime.Now + " " + ex.ToString());
    //  return false;
    //} // 取得失敗時は名前がぶつかっている可能性があるが、ひとまず通しとする。
    return false;
  }
}