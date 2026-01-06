namespace Emdep.Geos.Infrastructure.Constants
{
    public static class APMConstants
    {
        public static class StoredProcedures
        {
            public const string APM_GetActionPlanDetails = "APM_GetActionPlanDetails_V2690";
            public const string APM_GetDepartmentsForActionPlan = "APM_GetDepartmentsForActionPlan_V2590";
            public const string APM_GetResponsibleByLocation = "APM_GetResponsibleByLocation_V2670";
            public const string APM_GetAllYBPCode = "APM_GetAllYBPCode";
            public const string APM_GetCustomersWithSitesAndResponsible = "APM_GetCustomersWithSitesAndResponsible_V2690";
            public const string APM_GetAuthorizedLocationListByIdUser = "APM_GetAuthorizedLocationListByIdUser_V2690";
        }

        public static class SqlQueries
        {
            public const string GetLookupValuesQuery = @"
                SELECT IdLookupValue, Value, HtmlColor, Position, IdLookupKey, 
                       Abbreviation, ImageName, IdParent, InUse
                FROM lookup_values 
                WHERE IdLookupKey = @Key AND InUse = 1 
                ORDER BY Position";
        }
    }
}