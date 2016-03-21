using UnityEngine;
using System.Collections;
using System.Linq;
using System.Data.SqlClient;
using System;

public class DatabaseConnection : MonoBehaviour
{

    static string conString = "user id=dmaa0914_Spec14Games_1;" +
        "password=Marco19_heck;server=kraka.ucn.dk;" +
        "database=dmaa0914_Spec14Games_1; " +
        "connection timeout=30";
    SqlConnection con = new SqlConnection(conString);
    SqlCommand sc = null;
    SqlDataReader resultSet = null;

    void Start()
    {
    }
    
    public SqlDataReader ExecuteStringGet(string command) 
    {
        resultSet = null;

        try
        {
            con.Open();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }

        sc = new SqlCommand(command, con);
        try
        {
            resultSet = sc.ExecuteReader();
        }
        catch (SqlException e)
        {
            Debug.Log(e.ToString());
        }
            
        return resultSet;
    }

        public bool ExecuteStringPut(string command)
        {
            con.Open();

            sc = new SqlCommand(command, con);
            try
            {
                sc.ExecuteReader();
                return true;
            }
            catch (SqlException e)
            {
                Debug.Log(e.ToString());
                return false;
            }
            finally
            {
               // con.Close();
            }
        }
    
}

