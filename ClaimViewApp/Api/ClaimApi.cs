using System;
using ClaimViewApp.Models;
using ClaimViewApp.Data;
using System.Collections.Generic;

namespace ClaimViewApp.Api
{
    public class ClaimApi
    {
        public List<LossTypeModel> GetLossTypes()
        {
            DbLayer db = new DbLayer();
            try
            {
                db.Connect(Config.Claimdb_host, Config.Claimdb_user, Config.Claimdb_pass, Config.Claimdb_db);
                return db.GetLossTypes();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public List<ClaimModel> GetClaimsById(int id)
        {
            DbLayer db = new DbLayer();
            try
            {
                db.Connect(Config.Claimdb_host, Config.Claimdb_user, Config.Claimdb_pass, Config.Claimdb_db);
                return db.GetClaimsById(id);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public UserModel GetUserByUserName(string username)
        {
            DbLayer db = new DbLayer();
            try
            {
                db.Connect(Config.Claimdb_host, Config.Claimdb_user, Config.Claimdb_pass, Config.Claimdb_db);
                return db.GetUserByUserName(username);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db.Disconnect();
            }
        }
    }
}
