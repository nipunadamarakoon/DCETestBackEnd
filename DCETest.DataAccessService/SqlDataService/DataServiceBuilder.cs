﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DCETest.DataAccessService.SqlDataService
{
    public class DataServiceBuilder
    {
        public static IDataService CreateDataService()
        {
            return new SqlDataService();
        }

        public static DbParameter CreateDBParameter(string paramName, DbType paramType, ParameterDirection paramDirection, object value, [Optional] int size, [Optional] bool isImageType)
        {
            SqlParameter param = new SqlParameter();
            if (isImageType)
                param.SqlDbType = SqlDbType.Image;
            else
                param.DbType = paramType;
            param.ParameterName = paramName;
            param.Direction = paramDirection;
            param.Value = value;

            if (value == null)
                param.Value = DBNull.Value;
            if (size != 0)
                param.Size = size;
            return param;

        }
    }
}
