using System;
using System.Data;
using System.Data.Common;
using Beepoy.Data.Common;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for Places.
	/// </summary>
	public class Places : Persistent
	{
		#region ATRIBUTOS
		
		private DbParameter param;		

		#endregion

		#region CONSTRUTORES

		public Places()
		{
		
		}		

		public Places(DBWork banco):base(banco)
		{
		
		}
		
		/*
		public Places(
			DBWork banco,
			Int64 PlaceId
			):base(banco)
		{
			this = Load(PlaceId);
		}
		*/
		
		#endregion
		
		#region PROPRIEDADES

		public Int64 PlaceId { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public Int64 UserId { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }

		#endregion

		#region METODOS
				
		/// <summary>
        /// Carrega um objeto do tipo Places
        /// </summary>        
        /// <returns>Places</returns>
        /// <exception cref="System.Data.Common.DbException"></exception>
		public Places Load(Int64 PlaceId)
		{
			try
			{				
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Places_LOAD",this._Banco);
				


				#region PARAMETROS
				
				DbParameter param = qs.NewParameter();
				param.DbType = System.Data.DbType.Boolean;
				param.ParameterName = "@status";
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);				

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@PlaceId";
				param.Size = 8;
				param.Value = this.PlaceId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Name";
				param.Size = 55;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Double;
				param.ParameterName = "@Latitude";
				param.Size = 8;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Double;
				param.ParameterName = "@Longitude";
				param.Size = 8;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Size = 8;
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
												
					this.PlaceId = PlaceId;

					if ( qs.Parameters["@Name"].Value != DBNull.Value )
						this.Name = Convert.ToString(qs.Parameters["@Name"].Value);

					if ( qs.Parameters["@Latitude"].Value != DBNull.Value )
						this.Latitude = Convert.ToDouble(qs.Parameters["@Latitude"].Value);

					if ( qs.Parameters["@Longitude"].Value != DBNull.Value )
						this.Longitude = Convert.ToDouble(qs.Parameters["@Longitude"].Value);

					if ( qs.Parameters["@UserId"].Value != DBNull.Value )
						this.UserId = Convert.ToInt64(qs.Parameters["@UserId"].Value);

					if ( qs.Parameters["@DateInsert"].Value != DBNull.Value )
						this.DateInsert = Convert.ToDateTime(qs.Parameters["@DateInsert"].Value);

					if ( qs.Parameters["@DateUpdate"].Value != DBNull.Value )
						this.DateUpdate = Convert.ToDateTime(qs.Parameters["@DateUpdate"].Value);


					#endregion
				}
				
				qs.Parameters.Clear();
				
				return this;
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
        /// Salva um objeto do tipo Places
        /// </summary>        
        /// <returns>Int64</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public Int64 Save()
		{
			if(this.PlaceId == -1)
				return this.Insert();
			else
				return this.Update();
		}

		private Int64 Insert()
		{
			try
			{
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Places_INSERT",this._Banco);

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@ID";
				param.Size = 8;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Name";
				param.Size = 55;
				param.Value = this.Name;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Double;
				param.ParameterName = "@Latitude";
				param.Size = 8;
				param.Value = this.Latitude;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Double;
				param.ParameterName = "@Longitude";
				param.Size = 8;
				param.Value = this.Longitude;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Size = 8;
				param.Value = this.UserId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.DateTime;
				param.ParameterName = "@DateInsert";
				param.Size = 16;
				param.Value = this.DateInsert;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.DateTime;
				param.ParameterName = "@DateUpdate";
				param.Size = 16;
				param.Value = this.DateUpdate;
				qs.Parameters.Add(param);


				#endregion
				
				qs.Execute();

				this.PlaceId = Convert.ToInt64( qs.Parameters["@ID"].Value );

				qs.Parameters.Clear();

				return this.PlaceId;
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
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Places_UPDATE",this._Banco);				

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@PlaceId";
				param.Size = 8;
				param.Value = this.PlaceId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Name";
				param.Size = 55;
				param.Value = this.Name;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Double;
				param.ParameterName = "@Latitude";
				param.Size = 8;
				param.Value = this.Latitude;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Double;
				param.ParameterName = "@Longitude";
				param.Size = 8;
				param.Value = this.Longitude;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Size = 8;
				param.Value = this.UserId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.DateTime;
				param.ParameterName = "@DateInsert";
				param.Size = 16;
				param.Value = this.DateInsert;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.DateTime;
				param.ParameterName = "@DateUpdate";
				param.Size = 16;
				param.Value = this.DateUpdate;
				qs.Parameters.Add(param);


				#endregion
				
				qs.Execute();	
				
				bool ret = false;
				if(qs.Return > 0)
					ret = true;			

				qs.Parameters.Clear();	
				
				if(!ret)
					throw new Exception("RowCount < 0");

				return this.PlaceId;
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
        /// Apaga um objeto do tipo Places
        /// </summary>        
        /// <returns>Boolean</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public bool Delete()
		{
			try
			{				
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Places_DELETE",this._Banco);
				
				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@PlaceId";
				param.Value = this.PlaceId;
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
		
		/*
		/// <summary>
        /// Lista objetos do tipo Places
        /// </summary>        
        /// <returns>List<Places></returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public List<Places> Select()
		{
			try
			{
				List<Places> lt = new List<Places>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Places_SELECT",this._Banco);

				qs.Execute();	
				
				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;	
								
				for (int i=0;i<dt.Rows.Count;i++)
                {			
					Places obj = new Places(this._Banco);
                    
                    #region PARAMETROS
                    
					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["Name"] != DBNull.Value )
						this.Name = Convert.ToString(dt.Rows[i]["Name"]);

					if ( dt.Rows[i]["Latitude"] != DBNull.Value )
						this.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);

					if ( dt.Rows[i]["Longitude"] != DBNull.Value )
						this.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["DateInsert"] != DBNull.Value )
						this.DateInsert = Convert.ToDateTime(dt.Rows[i]["DateInsert"]);

					if ( dt.Rows[i]["DateUpdate"] != DBNull.Value )
						this.DateUpdate = Convert.ToDateTime(dt.Rows[i]["DateUpdate"]);


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
		}*/	
		
		/// <summary>
		/// Lista objetos do tipo Places
		/// Filtrados por UserId
		/// </summary>
		/// <returns>List<Places></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<Places> SelectBy_UserId(Int64 UserId)
		{
			try
			{
				List<Places> lt = new List<Places>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Places_SELECTBY_UserId",this._Banco);
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Size = 8;
				param.Value = UserId;
				qs.Parameters.Add(param);


				qs.Execute();

				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;

				for (int i=0;i<dt.Rows.Count;i++)
				{
					Places obj = new Places();

					#region PARAMETROS
					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["Name"] != DBNull.Value )
						this.Name = Convert.ToString(dt.Rows[i]["Name"]);

					if ( dt.Rows[i]["Latitude"] != DBNull.Value )
						this.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);

					if ( dt.Rows[i]["Longitude"] != DBNull.Value )
						this.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["DateInsert"] != DBNull.Value )
						this.DateInsert = Convert.ToDateTime(dt.Rows[i]["DateInsert"]);

					if ( dt.Rows[i]["DateUpdate"] != DBNull.Value )
						this.DateUpdate = Convert.ToDateTime(dt.Rows[i]["DateUpdate"]);

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

		/// <summary>
		/// Lista objetos do tipo Places
		/// Filtrados por UserId
		/// Pagess
		/// </summary>
		/// <returns>List<Places></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<Places> SelectBy_UserId_Pages(Int64 UserId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<Places> lt = new List<Places>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Places_SELECTBY_UserId",this._Banco);
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Size = 8;
				param.Value = UserId;
				qs.Parameters.Add(param);


				totalDeRegistros = qs.Execute(currentPage,pageSize);

				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;

				for (int i=0;i<dt.Rows.Count;i++)
				{
					Places obj = new Places();

					#region PARAMETROS
					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["Name"] != DBNull.Value )
						this.Name = Convert.ToString(dt.Rows[i]["Name"]);

					if ( dt.Rows[i]["Latitude"] != DBNull.Value )
						this.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);

					if ( dt.Rows[i]["Longitude"] != DBNull.Value )
						this.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["DateInsert"] != DBNull.Value )
						this.DateInsert = Convert.ToDateTime(dt.Rows[i]["DateInsert"]);

					if ( dt.Rows[i]["DateUpdate"] != DBNull.Value )
						this.DateUpdate = Convert.ToDateTime(dt.Rows[i]["DateUpdate"]);

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

