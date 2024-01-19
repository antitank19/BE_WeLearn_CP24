using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIExtension.Validator
{
    public class ValidatorResult
    {
        public ValidatorResult()
        {
            Failures = new List<string?>();
            FailuresMap=new Dictionary<string, string>();
        }

        public bool IsValid => !Failures.Any();

        public List<string?> Failures { get; set; }
        public Dictionary<string, string> FailuresMap { get; set; }
        public void AddError(string errorName, string error)
        {
            Failures.Add(error);
            FailuresMap.Add(errorName, error);
            //if (FailuresMap.ContainsKey(errorName))
            //{
            //    FailuresMap.Add(errorName, error);
            //}
        }
    }
}
