using Newtonsoft.Json;

namespace SenteRecruitmentApplication.Data
{
    public partial class Company
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("subject")]
        public Subject Subject { get; set; }

    }

    public partial class Subject
    {

        [JsonProperty("accountNumbers")]
        public string[] AccountNumbers { get; set; }


    }
}
