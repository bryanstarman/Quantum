using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Modelo
{
    public class FailureCityResponse
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("sourceId")]
        public int? SourceId { get; set; }

        [JsonProperty("branch_id")]
        public int? BranchId { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("branch")]
        public BranchFailureCity? Branch { get; set; }
    }
    public class BranchFailureCity
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("company_id")]
        public int? CompanyId { get; set; }

        [JsonProperty("country_id")]
        public int? CountryId { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("company")]
        public CompanyFailureCity? Company { get; set; }

        [JsonProperty("country")]
        public CountryFailureCity? Country { get; set; }
    }

    public class CompanyFailureCity
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("path")]
        public string? Path { get; set; }

        [JsonProperty("name")]
        public string? NameCompany { get; set; }
    }

    public class CountryFailureCity
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("capital")]
        public string? Capital { get; set; }

        [JsonProperty("code_iso")]
        public string? CodeIso { get; set; }

        [JsonProperty("code_iso3")]
        public string? CodeIso3 { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("calling_code")]
        public string? CallingCode { get; set; }

        [JsonProperty("flag_url")]
        public string? FlagUrl { get; set; }

        [JsonProperty("TimezoneCode")]
        public string? TimezoneCode { get; set; }
    }
}
