using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
/// <summary>
/// Summary description for Class1
/// </summary>
public class ConnectAzure
{
	public SqlConnection AzureConnect ;
	public bool PublicConnection()
	{
		AzureConnect = new SqlConnection();
        AzureConnect.ConnectionString = "Server=tcp:cjvbhjdv.database.windows.net;Database=MicNewsDemo;User ID=mahesh@sjhdu.database.windows.net;Password=P@ssw0rd;Trusted_Connection=False;Encrypt=True";
        //AzureConnect.ConnectionString = "server=.;user=sa;password=spc;Trusted_Connection=false;database=MICNews;connection timeout=30";

        try
		{
			AzureConnect.Open();
			AzureConnect.Close();
			return true;
		}
		catch
		{
			return false;
		}
	}

		  public SqlConnection getConnString()
		{
			return AzureConnect;
		}

	  
	}
