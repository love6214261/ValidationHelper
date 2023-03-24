using System;
using System.Refelection;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace ValidationTool
{
    public static class ValidationHelper
    {
        public static bool ValidateDTOIsNullOrEmpty<T>(T inputDTO)
        {
            try 
            {
                bool validatedResult = false;
                string errorMsg = ValidateDTOAndGetErrorMsg(inputDTO);
                if (errorMsg != "")
                {
                    throw new Exception(errorMsg);
                } 
                else
                {
                    return validatedResult;
                }
            }
            catch (Exception e)
            {
                string err = string.Format("Error happened during ValidateDTOIsNullOrEmpty:" + e.Message);
                throw new Exception(err);
            }
        }

        private static string ValidateDTOAndGetErrorMsg<T>(T inputDTO, string errorMsg = "")
        {
            Type dtoType = inputDTO.GetType();

            foreach (PropertyInfo property in dtoType.GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    if (property.GetCustomAttribute(typeof(ValidationAttributes.NotNullOrEmptyAttribute) != null))
                    {
                        string propertyValue = (string)property.GetValue(inputDTO);
                        if(string.IsNullOrEmpty(propertyValue))
                        {
                            ValidationAttributes.NotNullOrEmptyAttribute propertyAttr = (ValidationAttributes.NotNullOrEmptyAttribute)property.GetCustomAttribute(typeof(ValidationAttributes.NotNullOrEmptyAttribute))
                            errorMsg += propertyAttr.ErrorContext;
                        }
                    }
                }
                else if (property.PropertyType.Name.Equals("List`1"))
                {
                    foreach (var listContent in (IList)property.GetValue(inputDTO))
                    {
                        errorMsg = ValidateDTOAndGetErrorMsg(listContent, errorMsg);
                    }
                }
                else
                {
                    errorMsg = ValidateDTOAndGetErrorMsg(property.GetValue(inputDTO), errorMsg);
                }
            }

            return errorMsg;
        } 
    }
}
Console.WriteLine("Hello, World!");
