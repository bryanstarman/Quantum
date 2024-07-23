using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Quantum.Modelo
{
    public class TroubleTicketsResponse
    {
        [JsonProperty("current_page")]
        public int? CurrentPage { get; set; }

        [JsonProperty("data")]
        public List<TroubleTicketData>? Data { get; set; }

        [JsonProperty("first_page_url")]
        public string? FirstPageUrl { get; set; }

        [JsonProperty("from")]
        public int? From { get; set; }

        [JsonProperty("last_page")]
        public int? LastPage { get; set; }

        [JsonProperty("last_page_url")]
        public string? LastPageUrl { get; set; }

        [JsonProperty("links")]
        public List<Link>? Links { get; set; }

        [JsonProperty("next_page_url")]
        public string? NextPageUrl { get; set; }

        [JsonProperty("path")]
        public string? Path { get; set; }

        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        [JsonProperty("prev_page_url")]
        public string? PrevPageUrl { get; set; }

        [JsonProperty("to")]
        public int? To { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }

    public class TroubleTicketData
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("ticket_id")]
        public int? TicketId { get; set; }

        [JsonProperty("failure_city_id")]
        public int? FailureCityId { get; set; }

        [JsonProperty("delivery_city_id")]
        public int? DeliveryCityId { get; set; }

        [JsonProperty("additional_information")]
        public string? AdditionalInformation { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("ticket")]
        public TicketTrouble? Ticket { get; set; }

        [JsonProperty("delivery_city")]
        public DeliveryCity? DeliveryCity { get; set; }

        [JsonProperty("failure_city")]
        public FailureCity? FailureCity { get; set; }

        //[JsonProperty("logistics")]
        //public List<object>? Logistics { get; set; }

        [JsonProperty("detail")]
        public DetailTrouble? DetailLV1 { get; set; }
    }

    public class TicketTrouble
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("TicketID")]
        public int? TicketID { get; set; }

        [JsonProperty("creator_id")]
        public int? CreatorId { get; set; }

        [JsonProperty("identify")]
        public int? Identify { get; set; }

        [JsonProperty("ticket_number")]
        public string? TicketNumber { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("timezone")]
        public string? Timezone { get; set; }

        [JsonProperty("project_id")]
        public int? ProjectId { get; set; }

        [JsonProperty("status_id")]
        public int? StatusId { get; set; }

        [JsonProperty("service_type_id")]
        public int? ServiceTypeId { get; set; }

        [JsonProperty("check_sla")]
        public int? CheckSla { get; set; }

        [JsonProperty("additional_information")]
        public string? AdditionalInformation { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("created_at_local")]
        public string? CreatedAtLocal { get; set; }

        [JsonProperty("code_identify")]
        public string? CodeIdentify { get; set; }

        [JsonProperty("created_at_tz")]
        public string? CreatedAtTz { get; set; }

        [JsonProperty("created_at_for_sla")]
        public DateTime? CreatedAtForSla { get; set; }

        [JsonProperty("has_sla_assigned")]
        public bool? HasSlaAssigned { get; set; }

        //[JsonProperty("lab_assignment")]
        //public object? LabAssignment { get; set; }

        [JsonProperty("status")]
        public Status? Status { get; set; }

        [JsonProperty("service_type")]
        public ServiceTypeTrouble? ServiceType { get; set; }

        [JsonProperty("technicals")]
        public List<Technical>? Technicals { get; set; }

        [JsonProperty("project")]
        public ProjectTrouble? Project { get; set; }

        [JsonProperty("creator")]
        public Creator? Creator { get; set; }

        [JsonProperty("status_histories")]
        public List<StatusHistory>? StatusHistories { get; set; }

        //[JsonProperty("sla")]
        //public object? Sla { get; set; }
    }

    public class DeliveryCity
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
    }


    public class FailureCity
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
    }


    public class DetailTrouble
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("trouble_ticket_info_id")]
        public int? TroubleTicketInfoId { get; set; }

        [JsonProperty("item_master_id")]
        public int? ItemMasterId { get; set; }

        [JsonProperty("sla_time")]
        public int? SlaTime { get; set; }

        [JsonProperty("sla_unit_id")]
        public int? SlaUnitId { get; set; }

        [JsonProperty("part_number")]
        public string? PartNumber { get; set; }

        [JsonProperty("serial")]
        public string? Serial { get; set; }

        [JsonProperty("revision")]
        public string? Revision { get; set; }

        [JsonProperty("remedy")]
        public string? Remedy { get; set; }

        [JsonProperty("location_id")]
        public int? LocationId { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("warranty")]
        public int? Warranty { get; set; }

        /*[JsonProperty("lab_warranty")]
        public object? LabWarranty { get; set; }

        [JsonProperty("check_warranty")]
        public object? CheckWarranty { get; set; }

        [JsonProperty("sla_status")]
        public object? SlaStatus { get; set; }

        [JsonProperty("advancement")]
        public object? Advancement { get; set; }
        */
        [JsonProperty("sla_unit")]
        public SlaUnitDetailLV1? SlaUnit { get; set; }

        [JsonProperty("sla")]
        public SlaDetailLV1? Sla { get; set; }

        [JsonProperty("location")]
        public Location? Location { get; set; }

        //[JsonProperty("logistic_item")]
        //public object? LogisticItem { get; set; }

        [JsonProperty("item_master")]
        public ItemMasterLV1? ItemMaster { get; set; }
    }

    public class SlaUnitDetailLV1
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("unit")]
        public string? Unit { get; set; }

        [JsonProperty("nomenclature")]
        public string? Nomenclature { get; set; }

        [JsonProperty("letter_format")]
        public string? LetterFormat { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("factor_conversion")]
        public int? FactorConversion { get; set; }

        [JsonProperty("weekdays")]
        public int? Weekdays { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

    public class SlaDetailLV1
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("model_id")]
        public int? ModelId { get; set; }

        [JsonProperty("model_type")]
        public string? ModelType { get; set; }

        [JsonProperty("running_sla_name")]
        public string? RunningSlaName { get; set; }

        [JsonProperty("started_at")]
        public DateTime? StartedAt { get; set; }

        [JsonProperty("stopped_at")]
        public DateTime? StoppedAt { get; set; }

        [JsonProperty("time_elapsed")]
        public string? TimeElapsed { get; set; }

        [JsonProperty("time_elapsed_value")]
        public int? TimeElapsedValue { get; set; }

        [JsonProperty("days")]
        public int? Days { get; set; }

        [JsonProperty("hours")]
        public int? Hours { get; set; }

        [JsonProperty("minutes")]
        public int? Minutes { get; set; }

        [JsonProperty("seconds")]
        public int? Seconds { get; set; }

        [JsonProperty("fulfillment")]
        public int? Fulfillment { get; set; }

        [JsonProperty("status_sla")]
        public string? StatusSla { get; set; }

        [JsonProperty("sla_result")]
        public string? SlaResult { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("timezone")]
        public string? Timezone { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("started_at_tz")]
        public DateTime? StartedAtTz { get; set; }

        [JsonProperty("stopped_at_tz")]
        public DateTime? StoppedAtTz { get; set; }
    }

    public class Sla
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("ticket_detail_id")]
        public int? TicketDetailId { get; set; }

        [JsonProperty("item_master_id")]
        public int? ItemMasterId { get; set; }

        [JsonProperty("sla_status_id")]
        public int? SlaStatusId { get; set; }

        [JsonProperty("sla_type_id")]
        public int? SlaTypeId { get; set; }

        [JsonProperty("sla_unit_id")]
        public int? SlaUnitId { get; set; }

        [JsonProperty("sla_id")]
        public int? SlaId { get; set; }

        [JsonProperty("sla_date")]
        public DateTime? SlaDate { get; set; }

        [JsonProperty("sla_end")]
        public DateTime? SlaEnd { get; set; }

        [JsonProperty("sla_time")]
        public int? SlaTime { get; set; }

        //[JsonProperty("advancement")]
        //public object? Advancement { get; set; }

        [JsonProperty("is_completed")]
        public int? IsCompleted { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }

    public class Location
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("address_id")]
        public int? AddressId { get; set; }

        [JsonProperty("category_id")]
        public int? CategoryId { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }

    public class ItemMasterLV1
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("spmItemID")]
        public string? SpmItemID { get; set; }

        [JsonProperty("part_number")]
        public string? PartNumber { get; set; }

        [JsonProperty("part_number_homologated")]
        public string? PartNumberHomologated { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("layer_id")]
        public int? LayerId { get; set; }

        [JsonProperty("branch_id")]
        public int? BranchId { get; set; }

        [JsonProperty("oem_id")]
        public int? OemId { get; set; }

        [JsonProperty("sla_time")]
        public string? SlaTime { get; set; } // Assuming this can be a string or null

        [JsonProperty("sla_unit_id")]
        public int? SlaUnitId { get; set; }

        [JsonProperty("unit_id")]
        public int? UnitId { get; set; }

        [JsonProperty("time")]
        public int? Time { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("serialized")]
        public int? Serialized { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; } // Nullable DateTime

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("is_serialized")]
        public string? IsSerialized { get; set; }

        [JsonProperty("oem")]
        public OemItemMasterLV1? Oem { get; set; }

        [JsonProperty("details")]
        public DetailsItemMasterLV1? Details { get; set; }
    }

    public class OemItemMasterLV1
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("OemId")]
        public int? OemId { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; } // Nullable DateTime

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

    public class DetailsItemMasterLV1
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("items_master_id")]
        public int? ItemsMasterId { get; set; }

        [JsonProperty("segment_id")]
        public int? SegmentId { get; set; }

        [JsonProperty("technology_id")]
        public int? TechnologyId { get; set; }

        [JsonProperty("controller_type_id")]
        public int? ControllerTypeId { get; set; }

        [JsonProperty("network_element_id")]
        public int? NetworkElementId { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("technology")]
        public TechnologyDetailsItemMasterLV1? Technology { get; set; }
    }

    public class TechnologyDetailsItemMasterLV1
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("technologyId")]
        public int? TechnologyId { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; } // Nullable DateTime

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
    public class ItemMaster
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("sku")]
        public string? Sku { get; set; }

        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }

    public class Status
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("source_id")]
        public int? SourceId { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("icon")]
        public string? Icon { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }

    public class ServiceTypeTrouble
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("source_id")]
        public int? SourceId { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("icon")]
        public string? Icon { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }

    public class Technical
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }

    public class ProjectTrouble
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("source_id")]
        public int? SourceId { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }

    public class Creator
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("email_verified_at")]
        public DateTime? EmailVerifiedAt { get; set; } // Nullable DateTime

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("work_phone")]
        public string? WorkPhone { get; set; }

        [JsonProperty("mobile_phone")]
        public string? MobilePhone { get; set; }

        [JsonProperty("last_activity_date")]
        public DateTime? LastActivityDate { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("has_access_ici_service")]
        public int? HasAccessIciService { get; set; }

        [JsonProperty("reset_password")]
        public int ResetPassword { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; } // Nullable DateTime

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }

    public class StatusHistory
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("ticket_id")]
        public int? TicketId { get; set; }

        [JsonProperty("status_id")]
        public int? StatusId { get; set; }

        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        [JsonProperty("additional_information")]
        public string? AdditionalInformation { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }

    public class Link
    {
        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("label")]
        public string? Label { get; set; }

        [JsonProperty("active")]
        public bool? Active { get; set; }
    }


    public class NewTicketSP{
        [JsonProperty("current")]
        public int? Current { get; set; }
        [JsonProperty("currentCode")]
        public string? CurrentCode { get; set; }
        [JsonProperty("created_at")]
        public string? CreatedAt { get; set; }
        [JsonProperty("new")]
        public int? New { get; set; }
        [JsonProperty("newCode")]
        public string? NewCode { get; set; }
    }
}
