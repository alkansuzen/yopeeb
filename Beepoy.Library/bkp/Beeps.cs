using System;
using System.Data;
using System.Data.Common;
using Beepoy.Data.Common;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for Beeps.
	/// </summary>
	public class Beeps : Persistent
	{
		#region ATRIBUTOS
		
		private DbParameter param;		

		#endregion

		#region CONSTRUTORES

		public Beeps()
		{
		
		}		

		public Beeps(DBWork banco):base(banco)
		{
		
		}
		
		/*
		public Beeps(
			DBWork banco,
			Int64 BeepId
			):base(banco)
		{
			this = Load(BeepId);
		}
		*/
		
		#endregion
		
		#region PROPRIEDADES

		public Int64 BeepId { get; set; }
		public string Text { get; set; }
		public Int64 UserId { get; set; }
		public Int64 EventId { get; set; }
		public Int64 PlaceId { get; set; }
		public Int64 TimeId { get; set; }
		public Int64 BeepIdFather { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }

		#endregion

		#region METODOS
				
		/// <summary>
        /// Carrega um objeto do tipo Beeps
        /// </summary>        
        /// <returns>Beeps</returns>
        /// <exception cref="System.Data.Common.DbException"></exception>
		public Beeps Load(Int64 BeepId)
		{
			try
			{				
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Beeps_LOAD",this._Banco);
				


				#region PARAMETROS
				
				DbParameter param = qs.NewParameter();
				param.DbType = System.Data.DbType.Boolean;
				param.ParameterName = "@status";
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);				

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@BeepId";
				param.Size = 8;
				param.Value = this.BeepId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Text";
				param.Size = 144;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@UserId";
				param.Size = 8;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@EventId";
				param.Size = 8;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@PlaceId";
				param.Size = 8;
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
				param.ParameterName = "@BeepIdFather";
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
												
					this.BeepId = BeepId;

					if ( qs.Parameters["@Text"].Value != DBNull.Value )
						this.Text = Convert.ToString(qs.Parameters["@Text"].Value);

					if ( qs.Parameters["@UserId"].Value != DBNull.Value )
						this.UserId = Convert.ToInt64(qs.Parameters["@UserId"].Value);

					if ( qs.Parameters["@EventId"].Value != DBNull.Value )
						this.EventId = Convert.ToInt64(qs.Parameters["@EventId"].Value);

					if ( qs.Parameters["@PlaceId"].Value != DBNull.Value )
						this.PlaceId = Convert.ToInt64(qs.Parameters["@PlaceId"].Value);

					if ( qs.Parameters["@TimeId"].Value != DBNull.Value )
						this.TimeId = Convert.ToInt64(qs.Parameters["@TimeId"].Value);

					if ( qs.Parameters["@BeepIdFather"].Value != DBNull.Value )
						this.BeepIdFather = Convert.ToInt64(qs.Parameters["@BeepIdFather"].Value);

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
        /// Salva um objeto do tipo Beeps
        /// </summary>        
        /// <returns>Int64</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public Int64 Save()
		{
			if(this.BeepId == -1)
				return this.Insert();
			else
				return this.Update();
		}

		private Int64 Insert()
		{
			try
			{
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Beeps_INSERT",this._Banco);

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@ID";
				param.Size = 8;
				param.Direction = ParameterDirection.Output;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Text";
				param.Size = 144;
				param.Value = this.Text;
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
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@PlaceId";
				param.Size = 8;
				param.Value = this.PlaceId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TimeId";
				param.Size = 8;
				param.Value = this.TimeId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@BeepIdFather";
				param.Size = 8;
				param.Value = this.BeepIdFather;
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

				this.BeepId = Convert.ToInt64( qs.Parameters["@ID"].Value );

				qs.Parameters.Clear();

				return this.BeepId;
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
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Beeps_UPDATE",this._Banco);				

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@BeepId";
				param.Size = 8;
				param.Value = this.BeepId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Text";
				param.Size = 144;
				param.Value = this.Text;
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
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@PlaceId";
				param.Size = 8;
				param.Value = this.PlaceId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TimeId";
				param.Size = 8;
				param.Value = this.TimeId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@BeepIdFather";
				param.Size = 8;
				param.Value = this.BeepIdFather;
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

				return this.BeepId;
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
        /// Apaga um objeto do tipo Beeps
        /// </summary>        
        /// <returns>Boolean</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public bool Delete()
		{
			try
			{				
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Beeps_DELETE",this._Banco);
				
				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@BeepId";
				param.Value = this.BeepId;
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
        /// Lista objetos do tipo Beeps
        /// </summary>        
        /// <returns>List<Beeps></returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public List<Beeps> Select()
		{
			try
			{
				List<Beeps> lt = new List<Beeps>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Beeps_SELECT",this._Banco);

				qs.Execute();	
				
				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;	
								
				for (int i=0;i<dt.Rows.Count;i++)
                {			
					Beeps obj = new Beeps(this._Banco);
                    
                    #region PARAMETROS
                    
					if ( dt.Rows[i]["BeepId"] != DBNull.Value )
						this.BeepId = Convert.ToInt64(dt.Rows[i]["BeepId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

					if ( dt.Rows[i]["BeepIdFather"] != DBNull.Value )
						this.BeepIdFather = Convert.ToInt64(dt.Rows[i]["BeepIdFather"]);

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
		/// Lista objetos do tipo Beeps
		/// Filtrados por UserId
		/// </summary>
		/// <returns>List<Beeps></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<Beeps> SelectBy_UserId(Int64 UserId)
		{
			try
			{
				List<Beeps> lt = new List<Beeps>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Beeps_SELECTBY_UserId",this._Banco);
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
					Beeps obj = new Beeps();

					#region PARAMETROS
					if ( dt.Rows[i]["BeepId"] != DBNull.Value )
						this.BeepId = Convert.ToInt64(dt.Rows[i]["BeepId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

					if ( dt.Rows[i]["BeepIdFather"] != DBNull.Value )
						this.BeepIdFather = Convert.ToInt64(dt.Rows[i]["BeepIdFather"]);

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
		/// Lista objetos do tipo Beeps
		/// Filtrados por UserId
		/// Pagess
		/// </summary>
		/// <returns>List<Beeps></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<Beeps> SelectBy_UserId_Pages(Int64 UserId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<Beeps> lt = new List<Beeps>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Beeps_SELECTBY_UserId",this._Banco);
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
					Beeps obj = new Beeps();

					#region PARAMETROS
					if ( dt.Rows[i]["BeepId"] != DBNull.Value )
						this.BeepId = Convert.ToInt64(dt.Rows[i]["BeepId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

					if ( dt.Rows[i]["BeepIdFather"] != DBNull.Value )
						this.BeepIdFather = Convert.ToInt64(dt.Rows[i]["BeepIdFather"]);

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
		/// Lista objetos do tipo Beeps
		/// Filtrados por EventId
		/// </summary>
		/// <returns>List<Beeps></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<Beeps> SelectBy_EventId(Int64 EventId)
		{
			try
			{
				List<Beeps> lt = new List<Beeps>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Beeps_SELECTBY_EventId",this._Banco);
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
					Beeps obj = new Beeps();

					#region PARAMETROS
					if ( dt.Rows[i]["BeepId"] != DBNull.Value )
						this.BeepId = Convert.ToInt64(dt.Rows[i]["BeepId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

					if ( dt.Rows[i]["BeepIdFather"] != DBNull.Value )
						this.BeepIdFather = Convert.ToInt64(dt.Rows[i]["BeepIdFather"]);

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
		/// Lista objetos do tipo Beeps
		/// Filtrados por EventId
		/// Pagess
		/// </summary>
		/// <returns>List<Beeps></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<Beeps> SelectBy_EventId_Pages(Int64 EventId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<Beeps> lt = new List<Beeps>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Beeps_SELECTBY_EventId",this._Banco);
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
					Beeps obj = new Beeps();

					#region PARAMETROS
					if ( dt.Rows[i]["BeepId"] != DBNull.Value )
						this.BeepId = Convert.ToInt64(dt.Rows[i]["BeepId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

					if ( dt.Rows[i]["BeepIdFather"] != DBNull.Value )
						this.BeepIdFather = Convert.ToInt64(dt.Rows[i]["BeepIdFather"]);

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
		/// Lista objetos do tipo Beeps
		/// Filtrados por PlaceId
		/// </summary>
		/// <returns>List<Beeps></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<Beeps> SelectBy_PlaceId(Int64 PlaceId)
		{
			try
			{
				List<Beeps> lt = new List<Beeps>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Beeps_SELECTBY_PlaceId",this._Banco);
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
					Beeps obj = new Beeps();

					#region PARAMETROS
					if ( dt.Rows[i]["BeepId"] != DBNull.Value )
						this.BeepId = Convert.ToInt64(dt.Rows[i]["BeepId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

					if ( dt.Rows[i]["BeepIdFather"] != DBNull.Value )
						this.BeepIdFather = Convert.ToInt64(dt.Rows[i]["BeepIdFather"]);

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
		/// Lista objetos do tipo Beeps
		/// Filtrados por PlaceId
		/// Pagess
		/// </summary>
		/// <returns>List<Beeps></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<Beeps> SelectBy_PlaceId_Pages(Int64 PlaceId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<Beeps> lt = new List<Beeps>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Beeps_SELECTBY_PlaceId",this._Banco);
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
					Beeps obj = new Beeps();

					#region PARAMETROS
					if ( dt.Rows[i]["BeepId"] != DBNull.Value )
						this.BeepId = Convert.ToInt64(dt.Rows[i]["BeepId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

					if ( dt.Rows[i]["BeepIdFather"] != DBNull.Value )
						this.BeepIdFather = Convert.ToInt64(dt.Rows[i]["BeepIdFather"]);

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
		/// Lista objetos do tipo Beeps
		/// Filtrados por TimeId
		/// </summary>
		/// <returns>List<Beeps></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<Beeps> SelectBy_TimeId(Int64 TimeId)
		{
			try
			{
				List<Beeps> lt = new List<Beeps>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Beeps_SELECTBY_TimeId",this._Banco);
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
					Beeps obj = new Beeps();

					#region PARAMETROS
					if ( dt.Rows[i]["BeepId"] != DBNull.Value )
						this.BeepId = Convert.ToInt64(dt.Rows[i]["BeepId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

					if ( dt.Rows[i]["BeepIdFather"] != DBNull.Value )
						this.BeepIdFather = Convert.ToInt64(dt.Rows[i]["BeepIdFather"]);

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
		/// Lista objetos do tipo Beeps
		/// Filtrados por TimeId
		/// Pagess
		/// </summary>
		/// <returns>List<Beeps></returns>
		/// <exception cref="System.Data.Common.DbException"></exception>
		public List<Beeps> SelectBy_TimeId_Pages(Int64 TimeId, int currentPage, int pageSize, out int totalDeRegistros)
		{
			try
			{
				List<Beeps> lt = new List<Beeps>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Beeps_SELECTBY_TimeId",this._Banco);
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
					Beeps obj = new Beeps();

					#region PARAMETROS
					if ( dt.Rows[i]["BeepId"] != DBNull.Value )
						this.BeepId = Convert.ToInt64(dt.Rows[i]["BeepId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

					if ( dt.Rows[i]["UserId"] != DBNull.Value )
						this.UserId = Convert.ToInt64(dt.Rows[i]["UserId"]);

					if ( dt.Rows[i]["EventId"] != DBNull.Value )
						this.EventId = Convert.ToInt64(dt.Rows[i]["EventId"]);

					if ( dt.Rows[i]["PlaceId"] != DBNull.Value )
						this.PlaceId = Convert.ToInt64(dt.Rows[i]["PlaceId"]);

					if ( dt.Rows[i]["TimeId"] != DBNull.Value )
						this.TimeId = Convert.ToInt64(dt.Rows[i]["TimeId"]);

					if ( dt.Rows[i]["BeepIdFather"] != DBNull.Value )
						this.BeepIdFather = Convert.ToInt64(dt.Rows[i]["BeepIdFather"]);

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

