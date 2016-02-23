using UnityEngine;
using System.Collections;
using System.Linq;
using System.Data.SqlClient;
using System;

public class DatabaseConnection : MonoBehaviour
{

    static string conString = "user id=dmaa0914_3Sem_2_Grupperum;" +
        "password=IsAllowed;server=kraka.ucn.dk;" +
        "database=dmaa0914_3Sem_2_Grupperum; " +
        "connection timeout=30";
    SqlConnection con = new SqlConnection(conString);

    
    public SqlDataReader ExecuteStringGet(string command) 
    {
        SqlDataReader resultSet = null;

        try
        {
            con.Open();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }

        SqlCommand sc = new SqlCommand(command, con);
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
            SqlConnection con = new SqlConnection(conString);

            con.Open();

            SqlCommand sc = new SqlCommand(command, con);
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

