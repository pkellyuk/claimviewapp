using System.Threading.Tasks;
using ClaimViewApp.Models;
using ClaimViewApp.Api;
using System.Collections.Generic;

namespace ClaimViewApp.Data
{
    public static class ClaimViewService
    {       
        public static List<ClaimModel> GetClaimById(int claimId)
        {
            ClaimApi claimApi = new ClaimApi();
            List<ClaimModel> claims = claimApi.GetClaimsById(claimId);

            // fillout the losstypes
            var lossTypes = claimApi.GetLossTypes();
            if(lossTypes!=null)
            {
                foreach (ClaimModel claim in claims)
                {
                    var lossType = lossTypes.Find(x => x.CreatedId == claim.CreatedId);
                    if (lossType != null)
                    {
                        claim.LossTypeDesc = lossType.LossTypeDescription;
                    }
                    else
                    {
                        claim.LossTypeDesc = "Unknown Loss Type";
                    }
                }
            }
            return claims;            
        }

        public static UserModel LoginUser(string username, string password)
        {
            if(string.IsNullOrEmpty(username))
            {
                return null;
            }

            if(string.IsNullOrEmpty(password))
            {
                return null;
            }

            ClaimApi claimApi = new ClaimApi();
            UserModel user = claimApi.GetUserByUserName(username);

            if(user == null)
            {
                return null;
            }

            if(string.IsNullOrEmpty(user.Password))
            {
                return null;
            }

            if(user.Password.ToLower().Trim() == password.ToLower().Trim())
            {
                return user;
            }

            return null;
        }
    }
}
