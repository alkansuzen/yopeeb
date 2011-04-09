using System;
using System.Data;
using System.Data.Common;
using Beepoy.Data.Common;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for TrackUsersEvents.
	/// </summary>
	public class TrackUsersEventsDB : Persistent
	{
		#region ATRIBUTOS
		
		private DbParameter param;		
		private bool isUpdate = false;


		#endregion

		#region CONSTRUTORES

		public TrackUsersEvents()
		{
		
		}		

		public TrackUsersEvents(DBWork banco):base(banco)
		{
		
		}
		
		/*
		public TrackUsersEvents(
			DBWork banco,
			Int64 UserId
			, Int64 EventId
			):base(banco)
		{
			this = Load(UserId, EventId);
		}
		*/
		
		#endregion
		
		#region PROPRIEDADES

		public Int64 UserId { get; set; }
		public Int64 EventId { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
		public bool IsUpdate()
		{
				return this.isUpdate;
		}


		#endregion

		#region METODOS
				
		/// <summary>
        /// Carrega um objeto do tipo TrackUsersEvents
        /// </summary>        
        /// <returns>TrackUsersEvents</returns>
        /// <exception cref="System.Data.Common.DbException"></exception>
		public TrackUsersEventsModel Load(Int64 UserId, Int64 EventId)
		{
			try
			{				
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_TrackUsersEvents_LOAD",this._Banco);
				
				this.UserId = UserId;
				this.EventId = EventId;


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
				param.Value = this.UserId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@EventId";
				param.Size = 8;
				param.Value = this.EventId;
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
												
					if ( qs.Parameters["@DateInsert"].Value != DBNull.Value )
						this.DateInsert = Convert.ToDateTime(qs.Parameters["@DateInsert"].Value);

					if ( qs.Parameters["@DateUpdate"].Value != DBNull.Value )
						this.DateUpdate = Convert.ToDateTime(qs.Parameters["@DateUpdate"].Value);

					this.isUpdate = true;


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
        /// Salva um objeto do tipo TrackUsersEvents
        /// </summary>        
        /// <returns>Int64</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public Int64 Save()
		{
			if(!this.isUpdate)
				return this.Insert();
			else
				return this.Update();
		}

		private Int64 Insert()
		{
			try
			{
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_TrackUsersEvents_INSERT",this._Banco);

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Size = 8;
				param.Value = this.UserId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@EventId";
				param.Size = 8;
				param.Value = this.EventId;
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

				this.UserId = Convert.ToInt64( qs.Parameters["@ID"].Value );

				qs.Parameters.Clear();

				return this.UserId;
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
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_TrackUsersEvents_UPDATE",this._Banco);				

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Size = 8;
				param.Value = this.UserId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@EventId";
				param.Size = 8;
				param.Value = this.EventId;
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

				return this.UserId;
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
        /// Apaga um objeto do tipo TrackUsersEvents
        /// </summary>        
        /// <returns>Boolean</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public bool Delete()
		{
			try
			{				
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_TrackUsersEvents_DELETE",this._Banco);
				
				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Value = this.UserId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@EventId";
				param.Value = this.EventId;
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
        /// Lista objetos do tipo TrackUsersEvents
        /// </summary>        
        /// <returns>List<TrackUsersEvents></returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public List<TrackUsersEvents> Select()
		{
			try
			{
				List<TrackUsersEvents> lt = new List<TrackUsersEvents>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_TrackUsersEvents_SELECT",this._Banco);

				qs.Execute();	
				
				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;	
								
				for (int i=0;i<dt.Rows.Count;i++)
                {			
					TrackUsersEvents obj = new TrackUsersEvents(this._Banco);
                    
                    #region PARAMETROS
                    
					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

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
		/// Lista objetos do tipo TrackUsersEvents
		/// Filtrados por UserId
		/// </summary>
		/// <returns>List<TrackUsersEvents></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<TrackUsersEventsModel> SelectBy_UserId(Int64 UserId)
		{
			try
			{
				List<TrackUsersEventsModel> lt = new List<TrackUsersEventsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_TrackUsersEvents_SELECTBY_UserId",this._Banco);
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
					TrackUsersEventsModel obj = new TrackUsersEventsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

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
		/// Lista objetos do tipo TrackUsersEvents
		/// Filtrados por UserId
		/// Pagess
		/// </summary>
		/// <returns>List<TrackUsersEvents></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<TrackUsersEventsModel> SelectBy_UserId_Pages(Int64 UserId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<TrackUsersEventsModel> lt = new List<TrackUsersEventsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_TrackUsersEvents_SELECTBY_UserId",this._Banco);
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
					TrackUsersEventsModel obj = new TrackUsersEventsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

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
		/// Lista objetos do tipo TrackUsersEvents
		/// Filtrados por EventId
		/// </summary>
		/// <returns>List<TrackUsersEvents></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<TrackUsersEventsModel> SelectBy_EventId(Int64 EventId)
		{
			try
			{
				List<TrackUsersEventsModel> lt = new List<TrackUsersEventsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_TrackUsersEvents_SELECTBY_EventId",this._Banco);
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@EventId";
				param.Size = 8;
				param.Value = EventId;
				qs.Parameters.Add(param);


				qs.Execute();

				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;

				for (int i=0;i<dt.Rows.Count;i++)
				{
					TrackUsersEventsModel obj = new TrackUsersEventsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

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
		/// Lista objetos do tipo TrackUsersEvents
		/// Filtrados por EventId
		/// Pagess
		/// </summary>
		/// <returns>List<TrackUsersEvents></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<TrackUsersEventsModel> SelectBy_EventId_Pages(Int64 EventId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<TrackUsersEventsModel> lt = new List<TrackUsersEventsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_TrackUsersEvents_SELECTBY_EventId",this._Banco);
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@EventId";
				param.Size = 8;
				param.Value = EventId;
				qs.Parameters.Add(param);


				totalDeRegistros = qs.Execute(currentPage,pageSize);

				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;

				for (int i=0;i<dt.Rows.Count;i++)
				{
					TrackUsersEventsModel obj = new TrackUsersEventsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

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

