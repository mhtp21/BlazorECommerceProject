using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class BusinessProblemDetails : ProblemDetails
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
