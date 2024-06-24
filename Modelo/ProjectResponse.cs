using Newtonsoft.Json;


namespace Quantum.Modelo
{
    public class ProjectResponse
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("projects")]
        public List<Project> Projects { get; set; }
    }

    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_verified_at")]
        public DateTime EmailVerifiedAt { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("work_phone")]
        public string WorkPhone { get; set; }

        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }

        [JsonProperty("last_activity_date")]
        public DateTime LastActivityDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("has_access_ici_service")]
        public int HasAccessIciService { get; set; }

        [JsonProperty("reset_password")]
        public int ResetPassword { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }


    }


    public class Project
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("projectId")]
        public int? ProjectId { get; set; }

        [JsonProperty("project_type_id")]
        public int? ProjectTypeId { get; set; }

        [JsonProperty("branch_id")]
        public int? BranchId { get; set; }

        [JsonProperty("tenant_id")]
        public int? TenantId { get; set; }

        [JsonProperty("migrated")]
        public int? Migrated { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("pivot")]
        public Pivot Pivot { get; set; }

        [JsonProperty("branch")]
        public Branch Branch { get; set; }

        [JsonProperty("project_type")]
        public ProjectType ProjectType { get; set; }
    }

    public class Pivot
    {
        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        [JsonProperty("project_id")]
        public int? ProjectId { get; set; }
    }

    public class Branch
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("branchId")]
        public int? BranchId { get; set; }

        [JsonProperty("company_id")]
        public int? CompanyId { get; set; }

        [JsonProperty("country_id")]
        public int? CountryId { get; set; }

        [JsonProperty("timezone")]
        public string? Timezone { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }
    }

    public class Company
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("companyId")]
        public int? CompanyId { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("path")]
        public string? Path { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

    public class Country
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

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("TimezoneCode")]
        public string? TimezoneCode { get; set; }
    }

    public class ProjectType
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("service_type_id")]
        public int? ServiceTypeId { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("service_type")]
        public ServiceType ServiceType { get; set; }
    }

    public class ServiceType
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
