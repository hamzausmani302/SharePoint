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
            BucketName = "";    //enter bucket name
            Region = "";          //enter your region
            AwsAccessKey = "";      //enter access key from Iam roles
            AwsSecretAccessKey = "";        //enter secret key from iam role
            AwsSessionToken = "";
        }

        public string BucketName { get; set; }
        public string Region { get; set; }
        public string AwsAccessKey { get; set; }
        public string AwsSecretAccessKey { get; set; }
        public string AwsSessionToken { get; set; }
    }
}
