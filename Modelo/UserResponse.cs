
using Newtonsoft.Json;

public class UserResponse
{
    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("tenant")]
    public object Tenant { get; set; }

    [JsonProperty("token")]
    public string Token { get; set; }

    [JsonProperty("navigation")]
    public List<Navigation> Navigation { get; set; }

    [JsonProperty("defaultPage")]
    public string DefaultPage { get; set; }
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

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("last_activity_date")]
    public DateTime LastActivityDate { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("reset_password")]
    public int ResetPassword { get; set; }

    [JsonProperty("notifications")]
    public string Notifications { get; set; }

    [JsonProperty("has_access_ici_service")]
    public int HasAccessIciService { get; set; }

    [JsonProperty("work_phone")]
    public string WorkPhone { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("projects")]
    public List<ProjectLogin> Projects { get; set; }

    [JsonProperty("roles")]
    public List<Role> Roles { get; set; }

    [JsonProperty("permissions")]
    public List<object> Permissions { get; set; }
}

public class ProjectLogin
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("projectId")]
    public int? ProjectId { get; set; }

    [JsonProperty("project_type_id")]
    public int ProjectTypeId { get; set; }

    [JsonProperty("branch_id")]
    public int BranchId { get; set; }

    [JsonProperty("tenant_id")]
    public object TenantId { get; set; }

    [JsonProperty("migrated")]
    public int Migrated { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("deleted_at")]
    public object DeletedAt { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("pivot")]
    public Pivot Pivot { get; set; }

    [JsonProperty("project_type")]
    public ProjectType ProjectType { get; set; }
}

public class Pivot
{
    [JsonProperty("user_id")]
    public int UserId { get; set; }

    [JsonProperty("project_id")]
    public int ProjectId { get; set; }
}

public class ProjectType
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("service_type_id")]
    public int ServiceTypeId { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("deleted_at")]
    public object DeletedAt { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("service_type")]
    public ServiceType ServiceType { get; set; }
}

public class ServiceType
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("deleted_at")]
    public object DeletedAt { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}

public class Role
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("pivot")]
    public RolePivot Pivot { get; set; }

    [JsonProperty("permissions")]
    public List<object> Permissions { get; set; }
}

public class RolePivot
{
    [JsonProperty("model_type")]
    public string ModelType { get; set; }

    [JsonProperty("model_id")]
    public int ModelId { get; set; }

    [JsonProperty("role_id")]
    public int RoleId { get; set; }
}

public class Navigation
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("iconName")]
    public string IconName { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("roles")]
    public List<string> Roles { get; set; }

    [JsonProperty("visible")]
    public bool Visible { get; set; }
}
