using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class AWSConfiguration : IAWSConfiguration
    {
        public 
         AWSConfiguration()
        {
            BucketName = "todo-app-staging";
            Region = "ap-south-1";
            AwsAccessKey = "AKIA3FEXHETZWUKA6OO6";
            AwsSecretAccessKey = "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";
            AwsSessionToken = "";
        }

        public string BucketName { get; set; }
        public string Region { get; set; }
        public string AwsAccessKey { get; set; }
        public string AwsSecretAccessKey { get; set; }
        public string AwsSessionToken { get; set; }
    }
}
