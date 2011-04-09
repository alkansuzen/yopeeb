using System;
using System.Data;
using System.Data.Common;
using Beepoy.Data.Common;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for Tags.
	/// </summary>
	public class TagsDB : Persistent
	{
		#region ATRIBUTOS
		
		private DbParameter param;		

		#endregion

		#region CONSTRUTORES

		public Tags()
		{
		
		}		

		public Tags(DBWork banco):base(banco)
		{
		
		}
		
		/*
		public Tags(
			DBWork banco,
			Int64 TagId
			):base(banco)
		{
			this = Load(TagId);
		}
		*/
		
		#endregion
		
		#region PROPRIEDADES

		public Int64 TagId { get; set; }
		public string Text { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }

		#endregion

		#region METODOS
				
		/// <summary>
        /// Carrega um objeto do tipo Tags
        /// </summary>        
        /// <returns>Tags</returns>
        /// <exception cref="System.Data.Common.DbException"></exception>
		public TagsModel Load(Int64 TagId)
		{
			try
			{				
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Tags_LOAD",this._Banco);
				


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
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Text";
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
												
					this.TagId = TagId;

					if ( qs.Parameters["@Text"].Value != DBNull.Value )
						this.Text = Convert.ToString(qs.Parameters["@Text"].Value);

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
        /// Salva um objeto do tipo Tags
        /// </summary>        
        /// <returns>Int64</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public Int64 Save()
		{
			if(this.TagId == -1)
				return this.Insert();
			else
				return this.Update();
		}

		private Int64 Insert()
		{
			try
			{
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Tags_INSERT",this._Banco);

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
				param.Size = 12;
				param.Value = this.Text;
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
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Tags_UPDATE",this._Banco);				

				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TagId";
				param.Size = 8;
				param.Value = this.TagId;
				qs.Parameters.Add(param);

				param = qs.NewParameter();
				param.DbType = System.Data.DbType.AnsiString;
				param.ParameterName = "@Text";
				param.Size = 12;
				param.Value = this.Text;
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
        /// Apaga um objeto do tipo Tags
        /// </summary>        
        /// <returns>Boolean</returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public bool Delete()
		{
			try
			{				
				QueryStoredProcedure qs = new QueryStoredProcedure("STP_Tags_DELETE",this._Banco);
				
				#region PARAMETROS
				
				param = qs.NewParameter();
				param.DbType = System.Data.DbType.Int64;
				param.ParameterName = "@TagId";
				param.Value = this.TagId;
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
        /// Lista objetos do tipo Tags
        /// </summary>        
        /// <returns>List<Tags></returns>
         /// <exception cref="System.Data.Common.DbException"></exception>
		public List<Tags> Select()
		{
			try
			{
				List<Tags> lt = new List<Tags>();
				DataTable dt = new DataTable();
				QuerySelectStoredProcedure qs = new QuerySelectStoredProcedure("STP_Tags_SELECT",this._Banco);

				qs.Execute();	
				
				if(qs.Return.Rows.Count > 0)
					dt = qs.Return;	
								
				for (int i=0;i<dt.Rows.Count;i++)
                {			
					Tags obj = new Tags(this._Banco);
                    
                    #region PARAMETROS
                    
					if ( dt.Rows[i]["TagId"] != DBNull.Value )
						this.TagId = Convert.ToInt64(dt.Rows[i]["TagId"]);

					if ( dt.Rows[i]["Text"] != DBNull.Value )
						this.Text = Convert.ToString(dt.Rows[i]["Text"]);

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
		
 
		#endregion
	}
}

