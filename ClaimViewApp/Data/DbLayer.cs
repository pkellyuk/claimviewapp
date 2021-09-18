using System;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using ClaimViewApp.Models;
using Polly;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace ClaimViewApp.Data
{
    public class DbLayer
    {
        private SqlConnection sqlserverConnection = null;
        private string strConnection = string.Empty;
        private Policy sqlRetryPolicy = Policy.Handle<SqlException>().WaitAndRetry(
               retryCount: 5,
               onRetry: (exception, attempt) =>
               {
               },
               sleepDurationProvider: attempt => TimeSpan.FromMilliseconds(2000));

        public List<LossTypeModel> GetLossTypes()
        {
            return sqlRetryPolicy.Execute(() =>
            {
                return sqlserverConnection.GetAll<LossTypeModel>().ToList();
            });
        }

        public List<ClaimModel> GetClaimsById(int createdId)
        {
            return sqlRetryPolicy.Execute(() =>
            {
                string strSql = "select * from Claims where CreatedId = @CREATEDID";
                var p = new DynamicParameters();
                p.Add("CREATEDID", createdId);
                var claims = sqlserverConnection.Query<ClaimModel>(strSql, p);
                List<ClaimModel> claimsList = claims.ToList();
                return claimsList;
            });
        }

        public UserModel GetUserByUserName(string username)
        {
            return sqlRetryPolicy.Execute(() =>
            {
                return sqlserverConnection.Get<UserModel>(username);
            });
        }

        public bool Connect(string strHost,
           string strUsername,
           string strPassword,
           string strDBname)
        {
            try
            {
                sqlRetryPolicy.Execute(() =>
                {
                    strConnection = "Server=" + strHost + ";Database=" + strDBname + ";Uid=" + strUsername + ";Pwd=" + strPassword;
                    sqlserverConnection = new SqlConnection(strConnection);
                    sqlserverConnection.Open();
                });
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
        public void Disconnect()
        {
            try
            {
                sqlserverConnection.Close();
            }
            catch (Exception)
            {
                // no need to log here
            }
        }
    }
}
