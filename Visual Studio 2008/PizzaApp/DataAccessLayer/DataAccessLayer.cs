﻿using System;
using System.Data;
using System.Configuration;
// Nuget Install
// Install-Package System.Data.SQLite
// SQLite - net40 - 1.0.84.0
// Need to Copy x64 and x86 folders to bin
using System.Data.SQLite;

namespace PizzaApp
{
    public class DataAccessLayer
    {
        private string ConnectionString
        {
            get
            {
                ConnectionStringSettingsCollection ConnectionStringSetting = ConfigurationManager.ConnectionStrings;
                return ConnectionStringSetting["ConnectionString"].ConnectionString;
            }
        }

        public DataTable Select(string sqliteQuerySelect, SQLiteDataAdapter dataAdapterSQLite)
        {
           DataTable datTable = new DataTable();
           try
           {
               using (SQLiteConnection connectionSQLite = new SQLiteConnection(ConnectionString))
               {
                   dataAdapterSQLite.SelectCommand.CommandText = sqliteQuerySelect;
                   dataAdapterSQLite.SelectCommand.Connection = connectionSQLite;
                   connectionSQLite.Open();
                   dataAdapterSQLite.Fill(datTable);
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }
           return datTable;
        }


        public int Insert(string sqliteQueryInsert, SQLiteDataAdapter sqliteDataAdapterInsert)
        {
            int rowsAffacted = 0;
            try
            {
                using (SQLiteConnection connectionSQLite = new SQLiteConnection(ConnectionString))
                {
                    sqliteDataAdapterInsert.InsertCommand.CommandText = sqliteQueryInsert;
                    sqliteDataAdapterInsert.InsertCommand.Connection = connectionSQLite;
                    connectionSQLite.Open();
                    rowsAffacted = sqliteDataAdapterInsert.InsertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsAffacted;
        }

        public int Update(string sqliteQueryUpdate, SQLiteDataAdapter sqliteDataAdapterUpdate)
        {
            int rowsAffacted = 0;

            try
            {
                using (SQLiteConnection connectionSQLite = new SQLiteConnection(ConnectionString))
                {
                    sqliteDataAdapterUpdate.UpdateCommand.CommandText = sqliteQueryUpdate;
                    sqliteDataAdapterUpdate.UpdateCommand.Connection = connectionSQLite;
                    connectionSQLite.Open();
                    rowsAffacted = sqliteDataAdapterUpdate.UpdateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsAffacted;
        }

        public int Delete(string sqliteQueryDelete, SQLiteDataAdapter sqliteDataAdapterDelete)
        {
            int rowsAffacted = 0;

            try
            {
                using (SQLiteConnection connectionSQLite = new SQLiteConnection(ConnectionString))
                {
                    sqliteDataAdapterDelete.DeleteCommand.CommandText = sqliteQueryDelete;
                    sqliteDataAdapterDelete.DeleteCommand.Connection = connectionSQLite;
                    connectionSQLite.Open();
                    rowsAffacted = sqliteDataAdapterDelete.DeleteCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rowsAffacted;
        }       
    }
}
