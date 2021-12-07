using Dapper;
using MultiLanguageWebApplication.Common.ConfigSettings;
using MultiLanguageWebApplication.Common.Logger;
using MultiLanguageWebApplication.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MultiLanguageWebApplication.DataAccess
{
    public class MultiLanguageDA
    {
        public static async Task<long> InsertUpdateLanguage(long languageID, string language, string isoCode)
        {
            long id = 0;

            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("LanguageID", languageID);
                param.Add("Language", language);
                param.Add("ISOCode", isoCode);
                param.Add("IsActive", true);
                param.Add("CreatedDate", DateTime.Now);
                param.Add("ModifiedDate", DateTime.Now);

                using (var connection = new SqlConnection(ConfigSettings.ConnectionString))
                {
                    id = await connection.ExecuteScalarAsync<long>("dbo.InsertUpdateLanguage", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                await Logger.Error(ex, "Error in MultiLanguageDA.InsertUpdateLanguage");
            }

            return id;
        }
        public static async Task<IEnumerable<LanguageDetailsDTO>> SelectLanguageDetails(long languageID)
        {
            IEnumerable<LanguageDetailsDTO> result = null;

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("LanguageID", languageID);

                using (var connection = new SqlConnection(ConfigSettings.ConnectionString))
                {
                    result = await connection.QueryAsync<LanguageDetailsDTO>("dbo.SelectLanguageDetails", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                await Logger.Error(ex, "Error in BannerDA.SelectLanguageDetails");
            }

            return result;
        }
        public static async Task<long> DeleteLanguage(long languageID)
        {
            long response = -1;

            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("LanguageID", languageID);
                param.Add("IsActive", false);
                param.Add("ModifiedDate", DateTime.Now);

                using (var connection = new SqlConnection(ConfigSettings.ConnectionString))
                {
                    response = await connection.ExecuteAsync("dbo.DeleteLanguage", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                await Logger.Error(ex, "Error in MultiLanguageDA.DeleteLanguage");
            }

            return response;
        }

        public static async Task<long> InsertUpdateLanguageResource(LanguageResourceDTO resource)
        {
            long id = 0;

            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("LanguageID", resource.LanguageID);
                param.Add("ResourceKey", resource.ResourceKey);
                param.Add("ResourceValue", resource.ResourceValue);
                param.Add("CreatedDate", DateTime.Now);
                param.Add("ModifiedDate", DateTime.Now);

                using (var connection = new SqlConnection(ConfigSettings.ConnectionString))
                {
                    id = await connection.ExecuteScalarAsync<long>("dbo.InsertUpdateLanguageResouces", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                await Logger.Error(ex, "Error in MultiLanguageDA.InsertUpdateLanguageResouces");
            }

            return id;
        }
        public static async Task<IEnumerable<LanguageResourceDTO>> SelectLanguageResourceDetails(long resourceID)
        {
            IEnumerable<LanguageResourceDTO> result = null;

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("ResourceID", resourceID);

                using (var connection = new SqlConnection(ConfigSettings.ConnectionString))
                {
                    result = await connection.QueryAsync<LanguageResourceDTO>("dbo.SelectLanguageResourceDetails", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                await Logger.Error(ex, "Error in BannerDA.SelectLanguageResourceDetails");
            }

            return result;
        }
    }
}