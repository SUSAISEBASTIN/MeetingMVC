using Meeting.Framework.Helper;
using Meeting.Models;
using Meeting.Models.Input;
using Meeting.Models.Output;
using Meeting.Repository.Interface;
using Meeting.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting.Service.Services
{
    public class UserService : IUserDetailsService
    {
        private IRegisterationRepostory _userDetailsRepository;

        public UserService(IRegisterationRepostory userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }

        public async Task<ResultDataArgs> AddUserDetailsAsync(UserDetailsDTO userDetailDTO)
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                int objUserDetail = await _userDetailsRepository.AddUserDetailsAsync(userDetailDTO);
                if (objUserDetail == 0)
                {
                    ResultDataArgs.StatusCode = Messagecatalog.ErrorCodes.Success;
                    ResultDataArgs.StatusMessage = Messagecatalog.ErrorMessages.SaveSuccess;

                }
                else
                {
                    ResultDataArgs.StatusCode = Messagecatalog.ErrorCodes.Failed;
                    ResultDataArgs.StatusMessage = Messagecatalog.ErrorMessages.SaveFailed;
                }
            }
            catch (Exception ex)
            {

            }
            return ResultDataArgs;
        }

        public async Task<ResultDataArgs> DeleteUserDetailsAsync(int Id)
        {
            var RresultArgs = new ResultDataArgs();
            var objUserDetail = await _userDetailsRepository.DeleteUserDetailsAsync(Id);
            try
            {
                RresultArgs.StatusCode = 200;
                RresultArgs.MessageTitle = Messagecatalog.MessageTitle.UserDetails;

                if (RresultArgs.StatusCode == 200)
                {
                    RresultArgs.StatusCode = Messagecatalog.ErrorCodes.Success;
                    RresultArgs.StatusMessage = Messagecatalog.ErrorMessages.DeleteSuccess;
                }
                else if (RresultArgs.StatusCode == 203)
                {
                    RresultArgs.StatusCode = Messagecatalog.ErrorCodes.Exist;
                    RresultArgs.StatusMessage = Messagecatalog.ErrorMessages.RecordReferred;
                }
                else if (RresultArgs.StatusCode == 500)
                {
                    RresultArgs.StatusCode = Messagecatalog.ErrorCodes.Failed;
                    RresultArgs.StatusMessage = Messagecatalog.ErrorMessages.DeleteFailed;
                }
                else
                {
                    RresultArgs.StatusCode = Messagecatalog.ErrorCodes.Failed;
                    RresultArgs.StatusMessage = Messagecatalog.ErrorMessages.DeleteFailed;
                }
            }
            catch (Exception ex)
            {
                
            }
            return RresultArgs;
        }

        public async Task<ResultDataArgs> GetUserDetailsAsync()
        {
            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            UserDetailResult obj= new UserDetailResult();
            try
            {
                  obj = await _userDetailsRepository.GetUserDetailsAsync();

                

                if (obj != null)
                {
                    ResultDataArgs.StatusCode = Messagecatalog.ErrorCodes.Success;
                    ResultDataArgs.StatusMessage = Messagecatalog.ErrorMessages.Success;
                    ResultDataArgs.MessageTitle = Messagecatalog.MessageTitle.UserDetails;
                    ResultDataArgs.ResultData = obj.UserDetailsList;
                }
                else
                {
                    ResultDataArgs.StatusCode = Messagecatalog.ErrorCodes.NoRecordFound;
                    ResultDataArgs.StatusMessage = Messagecatalog.ErrorMessages.NoRecordFound;
                }
            }
            catch (Exception ex)
            {
                
            }
            return ResultDataArgs;
        }

        public async Task<ResultDataArgs> GetUserDetailsByIdAsync(int Id)
        {
            ResultDataArgs ResultDataArgs=new ResultDataArgs();

          
            try
            {
                UserDetailsDTO objUserDetail = await _userDetailsRepository.GetUserDetailsByIdAsync(Id);
                if (objUserDetail != null)
                {
                    ResultDataArgs.StatusCode = Messagecatalog.ErrorCodes.Success;
                    ResultDataArgs.StatusMessage = Messagecatalog.ErrorMessages.Success;
                    ResultDataArgs.ResultData = objUserDetail;
                }
                else
                {
                    ResultDataArgs.StatusCode = Messagecatalog.ErrorCodes.NoRecordFound;
                    ResultDataArgs.StatusMessage = Messagecatalog.ErrorMessages.NoRecordFound;
                }
            }
            catch (Exception ex)
            {

            }
            return ResultDataArgs;
        }

        public async Task<ResultDataArgs> UpdateUserDetailsAsync(UserDetailsDTO userDetailDTO)
        {

            ResultDataArgs ResultDataArgs = new ResultDataArgs();
            try
            {
                int objUserDetail = await _userDetailsRepository.UpdateUserDetailsAsync(userDetailDTO);
                if (objUserDetail == 0)
                {
                    ResultDataArgs.StatusCode = Messagecatalog.ErrorCodes.Success;
                    ResultDataArgs.StatusMessage = Messagecatalog.ErrorMessages.SaveSuccess;
                   
                }
                else
                {
                    ResultDataArgs.StatusCode = Messagecatalog.ErrorCodes.Failed;
                    ResultDataArgs.StatusMessage = Messagecatalog.ErrorMessages.SaveFailed;
                }
            }
            catch (Exception ex)
            {
                
            }
            return ResultDataArgs;
        }
    }
}