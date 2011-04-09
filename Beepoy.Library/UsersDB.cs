using System;
using System.Data;
using System.Data.Common;
using Beepoy.Data.Common;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for UsersDB.
	/// </summary>
	public class UsersDB : Persistent
	{
		#region ATRIBUTOS
		
		private DbParameter param;		

		#endregion

		#region CONSTRUTORES

		public UsersDB(DBWork banco):base(banco)
		{
		
		}
		
		public UsersDB(
			DBWork banco,
			Int64 UserId
			):base(banco)
		{
			this.User = Load(UserId);
		}
		
		#endregion
		
		#region PROPRIEDADES

        public UsersModel User { get; set; }

		#endregion

		#region METODOS
				
		/// <summary>
        /// Carrega um objeto do tipo UsersDB
        /// </summary>        
        /// <returns>UsersDB</returns>
        /// <exception cref="System.Data.Common.DbException"></exception>
		public UsersModel Load(Int64 userId)
		{
			try
			{
                QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Users_LOAD", this._Banco);

				#region PARAMETROS
				
				DbParameter param = qs.NewParameter();
				param.DbType = System.Data.DbType.Boolean;
				param.ParameterName = "@status";
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);				

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Size = 8;
				param.Value = userId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@UserName";
				param.Size = 55;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Password";
				param.Size = 12;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.DateTime;
				param.ParameterName = "@DateInsert";
				param.Size = 16;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.DateTime;
				param.ParameterName = "@DateUpdate";
				param.Size = 16;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				#endregion
				
				qs.Execute();
				
				if ( Convert.ToBoolean(qs.Parameters["@status"].Value) )
				{	
					#region PARAMETROS		
												
					this.User.UserId = userId;

					if ( qs.Parameters["@UserName"].Value != DBNull.Value )
                        this.User.UserName = Convert.ToString(qs.Parameters["@UserName"].Value);

					if ( qs.Parameters["@Password"].Value != DBNull.Value )
                        this.User.Password = Convert.ToString(qs.Parameters["@Password"].Value);

					if ( qs.Parameters["@DateInsert"].Value != DBNull.Value )
                        this.User.DateInsert = Convert.ToDateTime(qs.Parameters["@DateInsert"].Value);

					if ( qs.Parameters["@DateUpdate"].Value != DBNull.Value )
                        this.User.DateUpdate = Convert.ToDateTime(qs.Parameters["@DateUpdate"].Value);

					#endregion
				}
				
				qs.Parameters.Clear();
				
				return this.User;
			}
			catch(DbException err)
			{
				throw err;
			}
			catch(Exception err)
			{
				throw err;
			}
		}		

		/// <summary>
        /// Salva um objeto do tipo UsersDB
        /// </summary>        
        /// <returns>Int64</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public Int64 Save()
		{
			if(this.User.UserId == -1)
                return this.Insert();
			else
                return this.Update();
		}

		private Int64 Insert()
		{
			try
			{
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Users_INSERT",this._Banco);

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@ID";
				param.Size = 8;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@UserName";
				param.Size = 55;
                param.Value = this.User.UserName;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Password";
				param.Size = 12;
                param.Value = this.User.Password;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.DateTime;
				param.ParameterName = "@DateInsert";
				param.Size = 16;
                param.Value = this.User.DateInsert;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.DateTime;
				param.ParameterName = "@DateUpdate";
				param.Size = 16;
                param.Value = this.User.DateUpdate;
				qs.Parameters.Add(param);

				#endregion
				
				qs.Execute();

                this.User.UserId = Convert.ToInt64(qs.Parameters["@ID"].Value);

				qs.Parameters.Clear();

                return this.User.UserId;
			}
			catch(DbException err)
			{
				throw err;
			}
			catch(Exception err)
			{
				throw err;
			}
		}

		private Int64 Update()
		{
			try
			{
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Users_UPDATE",this._Banco);				

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Size = 8;
                param.Value = this.User.UserId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@UserName";
				param.Size = 55;
                param.Value = this.User.UserName;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Password";
				param.Size = 12;
                param.Value = this.User.Password;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.DateTime;
				param.ParameterName = "@DateInsert";
				param.Size = 16;
                param.Value = this.User.DateInsert;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.DateTime;
				param.ParameterName = "@DateUpdate";
				param.Size = 16;
                param.Value = this.User.DateUpdate;
				qs.Parameters.Add(param);

				#endregion
				
				qs.Execute();	
				
				bool ret = false;
				if(qs.Return > 0)
					ret = true;			

				qs.Parameters.Clear();	
				
				if(!ret)
					throw new Exception("RowCount < 0");

                return this.User.UserId;
			}
			catch(DbException err)
			{
				throw err;
			}
			catch(Exception err)
			{
				throw err;
			}
		}	

		/// <summary>
        /// Apaga um objeto do tipo UsersDB
        /// </summary>        
        /// <returns>Boolean</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public bool Delete()
		{
			try
			{				
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Users_DELETE",this._Banco);
				
				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
                param.Value = this.User.UserId;
				qs.Parameters.Add(param);

				#endregion
				
				qs.Execute();	
				
				bool ret = false;
				if(qs.Return > 0)
					ret = true;				

				qs.Parameters.Clear();	
				
				return ret;	
			}
			catch(DbException err)
			{
				throw err;
			}
			catch(Exception err)
			{
				throw err;
			}
		}		
		
		/// <summary>
        /// Lista objetos do tipo UsersDB
        /// </summary>        
        /// <returns>List<UsersDB></returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public List<UsersModel> Select()
		{
			try
			{
				List<UsersModel> lt = new List<UsersModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Users_SELECT",this._Banco);

				qs.Execute();	
				
				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;	
								
				for (int i=0;i<dt.Rows.Count;i++)
                {			
					UsersModel obj = new UsersModel();
                    
                    #region PARAMETROS
                    
					if ( dt.Rows[i]["UserId"] != DBNull.Value )
                        obj.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["UserName"] != DBNull.Value )
                        obj.UserName = Convert.ToString(dt.Rows[i]["UserName"]);

					if ( dt.Rows[i]["Password"] != DBNull.Value )
                        obj.Password = Convert.ToString(dt.Rows[i]["Password"]);

					if ( dt.Rows[i]["DateInsert"] != DBNull.Value )
                        obj.DateInsert = Convert.ToDateTime(dt.Rows[i]["DateInsert"]);

					if ( dt.Rows[i]["DateUpdate"] != DBNull.Value )
                        obj.DateUpdate = Convert.ToDateTime(dt.Rows[i]["DateUpdate"]);

					#endregion
					
                    lt.Add(obj);
                }

				qs.Parameters.Clear();	
				
				return lt;	
			}
			catch(DbException err)
			{
				throw err;
			}
			catch(Exception err)
			{
				throw err;
			}
		}
 
		#endregion
	}
}

