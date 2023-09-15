using Dapper;
using Meeting.Framework.Helper;
using Meeting.Models.Input;
using Meeting.Models.Output;
using Meeting.Repository.Interface;
using Microsoft.Extensions.Configuration;
using MVC.DBEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Meeting.Repository.Repository
{
    public class RegisterationRepostory: IRegisterationRepostory
    {
        private readonly IDapperHandler _configuration;

        public RegisterationRepostory(IDapperHandler configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddUserDetailsAsync(UserDetailsDTO userDetailDTO)
        {
            var parameters = new DynamicParameters();
            Int16 ReturnValue = 0;
            try
            {
                
                parameters.Add(DBParameter.Registeration.teamName, userDetailDTO.TeamName, DbType.String);
                parameters.Add(DBParameter.Registeration.roomNo, userDetailDTO.RoomNo, DbType.Int16);
                parameters.Add(DBParameter.Registeration.meetingDate, userDetailDTO.MeetingDate, DbType.String);
                parameters.Add(DBParameter.Registeration.fromTime, userDetailDTO.FromTime, DbType.String);
                parameters.Add(DBParameter.Registeration.toTime, userDetailDTO.ToTime, DbType.String);
                parameters.Add(DBParameter.Registeration.purpose, userDetailDTO.Purpose, DbType.String);


                ReturnValue = await _configuration.ExecuteScalarAsync<Int16>(StoreProc.Registeration.Save, parameters,CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                
            }

            return ReturnValue;
        }

        public async Task<int> DeleteUserDetailsAsync(int Id)
        {
            Int16 ReturnValue = 0;
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add(DBParameter.Registeration.bookingId, Id, DbType.Int64);
                

                ReturnValue = await _configuration.ExecuteScalarAsync<Int16>(StoreProc.Registeration.Delete, parameters);
            }
            catch (Exception ex)
            {
               
            }
            return ReturnValue;
        }
         
        public async Task<UserDetailResult> GetUserDetailsAsync()
        {
            UserDetailResult userDetailsDTO = new UserDetailResult();
            try
            {

                userDetailsDTO.UserDetailsList = (await _configuration.QueryAsync<UserDetailsDTO>(StoreProc.Registeration.Select)).ToList();
            }
            catch (Exception ex)
            {
               
            }
            return userDetailsDTO;
        
        }

        public async Task<UserDetailsDTO> GetUserDetailsByIdAsync(int Id)
        {
            UserDetailsDTO userDetailsDTO = new UserDetailsDTO();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(DBParameter.Registeration.bookingId, Id, DbType.Int32);
                userDetailsDTO = (await _configuration.QuerySingleAsync<UserDetailsDTO>(StoreProc.Registeration.SelectById, parameters));
            }
            catch (Exception ex)
            {
                 
            }
            return userDetailsDTO;

        }

        public async Task<int> UpdateUserDetailsAsync(UserDetailsDTO userDetailDTO)
        {
            var parameters = new DynamicParameters();
            Int16 ReturnValue = 0;
            try
            {
                parameters.Add(DBParameter.Registeration.bookingId, userDetailDTO.BookingId, DbType.Int16);
                parameters.Add(DBParameter.Registeration.teamName, userDetailDTO.TeamName, DbType.String);
                parameters.Add(DBParameter.Registeration.roomNo, userDetailDTO.RoomNo, DbType.Int16);
                parameters.Add(DBParameter.Registeration.meetingDate, userDetailDTO.MeetingDate, DbType.String);
                parameters.Add(DBParameter.Registeration.fromTime, userDetailDTO.FromTime, DbType.String);
                parameters.Add(DBParameter.Registeration.toTime, userDetailDTO.ToTime, DbType.String);
                parameters.Add(DBParameter.Registeration.purpose, userDetailDTO.Purpose, DbType.String);


                ReturnValue = await _configuration.ExecuteScalarAsync<Int16>(StoreProc.Registeration.Update, parameters);
            }
            catch (Exception ex)
            {

            }

            return ReturnValue;
        }
    }
} 
