using System;
using System.Data;
using System.Data.Common;
using Beepoy.Data.Common;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for Events.
	/// </summary>
	public class EventsDB : Persistent
	{
		#region ATRIBUTOS
		
		private DbParameter param;		

		#endregion

		#region CONSTRUTORES

		public Events()
		{
		
		}		

		public Events(DBWork banco):base(banco)
		{
		
		}
		
		/*
		public Events(
			DBWork banco,
			Int64 EventId
			):base(banco)
		{
			this = Load(EventId);
		}
		*/
		
		#endregion
		
		#region PROPRIEDADES

		public Int64 EventId { get; set; }
		public Int64 PlaceId { get; set; }
		public string Text { get; set; }
		public Int64 TimeId { get; set; }
		public Int64 UserId { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }

		#endregion

		#region METODOS
				
		/// <summary>
        /// Carrega um objeto do tipo Events
        /// </summary>        
        /// <returns>Events</returns>
        /// <exception cref="System.Data.Common.DbException"></exception>
		public EventsModel Load(Int64 EventId)
		{
			try
			{				
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Events_LOAD",this._Banco);
				


				#region PARAMETROS
				
				DbParameter param = qs.NewParameter();
				param.DbType = System.Data.DbType.Boolean;
				param.ParameterName = "@status";
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);				

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@EventId";
				param.Size = 8;
				param.Value = this.EventId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@PlaceId";
				param.Size = 8;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Text";
				param.Size = 144;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TimeId";
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
												
					this.EventId = EventId;

					if ( qs.Parameters["@PlaceId"].Value != DBNull.Value )
						this.PlaceId = Convert.ToInt64(qs.Parameters["@PlaceId"].Value);

					if ( qs.Parameters["@Text"].Value != DBNull.Value )
						this.Text = Convert.ToString(qs.Parameters["@Text"].Value);

					if ( qs.Parameters["@TimeId"].Value != DBNull.Value )
						this.TimeId = Convert.ToInt64(qs.Parameters["@TimeId"].Value);

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
        /// Salva um objeto do tipo Events
        /// </summary>        
        /// <returns>Int64</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public Int64 Save()
		{
			if(this.EventId == -1)
				return this.Insert();
			else
				return this.Update();
		}

		private Int64 Insert()
		{
			try
			{
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Events_INSERT",this._Banco);

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@ID";
				param.Size = 8;
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
				param.ParameterName = "@Text";
				param.Size = 144;
				param.Value = this.Text;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TimeId";
				param.Size = 8;
				param.Value = this.TimeId;
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

				this.EventId = Convert.ToInt64( qs.Parameters["@ID"].Value );

				qs.Parameters.Clear();

				return this.EventId;
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
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Events_UPDATE",this._Banco);				

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@EventId";
				param.Size = 8;
				param.Value = this.EventId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@PlaceId";
				param.Size = 8;
				param.Value = this.PlaceId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Text";
				param.Size = 144;
				param.Value = this.Text;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TimeId";
				param.Size = 8;
				param.Value = this.TimeId;
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

				return this.EventId;
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
        /// Apaga um objeto do tipo Events
        /// </summary>        
        /// <returns>Boolean</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public bool Delete()
		{
			try
			{				
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Events_DELETE",this._Banco);
				
				#region PARAMETROS
				
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
        /// Lista objetos do tipo Events
        /// </summary>        
        /// <returns>List<Events></returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public List<Events> Select()
		{
			try
			{
				List<Events> lt = new List<Events>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Events_SELECT",this._Banco);

				qs.Execute();	
				
				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;	
								
				for (int i=0;i<dt.Rows.Count;i++)
                {			
					Events obj = new Events(this._Banco);
                    
                    #region PARAMETROS
                    
					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

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
		/// Lista objetos do tipo Events
		/// Filtrados por PlaceId
		/// </summary>
		/// <returns>List<Events></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsModel> SelectBy_PlaceId(Int64 PlaceId)
		{
			try
			{
				List<EventsModel> lt = new List<EventsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Events_SELECTBY_PlaceId",this._Banco);
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@PlaceId";
				param.Size = 8;
				param.Value = PlaceId;
				qs.Parameters.Add(param);


				qs.Execute();

				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;

				for (int i=0;i<dt.Rows.Count;i++)
				{
					EventsModel obj = new EventsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

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
		/// Lista objetos do tipo Events
		/// Filtrados por PlaceId
		/// Pagess
		/// </summary>
		/// <returns>List<Events></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsModel> SelectBy_PlaceId_Pages(Int64 PlaceId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<EventsModel> lt = new List<EventsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Events_SELECTBY_PlaceId",this._Banco);
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@PlaceId";
				param.Size = 8;
				param.Value = PlaceId;
				qs.Parameters.Add(param);


				totalDeRegistros = qs.Execute(currentPage,pageSize);

				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;

				for (int i=0;i<dt.Rows.Count;i++)
				{
					EventsModel obj = new EventsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

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
		/// Lista objetos do tipo Events
		/// Filtrados por TimeId
		/// </summary>
		/// <returns>List<Events></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsModel> SelectBy_TimeId(Int64 TimeId)
		{
			try
			{
				List<EventsModel> lt = new List<EventsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Events_SELECTBY_TimeId",this._Banco);
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TimeId";
				param.Size = 8;
				param.Value = TimeId;
				qs.Parameters.Add(param);


				qs.Execute();

				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;

				for (int i=0;i<dt.Rows.Count;i++)
				{
					EventsModel obj = new EventsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

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
		/// Lista objetos do tipo Events
		/// Filtrados por TimeId
		/// Pagess
		/// </summary>
		/// <returns>List<Events></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsModel> SelectBy_TimeId_Pages(Int64 TimeId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<EventsModel> lt = new List<EventsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Events_SELECTBY_TimeId",this._Banco);
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TimeId";
				param.Size = 8;
				param.Value = TimeId;
				qs.Parameters.Add(param);


				totalDeRegistros = qs.Execute(currentPage,pageSize);

				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;

				for (int i=0;i<dt.Rows.Count;i++)
				{
					EventsModel obj = new EventsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

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
		/// Lista objetos do tipo Events
		/// Filtrados por UserId
		/// </summary>
		/// <returns>List<Events></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsModel> SelectBy_UserId(Int64 UserId)
		{
			try
			{
				List<EventsModel> lt = new List<EventsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Events_SELECTBY_UserId",this._Banco);
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
					EventsModel obj = new EventsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

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
		/// Lista objetos do tipo Events
		/// Filtrados por UserId
		/// Pagess
		/// </summary>
		/// <returns>List<Events></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsModel> SelectBy_UserId_Pages(Int64 UserId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<EventsModel> lt = new List<EventsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Events_SELECTBY_UserId",this._Banco);
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
					EventsModel obj = new EventsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

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

