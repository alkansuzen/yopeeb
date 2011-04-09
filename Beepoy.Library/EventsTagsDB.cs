using System;
using System.Data;
using System.Data.Common;
using Beepoy.Data.Common;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for EventsTags.
	/// </summary>
	public class EventsTagsDB : Persistent
	{
		#region ATRIBUTOS
		
		private DbParameter param;		
		private bool isUpdate = false;


		#endregion

		#region CONSTRUTORES

		public EventsTags()
		{
		
		}		

		public EventsTags(DBWork banco):base(banco)
		{
		
		}
		
		/*
		public EventsTags(
			DBWork banco,
			Int64 TagId
			, Int64 EventId
			):base(banco)
		{
			this = Load(TagId, EventId);
		}
		*/
		
		#endregion
		
		#region PROPRIEDADES

		public Int64 TagId { get; set; }
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
        /// Carrega um objeto do tipo EventsTags
        /// </summary>        
        /// <returns>EventsTags</returns>
        /// <exception cref="System.Data.Common.DbException"></exception>
		public EventsTagsModel Load(Int64 TagId, Int64 EventId)
		{
			try
			{				
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_EventsTags_LOAD",this._Banco);
				
				this.TagId = TagId;
				this.EventId = EventId;


				#region PARAMETROS
				
				DbParameter param = qs.NewParameter();
				param.DbType = System.Data.DbType.Boolean;
				param.ParameterName = "@status";
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);				

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TagId";
				param.Size = 8;
				param.Value = this.TagId;
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
        /// Salva um objeto do tipo EventsTags
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
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_EventsTags_INSERT",this._Banco);

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TagId";
				param.Size = 8;
				param.Value = this.TagId;
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

				this.TagId = Convert.ToInt64( qs.Parameters["@ID"].Value );

				qs.Parameters.Clear();

				return this.TagId;
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
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_EventsTags_UPDATE",this._Banco);				

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TagId";
				param.Size = 8;
				param.Value = this.TagId;
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

				return this.TagId;
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
        /// Apaga um objeto do tipo EventsTags
        /// </summary>        
        /// <returns>Boolean</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public bool Delete()
		{
			try
			{				
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_EventsTags_DELETE",this._Banco);
				
				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TagId";
				param.Value = this.TagId;
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
        /// Lista objetos do tipo EventsTags
        /// </summary>        
        /// <returns>List<EventsTags></returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsTags> Select()
		{
			try
			{
				List<EventsTags> lt = new List<EventsTags>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_EventsTags_SELECT",this._Banco);

				qs.Execute();	
				
				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;	
								
				for (int i=0;i<dt.Rows.Count;i++)
                {			
					EventsTags obj = new EventsTags(this._Banco);
                    
                    #region PARAMETROS
                    
					if ( dt.Rows[i]["TagId"] != DBNull.Value )
						this.TagId = Convert.ToInt64(dt.Rows[i]["TagId"]);

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
		/// Lista objetos do tipo EventsTags
		/// Filtrados por TagId
		/// </summary>
		/// <returns>List<EventsTags></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsTagsModel> SelectBy_TagId(Int64 TagId)
		{
			try
			{
				List<EventsTagsModel> lt = new List<EventsTagsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_EventsTags_SELECTBY_TagId",this._Banco);
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TagId";
				param.Size = 8;
				param.Value = TagId;
				qs.Parameters.Add(param);


				qs.Execute();

				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;

				for (int i=0;i<dt.Rows.Count;i++)
				{
					EventsTagsModel obj = new EventsTagsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["TagId"] != DBNull.Value )
						this.TagId = Convert.ToInt64(dt.Rows[i]["TagId"]);

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
		/// Lista objetos do tipo EventsTags
		/// Filtrados por TagId
		/// Pagess
		/// </summary>
		/// <returns>List<EventsTags></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsTagsModel> SelectBy_TagId_Pages(Int64 TagId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<EventsTagsModel> lt = new List<EventsTagsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_EventsTags_SELECTBY_TagId",this._Banco);
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TagId";
				param.Size = 8;
				param.Value = TagId;
				qs.Parameters.Add(param);


				totalDeRegistros = qs.Execute(currentPage,pageSize);

				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;

				for (int i=0;i<dt.Rows.Count;i++)
				{
					EventsTagsModel obj = new EventsTagsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["TagId"] != DBNull.Value )
						this.TagId = Convert.ToInt64(dt.Rows[i]["TagId"]);

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
		/// Lista objetos do tipo EventsTags
		/// Filtrados por EventId
		/// </summary>
		/// <returns>List<EventsTags></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsTagsModel> SelectBy_EventId(Int64 EventId)
		{
			try
			{
				List<EventsTagsModel> lt = new List<EventsTagsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_EventsTags_SELECTBY_EventId",this._Banco);
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
					EventsTagsModel obj = new EventsTagsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["TagId"] != DBNull.Value )
						this.TagId = Convert.ToInt64(dt.Rows[i]["TagId"]);

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
		/// Lista objetos do tipo EventsTags
		/// Filtrados por EventId
		/// Pagess
		/// </summary>
		/// <returns>List<EventsTags></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<EventsTagsModel> SelectBy_EventId_Pages(Int64 EventId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<EventsTagsModel> lt = new List<EventsTagsModel>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_EventsTags_SELECTBY_EventId",this._Banco);
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
					EventsTagsModel obj = new EventsTagsModel();

					#region PARAMETROS
					if ( dt.Rows[i]["TagId"] != DBNull.Value )
						this.TagId = Convert.ToInt64(dt.Rows[i]["TagId"]);

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

