//-----------------------------------------------------------------------
// Copyright (c) 2009 Navya Jammula.

// This file is part of HealthMonitoringSystem.
// HealthMonitoringSystem is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// HealthMonitoringSystem is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with HealthMonitoringSystem.  If not, see
// <http://www.gnu.org/licenses/>.
//-----------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace HealthMonitorSystem
{
	
	
	public class BaseDA
	{
		private static string connectionString = "Server=db.cecs.pdx.edu;" + "Port=5432;" + 
								"Database=jammulan;" + "User ID=jammulan;" + "Password=kr!m22Uc;";
		private static NpgsqlConnection dbcon = new Npgsql.NpgsqlConnection(connectionString);
		
				
		public static int ExecuteNonQuery(string strSql)
		{
			try
			{
				dbcon.Open();
				NpgsqlCommand cmd = new NpgsqlCommand(strSql, dbcon);
				int retVal = cmd.ExecuteNonQuery();
				return retVal;			
			}
			catch
			{
				throw;
			}
			finally
			{
				dbcon.Close();
			}
		}
		
		public static int ExecuteScalar(string strSql)
		{
			try
			{
				dbcon.Open();
				NpgsqlCommand cmd = new NpgsqlCommand(strSql, dbcon);
				Object retVal = cmd.ExecuteScalar();
				dbcon.Close();
				return Convert.ToInt32(retVal);			
			}
			catch
			{
				throw;
			}
			finally
			{
				dbcon.Close();
			}
		}
		
		public static DataSet ExecuteDataSet(string strSql)
		{			
			try
			{
				NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSql, connectionString);
				DataSet ds = new DataSet();
				da.Fill(ds); 				
				return ds;
			}
			catch
			{	
				throw;
			}
			finally
			{
				dbcon.Close();
			}
			
		}
		
		public static string Escape(string strStmt)
		{
			strStmt = strStmt.Trim();
			strStmt = strStmt.Replace("'", "''");
			return strStmt;
		}
		
	}
}
