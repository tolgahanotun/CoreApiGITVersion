using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Response
{
    public class GenericResponse<T> where T : class , new()
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }

        //Error
        public GenericResponse( string errorMessage )
        {
            Message = errorMessage;
            Success = false;
        }
        //Success
        public GenericResponse( T ent)
        {
            Object = ent;
            Success = true;
            Message = string.Empty;
        }

        

    }
}
