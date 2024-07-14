using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace CheckRT.db_object
{
    internal static class db_object
    {

        public static void MakeDataBaseObject(SqlConnection sqlConnection)
        {
            //[dbo].[tbFilters]

            if (!dbobject_exist("[dbo].[tbFilters]", sqlConnection)) {
                //
                string sSQL = @"CREATE TABLE [dbo].[tbFilters](
	                [id_filter] [int] IDENTITY(1,1) NOT NULL,
	                [FilterName] [varchar](500) NULL,
	                [Descr] [nvarchar](max) NULL,
	                [Active] [bit] NULL,
                 CONSTRAINT [PK_tbFilters] PRIMARY KEY CLUSTERED 
                (
	                [id_filter] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]; ALTER TABLE [dbo].[tbFilters] ADD  CONSTRAINT [DF_tbFilters_Active]  DEFAULT ((0)) FOR [Active]";

                SqlCommand selectCommand = new()
                {
                    Connection = sqlConnection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = sSQL
                };
                selectCommand.ExecuteNonQuery();


            }

        }

        private static bool dbobject_exist(string dbObjectName, SqlConnection sqlConnection) {

            bool ret = false;

            SqlCommand selectCommand = new()
            {
                Connection = sqlConnection,
                CommandType = System.Data.CommandType.Text,
                CommandText = "select isnull(OBJECT_ID(@dbObjectName), 0)"
            };
            selectCommand.Parameters.AddWithValue("@dbObjectName", dbObjectName);
            int id_object = (int)selectCommand.ExecuteScalar();

            if (id_object > 0) ret = true;

            return ret;
        }


    }
}
